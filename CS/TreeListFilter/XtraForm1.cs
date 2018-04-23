using System;
using DevExpress.XtraEditors;

namespace TreeListFilter
{
	public partial class XtraForm1 : XtraForm
	{
		public XtraForm1()
		{
			InitializeComponent();
		}

		private void XtraForm1_Load(object sender, EventArgs e)
		{
			this.departmentsTableAdapter.Fill(this.departmentsDataSet.Departments);
			filterTreeList1.ExpandAll();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			filterTreeList1.ColumnFilterConditions.SaveToXml("..\\..\\filters.xml");
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			filterTreeList1.ColumnFilterConditions.RestoreFromXml("..\\..\\filters.xml");
		}
	}
}