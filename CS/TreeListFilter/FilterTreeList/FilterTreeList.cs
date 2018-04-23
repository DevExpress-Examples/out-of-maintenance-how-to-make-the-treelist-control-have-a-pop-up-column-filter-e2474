using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Serializing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Scrolling;
using DevExpress.XtraTreeList.ViewInfo;

namespace FilterTreeListControl
{
	public class FilterTreeList : TreeList
	{
		private readonly ColumnFilterEngine columnFilterEngine;
		private readonly PanelControl filterPanel;
		private readonly ScrollInfo scrollInfo;
		private LabelControl filterLabel;

		private readonly ColumnFilterConditionCollection columnFilterConditions;
		private readonly List<TreeListNode> filteredVisibleNodes = new List<TreeListNode>();

		public FilterTreeList()
		{
			columnFilterEngine = CreateColumnFilterEngine();
			scrollInfo = new ScrollInfo(this);

			columnFilterConditions = CreateColumnFilterConditions();
			filterPanel = CreateFilterPanel();
			filterPanel.Parent = this;
			filterPanel.LookAndFeel.Style = this.LookAndFeel.Style;

			CustomDrawColumnHeader += new CustomDrawColumnHeaderEventHandler(OnCustomDrawColumnHeader);
			NodeCellStyle += new GetCustomNodeCellStyleEventHandler(OnNodeCellStyle);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDown += new MouseEventHandler(OnMouseDown);
			MouseUp += new MouseEventHandler(OnMouseUp);
		}

		protected override void Dispose(bool disposing)
		{
			CustomDrawColumnHeader -= OnCustomDrawColumnHeader;
			NodeCellStyle -= OnNodeCellStyle;
			MouseMove -= OnMouseMove;
			MouseDown -= OnMouseDown;
			MouseUp -= OnMouseUp;

			base.Dispose(disposing);
		}

		protected virtual ColumnFilterEngine CreateColumnFilterEngine()
		{
			return new ColumnFilterEngine(this);
		}

		protected virtual ColumnFilterConditionCollection CreateColumnFilterConditions()
		{
			return new ColumnFilterConditionCollection(this);
		}

		protected virtual PanelControl CreateFilterPanel()
		{
			PanelControl panel = new PanelControl();
			filterLabel = new LabelControl();
			filterLabel.Parent = panel;
			filterLabel.AutoSizeMode = LabelAutoSizeMode.None;

			return panel;
		}

		private static GridFilterButtonInfoArgs GetFilterButtonInfoArgs(ColumnInfo colInfo)
		{
			if ( colInfo == null )
				return null;

			DrawElementInfo elementInfo = colInfo.InnerElements.Find(typeof(GridFilterButtonInfoArgs));
			if ( elementInfo != null )
				return (GridFilterButtonInfoArgs)elementInfo.ElementInfo;

			return null;
		}

		protected internal void SetFilterPanelVisibility(bool visible)
		{
			if ( filterPanel == null )
				return;

			if ( visible )
				filterLabel.Text = columnFilterConditions.ToString();

			filterPanel.Visible = visible;
		}

		private void OnCustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
		{
			if ( e.Column == null )
				return;

			ColumnInfo info = (ColumnInfo)e.ObjectArgs;
			for ( int i = 0; i < info.InnerElements.Count; i++ )
				if ( info.InnerElements[i].ElementInfo is GridFilterButtonInfoArgs )
					return;

			GridSmartSkinFilterButtonPainter painter = new GridSmartSkinFilterButtonPainter(UserLookAndFeel.Default);
			GridFilterButtonInfoArgs filterButtonInfo = new GridFilterButtonInfoArgs();
			filterButtonInfo.Cache = e.Cache;
			filterButtonInfo.Graphics = e.Graphics;

			DrawElementInfo elementInfo = info.InnerElements.Add(painter, filterButtonInfo);
			elementInfo.RequireTotalBounds = true;
			info.InnerElements.CalcBounds(e.ObjectArgs, e.Cache, e.Painter.GetObjectClientRectangle(e.ObjectArgs), e.Bounds);

			Rectangle captionRect = e.CaptionRect;
			captionRect.Width -= elementInfo.ElementInfo.Bounds.Width;
			info.CaptionRect = captionRect;
		}

