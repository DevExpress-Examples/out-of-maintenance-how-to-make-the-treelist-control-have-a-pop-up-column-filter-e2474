using System;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace FilterTreeListControl
{
	public partial class CustomFilterForm : XtraForm
	{
		public CustomFilterForm()
		{
			InitializeComponent();
		}

		private void RemoveConditionFromList(FilterConditionEnum condition)
		{
			int index = cbeFilterConditions.Properties.Items.IndexOf(Enum.GetName(typeof(FilterConditionEnum), condition));
			if ( index != -1 )
				cbeFilterConditions.Properties.Items.RemoveAt(index);
		}

		private void customFilterForm_Load(object sender, EventArgs e)
		{
			cbeFilterConditions.Properties.Items.AddRange(Enum.GetNames(typeof(FilterConditionEnum)));
			RemoveConditionFromList(FilterConditionEnum.Between);
			RemoveConditionFromList(FilterConditionEnum.NotBetween);
			RemoveConditionFromList(FilterConditionEnum.None);
		}

		private void cbeFilterConditions_EditValueChanged(object sender, EventArgs e)
		{
			sbOK.Enabled = ((ComboBoxEdit)sender).Text != "" && teValue.Text != "";
		}

		private void teValue_EditValueChanged(object sender, EventArgs e)
		{
			sbOK.Enabled = ((TextEdit)sender).Text != "" && cbeFilterConditions.Text != "";
		}
	}
}