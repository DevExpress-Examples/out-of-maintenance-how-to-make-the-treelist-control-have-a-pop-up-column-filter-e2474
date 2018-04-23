using System;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace FilterTreeListControl
{
	public class ColumnFilterItem
	{
		private readonly object value;
		private readonly string displayText;

		public ColumnFilterItem(object value, string displayText)
		{
			this.value = value;
			this.displayText = displayText;
		}
		public ColumnFilterItem(TreeListNode node, TreeListColumn col)
		{
			value = node.GetValue(col);
			displayText = node.GetDisplayText(col);
		}

		protected virtual bool GetItemIsEmpty()
		{
			return (value == null || value == DBNull.Value);
		}

		public override bool Equals(object obj)
		{
			if ( !(obj is ColumnFilterItem) )
				return base.Equals(obj);

			ColumnFilterItem item = (ColumnFilterItem)obj;
			return Object.Equals(this.Value, item.Value) && this.DisplayText == item.DisplayText;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static bool operator ==(ColumnFilterItem item1, ColumnFilterItem item2)
		{
			if ( Object.Equals(item1, null) && Object.Equals(item2, null) )
				return true;

			if ( Object.Equals(item1, null) && !Object.Equals(item2, null) )
				return false;

			if ( !Object.Equals(item1, null) && Object.Equals(item2, null) )
				return false;

			return item1.Equals(item2);
		}

		public static bool operator !=(ColumnFilterItem item1, ColumnFilterItem item2)
		{
			return !(item1 == item2);
		}

		public override string ToString()
		{
			if ( DisplayText == null )
				return String.Empty;

			return DisplayText;
		}

		public object Value
		{
			get { return value; }
		}

		public string DisplayText
		{
			get { return displayText; }
		}

		public bool IsEmpty
		{
			get { return GetItemIsEmpty(); }
		}
	}

	public class ColumnFilterCustomItem : ColumnFilterItem
	{
		public ColumnFilterCustomItem()
			: base("(Custom)", "(Custom)")
		{
		}
	}

	public class ColumnFilterAllItem : ColumnFilterItem
	{
		public ColumnFilterAllItem()
			: base("(All)", "(All)")
		{
		}
	}

	public class ColumnFilterBlanksItem : ColumnFilterItem
	{
		public ColumnFilterBlanksItem()
			: base("(Blanks)", "(Blanks)")
		{
		}
	}

	public class ColumnFilterNonBlanksItem : ColumnFilterItem
	{
		public ColumnFilterNonBlanksItem()
			: base("(Non blanks)", "(Non blanks)")
		{
		}
	}
}
