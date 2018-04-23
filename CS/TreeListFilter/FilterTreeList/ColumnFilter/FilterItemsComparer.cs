using System;
using System.Collections;
using System.Collections.Generic;

namespace FilterTreeListControl
{
	public class FilterItemsComparer : IComparer<ColumnFilterItem>
	{
		public int Compare(ColumnFilterItem x, ColumnFilterItem y)
		{
			if ( (x.Value == null || x.Value == DBNull.Value) && (y.Value == null || y.Value == DBNull.Value) )
				return 0;

			if ( (x.Value == null || x.Value == DBNull.Value) && (y.Value != null && y.Value != DBNull.Value) )
				return -1;

			if ( (x.Value != null && x.Value != DBNull.Value) && (y.Value == null || y.Value == DBNull.Value) )
				return 1;

			return Comparer.Default.Compare(x.Value, y.Value);
		}
	}
}
