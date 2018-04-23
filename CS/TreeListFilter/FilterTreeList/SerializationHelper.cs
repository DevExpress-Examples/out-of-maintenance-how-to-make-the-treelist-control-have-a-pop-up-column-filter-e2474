using DevExpress.Utils.Serializing;

namespace FilterTreeListControl
{
	class FilterSerializationHelper
	{
		private readonly ColumnFilterConditionCollection filterCollection;

		public FilterSerializationHelper(ColumnFilterConditionCollection collection)
		{
			filterCollection = collection;
		}

		[XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 1001)]
		public ColumnFilterConditionCollection FilterConditions
		{
			get { return filterCollection; }
		}

		private bool XtraShouldSerializeFilterConditions()
		{
			return true;
		}
		internal void XtraClearFilterConditions(XtraItemEventArgs e)
		{
			filterCollection.Clear();
		}
		internal object XtraCreateFilterConditionsItem(XtraItemEventArgs e)
		{
			ColumnFilterCondition filterCondition = new ColumnFilterCondition();
			filterCollection.Add(filterCondition);
			return filterCondition;
		}
	}
}