		private void OnNodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
		{
			if ( columnFilterConditions.Count == 0 )
				return;

			if ( filteredVisibleNodes.Contains(e.Node) && !e.Node.Selected )
				e.Appearance.BackColor = Color.LightGray;
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if ( e.Button != MouseButtons.None )
				return;

			TreeListHitInfo hitInfo = ((TreeList)sender).CalcHitInfo(e.Location);
			if ( hitInfo.HitInfoType == HitInfoType.Column )
			{
				ColumnInfo colInfo = ((TreeList)sender).ViewInfo.ColumnsInfo[hitInfo.Column];
				GridFilterButtonInfoArgs filterButtonInfo = GetFilterButtonInfoArgs(colInfo);
				if ( filterButtonInfo != null )
				{
					if ( filterButtonInfo.Bounds.Contains(e.Location) )
						filterButtonInfo.State = ObjectState.Hot;
					else if ( hitInfo.Column == columnFilterEngine.FilterShowingColumn )
						filterButtonInfo.State = ObjectState.Pressed;
					else
						filterButtonInfo.State = ObjectState.Normal;

					((TreeList)sender).InvalidateColumnHeader(hitInfo.Column);
				}
			} else
			{
				foreach ( TreeListColumn col in ((TreeList)sender).Columns )
				{
					ColumnInfo colInfo = ((TreeList)sender).ViewInfo.ColumnsInfo[col];
					GridFilterButtonInfoArgs filterButtonInfo = GetFilterButtonInfoArgs(colInfo);
					if ( col != columnFilterEngine.FilterShowingColumn && filterButtonInfo != null )
					{
						if ( columnFilterConditions.ContainsColumn(col) )
							filterButtonInfo.State = ObjectState.Selected;
						else
							filterButtonInfo.State = ObjectState.Normal;

						((TreeList)sender).InvalidateColumnHeader(col);
					}
				}
			}
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			if ( e.Button != MouseButtons.Left )
				return;

			TreeListHitInfo hitInfo = ((TreeList)sender).CalcHitInfo(e.Location);
			if ( hitInfo.HitInfoType == HitInfoType.Column )
			{
				ColumnInfo colInfo = ((TreeList)sender).ViewInfo.ColumnsInfo[hitInfo.Column];
				GridFilterButtonInfoArgs filterButtonInfo = GetFilterButtonInfoArgs(colInfo);
				if ( filterButtonInfo != null && filterButtonInfo.Bounds.Contains(e.Location) )
				{
					filterButtonInfo.State = ObjectState.Pressed;
					((TreeList)sender).InvalidateColumnHeader(hitInfo.Column);

					throw new HideException();
				}
			}
		}

		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			if ( e.Button != MouseButtons.Left )
				return;

			TreeListHitInfo hitInfo = ((TreeList)sender).CalcHitInfo(e.Location);
			if ( hitInfo.HitInfoType == HitInfoType.Column )
			{
				ColumnInfo colInfo = ((TreeList)sender).ViewInfo.ColumnsInfo[hitInfo.Column];
				GridFilterButtonInfoArgs filterButtonInfo = GetFilterButtonInfoArgs(colInfo);
				if ( filterButtonInfo != null && filterButtonInfo.Bounds.Contains(e.Location) )
				{
					columnFilterEngine.ProcessFilterButtonClick(hitInfo.Column, filterButtonInfo.Bounds);

					filterButtonInfo.State = ObjectState.Pressed;
					((TreeList)sender).InvalidateColumnHeader(hitInfo.Column);

					throw new HideException();
				}
			}
		}

		public override void FilterNodes()
		{
			this.BeginUpdate();
			try
			{
				FilterNodesOperation filterNodesOperation = new FilterNodesOperation(columnFilterConditions);
				this.NodesIterator.DoLocalOperation(filterNodesOperation, this.Nodes);
				filteredVisibleNodes.AddRange(filterNodesOperation.FilteredVisibleNodes);
			} finally
			{
				this.EndUpdate();
			}
		}

		public List<TreeListNode> FilteredVisibleNodes
		{
			get { return filteredVisibleNodes; }
		}

		internal bool FilterActive
		{
			get { return columnFilterConditions.ToString() != ""; }
		}

		internal PanelControl FilterPanel
		{
			get { return filterPanel; }
		}

		internal LabelControl FilterLabel
		{
			get { return filterLabel; }
		}

		internal ScrollInfo ScrollInfo
		{
			get { return scrollInfo; }
		}

		internal new bool IsNeededHScrollBar
		{
			get { return base.IsNeededHScrollBar; }
		}

		internal new bool IsNeededVScrollBar
		{
			get { return base.IsNeededVScrollBar; }
		}

		protected override TreeListViewInfo CreateViewInfo()
		{
			return new FilterTreeListViewInfo(this);
		}

		public new TreeListViewInfo ViewInfo
		{
			get { return (TreeListViewInfo)base.ViewInfo; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 1001)]
		public ColumnFilterConditionCollection ColumnFilterConditions
		{
			get { return columnFilterConditions; }
		}
		internal void XtraClearColumnFilterConditions(XtraItemEventArgs e)
		{
			ColumnFilterConditions.Clear();
		}
		internal object XtraCreateColumnFilterConditionsItem(XtraItemEventArgs e)
		{
			ColumnFilterCondition filterCondition = new ColumnFilterCondition();
			ColumnFilterConditions.Add(filterCondition);
			return filterCondition;
		}
	}
}