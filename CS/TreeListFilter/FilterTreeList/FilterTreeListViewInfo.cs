using System.Drawing;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;

namespace FilterTreeListControl
{
	public class FilterTreeListViewInfo : TreeListViewInfo
	{
		private const int filterPanelHeight = 30;

		public FilterTreeListViewInfo(TreeList treeList)
			: base(treeList)
		{
		}

		protected virtual void CalcFilterPanelRect(Rectangle clientRect)
		{
			if ( TreeList.FilterPanel == null )
				return;

			TreeList.FilterPanel.Left = clientRect.Left;
			TreeList.FilterPanel.Top = clientRect.Bottom;
			if ( TreeList.IsNeededHScrollBar )
				TreeList.FilterPanel.Top += TreeList.ScrollInfo.ScrollSize;

			TreeList.FilterPanel.Width = clientRect.Width;
			if ( TreeList.IsNeededVScrollBar )
				TreeList.FilterPanel.Width += TreeList.ScrollInfo.ScrollSize;

			TreeList.FilterPanel.Height = filterPanelHeight;

			TreeList.FilterLabel.Left = TreeList.FilterPanel.Left + 5;
			TreeList.FilterLabel.Top = TreeList.FilterPanel.Height / 2 - TreeList.FilterLabel.Height / 2;
			TreeList.FilterLabel.Width = TreeList.FilterPanel.Width - 5;
		}

		public override Rectangle CalcScrollRect(Rectangle windowRect)
		{
			Rectangle scrollRect = base.CalcScrollRect(windowRect);
			if ( TreeList.FilterActive )
				scrollRect.Height -= filterPanelHeight;

			return scrollRect;
		}

		protected override void CalcViewRects()
		{
			base.CalcViewRects();
			CalcFilterPanelRect(ViewRects.Client);
		}

		public new FilterTreeList TreeList
		{
			get { return (FilterTreeList)base.TreeList; }
		}
	}
}
