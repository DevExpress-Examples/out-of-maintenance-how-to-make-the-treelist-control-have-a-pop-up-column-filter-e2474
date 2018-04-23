using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FilterTreeListControl
{
	public partial class PopupForm : XtraForm
	{
		private const int WM_NCHITTEST = 0x84;
		private const int HT_BOTTOMRIGHT = 0x11;

		private readonly FilterTreeList ownerTreeList;
		private bool popupFormClosing;
		private ColumnFilterItem selectedFilterItem;

		public PopupForm(FilterTreeList owner)
		{
			InitializeComponent();
			ownerTreeList = owner;
		}

		protected override void WndProc(ref Message m)
		{
			if ( m.Msg == WM_NCHITTEST )
			{
				Point pt = this.PointToClient(new Point((int)m.LParam));

				if ( pt.X > this.Width - 5 && pt.Y > this.Height - 5 )
					m.Result = (IntPtr)HT_BOTTOMRIGHT;
			}
			else
				base.WndProc(ref m);
		}

		private void Form2_Deactivate(object sender, EventArgs e)
		{
			if ( !popupFormClosing )
				this.Close();
		}

		private void filterItemsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedFilterItem = (ColumnFilterItem)filterItemsList.SelectedItem;
			popupFormClosing = true;
			this.Close();
		}

		public Rectangle CalcPopupRect(Rectangle filterButtonRect)
		{
			Rectangle popupRect = new Rectangle();

			int maxWidth = 0;
			int maxHeight = 0;
			Graphics graphics = this.CreateGraphics();
			int itemHeight = (int)Math.Round(graphics.MeasureString("0", this.filterItemsList.Font).Height) + 3;

			for ( int i = 0; i < this.filterItemsList.ItemCount; i++ )
			{
				SizeF szText = graphics.MeasureString(this.filterItemsList.Items[i].ToString(), this.filterItemsList.Font);
				int itemWidth = (int)Math.Round(szText.Width);

				if ( itemWidth > maxWidth )
					maxWidth = itemWidth;

				if ( i < 20 )
					maxHeight += itemHeight;
			}
			maxWidth += 10;

			if ( maxWidth > ownerTreeList.Width / 2 )
				maxWidth = ownerTreeList.Width / 2;

			DevExpress.XtraEditors.VScrollBar vScroll = new DevExpress.XtraEditors.VScrollBar();
			int vScrollWidth = vScroll.Width;
			vScroll.Dispose();

			if ( itemHeight * this.filterItemsList.ItemCount > maxHeight )
				maxWidth += vScrollWidth;

			popupRect.X = filterButtonRect.X;
			popupRect.Y = filterButtonRect.Bottom;
			popupRect.Location = ownerTreeList.PointToScreen(popupRect.Location);

			popupRect.Width = maxWidth;
			popupRect.Height = maxHeight;

			Rectangle screenWorkingArea = Screen.GetWorkingArea(popupRect.Location);
			if ( popupRect.Right > screenWorkingArea.Right )
				popupRect.X -= popupRect.Right - screenWorkingArea.Right;

			if ( popupRect.Bottom > screenWorkingArea.Bottom )
				popupRect.Y = ownerTreeList.PointToScreen(filterButtonRect.Location).Y - popupRect.Height;

			return popupRect;
		}

		public object SelectedFilterItem
		{
			get { return selectedFilterItem; }
		}
	}
}
