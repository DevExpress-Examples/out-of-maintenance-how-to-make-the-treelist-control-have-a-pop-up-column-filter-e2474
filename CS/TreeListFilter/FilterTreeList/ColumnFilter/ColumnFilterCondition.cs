using System;
using System.ComponentModel;
using DevExpress.Utils.Serializing;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace FilterTreeListControl
{
	public delegate void FilterConditionPropertyChangedEventHandler(object sender, FilterConditionPropertyChangedEventArgs e);

	public class ColumnFilterCondition
	{
		private string fieldName;
		private FilterConditionEnum condition;
		private object value;
		private string displayText;
		private ColumnFilterConditionCollection storageCollection;

		public ColumnFilterCondition()
		{
		}
		public ColumnFilterCondition(string fieldName, FilterConditionEnum condition, object value, string displayText)
		{
			this.fieldName = fieldName;
			this.condition = condition;
			this.value = value;
			this.displayText = displayText;
		}

		public bool CheckValue(object valueToCheck)
		{
			if ( Collection == null || Column == null )
				return false;


			FilterCondition innerCondition = new FilterCondition(Condition, Column, Value);
			return innerCondition.CheckValue(valueToCheck);
		}

		public void Assign(ColumnFilterCondition source)
		{
			Collection = source.Collection;
			FieldName = source.FieldName;
			Condition = source.Condition;
			Value = source.Value;
			DisplayText = source.DisplayText;
		}

		protected TreeListColumn FindTreeListColumn()
		{
			if ( Collection == null )
				return null;

			return Collection.OwnerTreeList.Columns[FieldName];
		}


		protected void RaisePropertyChangedEvent(string propertyName)
		{
			FilterConditionPropertyChangedEventArgs args = new FilterConditionPropertyChangedEventArgs(propertyName);
			if ( FilterConditionPropertyChanged != null )
				FilterConditionPropertyChanged(this, args);
		}

		public override string ToString()
		{
			if ( String.IsNullOrEmpty(FieldName) || Condition == FilterConditionEnum.None || Collection == null )
				return "";

			if ( (Condition == FilterConditionEnum.IsBlank || Condition == FilterConditionEnum.IsNotBlank) )
				return String.Format("[{0}] {1}", Column.GetCaption(), Condition);

			object condValue = null;
			if ( Value != null )
				if ( Value.GetType() == typeof(string) )
					condValue = String.Format("'{0}'", DisplayText);
				else
					condValue = DisplayText;

			if ( condValue == null )
				return "";

			return String.Format("[{0}] {1} {2}", Column.GetCaption(), Condition, condValue);
		}

		[XtraSerializableProperty(XtraSerializationVisibility.Visible)]
		public string FieldName
		{
			get { return fieldName; }
			set
			{
				if ( fieldName == value )
					return;

				fieldName = value;
				RaisePropertyChangedEvent("FieldName");
			}
		}


		[XtraSerializableProperty(XtraSerializationVisibility.Visible)]
		public FilterConditionEnum Condition
		{
			get { return condition; }
			set
			{
				if ( condition == value )
					return;

				condition = value;
				RaisePropertyChangedEvent("Condition");
			}
		}


		[XtraSerializableProperty(XtraSerializationVisibility.Visible)]
		public object Value
		{
			get { return value; }
			set
			{
				if ( this.value == value )
					return;

				this.value = value;
				RaisePropertyChangedEvent("Value");
			}
		}

		[XtraSerializableProperty(XtraSerializationVisibility.Visible)]
		public string DisplayText
		{
			get { return displayText; }
			set
			{
				if ( displayText == value )
					return;

				displayText = value;
				RaisePropertyChangedEvent("DisplayText");
			}
		}

		[Browsable(false)]
		public ColumnFilterConditionCollection Collection
		{
			get { return storageCollection; }
			set { storageCollection = value; }
		}

		[Browsable(false)]
		public TreeListColumn Column
		{
			get { return FindTreeListColumn(); }
		}

		public event FilterConditionPropertyChangedEventHandler FilterConditionPropertyChanged;
	}
}