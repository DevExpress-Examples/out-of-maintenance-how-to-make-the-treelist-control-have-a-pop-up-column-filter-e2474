using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace FilterTreeListControl
{
	public class ColumnFilterEngine : IDisposable
	{
		private FilterTreeList ownerTreeList;
		private PopupForm filterPopupForm;
		private TreeListColumn filterShowingColumn;

		public ColumnFilterEngine(FilterTreeList owner)
		{
			ownerTreeList = owner;
		}

		protected virtual PopupForm CreatePopupForm()
		{
			return new PopupForm(ownerTreeList);
		}

		private void ShowPopupForm(Rectangle filterButtonBounds)
		{
			Rectangle filterPopupFormBounds = filterPopupForm.CalcPopupRect(filterButtonBounds);
			filterPopupForm.Bounds = filterPopupFormBounds;
			filterPopupForm.Show();
		}

		public void ProcessFilterButtonClick(TreeListColumn column, Rectangle filterButtonBounds)
		{
			filterShowingColumn = column;

			filterPopupForm = CreatePopupForm();
			filterPopupForm.FormClosing += new FormClosingEventHandler(filterPopupFormOnFormClosing);
			PopulateFilterList();
			ShowPopupForm(filterButtonBounds);
		}

		protected virtual List<ColumnFilterItem> GetFilterValues()
		{
			NodesValuesOperation nodesOperation = new NodesValuesOperation(filterShowingColumn);
			OwnerTreeList.NodesIterator.DoOperation(nodesOperation);
			return nodesOperation.Result;
		}

		private static void RemoveColumnDataDuplicates(List<ColumnFilterItem> columnValuesList)
		{
			ColumnFilterItem item = columnValuesList[0];
			int sameIndex = 0;
			int sameCount = 0;
			int i = 1;

			while ( i < columnValuesList.Count )
			{
				if ( columnValuesList[i] == item )
				{
					sameCount++;
					i++;
				} else
				{
					if ( sameCount > 0 )
					{
						columnValuesList.RemoveRange(sameIndex, sameCount);
						i = i - sameCount;
						sameCount = 0;
						sameIndex = i;
						item = columnValuesList[i];
						i++;
					} else
					{
						sameIndex = i;
						item = columnValuesList[i];
						i++;
					}
				}
			}

			if ( sameCount > 0 )
				columnValuesList.RemoveRange(sameIndex, sameCount);
		}

		private static bool IsFilterItemValueEmpty(ColumnFilterItem value)
		{
			return value.IsEmpty;
		}

		protected void PopulateFilterList()
		{
			List<ColumnFilterItem> columnValuesList = GetFilterValues();
			if ( columnValuesList.Count == 0 )
				return;

			columnValuesList.Sort(new FilterItemsComparer());
			columnValuesList.Insert(0, new ColumnFilterCustomItem());
			int blanksItemIndex = 1;
			if ( OwnerTreeList.ColumnFilterConditions.ContainsColumn(filterShowingColumn) )
			{
				columnValuesList.Insert(0, new ColumnFilterAllItem());
				blanksItemIndex++;
			}

			RemoveColumnDataDuplicates(columnValuesList);
			if ( columnValuesList.RemoveAll(IsFilterItemValueEmpty) != 0 )
			{
				columnValuesList.Insert(blanksItemIndex, new ColumnFilterBlanksItem());
				columnValuesList.Insert(blanksItemIndex + 1, new ColumnFilterNonBlanksItem());
			}

			filterPopupForm.filterItemsList.Items.Clear();
			filterPopupForm.filterItemsList.Items.AddRange(columnValuesList.ToArray());
		}

		private void AddSingleFilterCondition(string filterConditionString, ColumnFilterItem filterValue)
		{
			OwnerTreeList.FilteredVisibleNodes.Clear();

			FilterConditionEnum condition;
			ColumnFilterCondition newCondition;

			if ( filterValue is ColumnFilterBlanksItem )
				newCondition = new ColumnFilterCondition(filterShowingColumn.FieldName, FilterConditionEnum.IsBlank, null, null);
			else if ( filterValue is ColumnFilterNonBlanksItem )
				newCondition = new ColumnFilterCondition(filterShowingColumn.FieldName, FilterConditionEnum.IsNotBlank, null, null);
			else
			{
				condition = (FilterConditionEnum)Enum.Parse(typeof(FilterConditionEnum), filterConditionString);
				newCondition = new ColumnFilterCondition(filterShowingColumn.FieldName, condition, filterValue.Value, filterValue.DisplayText);
			}

			for ( int i = 0; i < OwnerTreeList.ColumnFilterConditions.Count; i++ )
				if ( OwnerTreeList.ColumnFilterConditions[i].Column == filterShowingColumn )
				{
					OwnerTreeList.ColumnFilterConditions.RemoveAt(i);
					break;
				}

			if ( !(filterValue is ColumnFilterAllItem) )
				OwnerTreeList.ColumnFilterConditions.Add(newCondition);
		}

		protected virtual CustomFilterForm CreateCustomFilterForm()
		{
			return new CustomFilterForm();
		}

		protected virtual void PopuplateFilterConditions(CustomFilterForm frm)
		{
			frm.filterGroupPanel.Text = filterShowingColumn.GetCaption();
			for ( int i = 0; i < OwnerTreeList.ColumnFilterConditions.Count; i++ )
				if ( OwnerTreeList.ColumnFilterConditions[i].Column == filterShowingColumn )
				{
					frm.cbeFilterConditions.Text = OwnerTreeList.ColumnFilterConditions[i].Condition.ToString();
					frm.teValue.Text = OwnerTreeList.ColumnFilterConditions[i].Value.ToString();
					break;
				}
		}

		protected virtual ColumnFilterItem GetCustomFilterValue(CustomFilterForm frm)
		{
			ColumnFilterItem filterValue;
			try
			{
				filterValue = new ColumnFilterItem(Convert.ChangeType(frm.teValue.EditValue, filterShowingColumn.ColumnType), frm.teValue.Text);
			} catch
			{
				filterValue = new ColumnFilterItem(frm.teValue.Text, frm.teValue.Text);
			}

			return filterValue;
		}

		private void ProcessItemSelection(object sender)
		{
			ColumnFilterItem filterValue = (ColumnFilterItem)((PopupForm)sender).SelectedFilterItem;
			if ( filterValue == null )
				return;

			if ( filterValue is ColumnFilterCustomItem && filterShowingColumn != null )
			{
				CustomFilterForm frm = CreateCustomFilterForm();
				PopuplateFilterConditions(frm);

				if ( frm.ShowDialog() == DialogResult.OK )
				{
					filterValue = GetCustomFilterValue(frm);
					AddSingleFilterCondition(frm.cbeFilterConditions.Text, filterValue);
				}
			} else if ( !filterValue.IsEmpty && filterShowingColumn != null )
				AddSingleFilterCondition("Equals", filterValue);

			filterShowingColumn = null;
		}

		private void filterPopupFormOnFormClosing(object sender, FormClosingEventArgs e)
		{
			ProcessItemSelection(sender);
		}

		public void Dispose()
		{
			ownerTreeList = null;
			filterShowingColumn = null;
		}

		public FilterTreeList OwnerTreeList
		{
			get { return ownerTreeList; }
		}

		public TreeListColumn FilterShowingColumn
		{
			get { return filterShowingColumn; }
		}
	}
}
