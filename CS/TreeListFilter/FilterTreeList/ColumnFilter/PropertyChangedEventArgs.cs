using System;

namespace FilterTreeListControl
{
	public class FilterConditionPropertyChangedEventArgs : EventArgs
	{
		readonly string changedPropertyName = "";

		public FilterConditionPropertyChangedEventArgs(string propertyName)
		{
			this.changedPropertyName = propertyName;
		}

		public string ChangedPropertyName
		{
			get { return changedPropertyName; }
		}
	}
}
