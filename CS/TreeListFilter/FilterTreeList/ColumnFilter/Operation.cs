using System.Collections.Generic;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace FilterTreeListControl
{
	public class NodesValuesOperation : TreeListOperation
	{
		private readonly TreeListColumn column;
		private readonly List<ColumnFilterItem> result = new List<ColumnFilterItem>();

		public NodesValuesOperation(TreeListColumn column)
		{
			this.column = column;
		}

		public override void Execute(TreeListNode node)
		{
			result.Add(new ColumnFilterItem(node, column));
		}

		public List<ColumnFilterItem> Result
		{
			get { return result; }
		}
	}

	public class FilterNodesOperation : TreeListOperation
	{
		private readonly ColumnFilterConditionCollection filterConditions;
		private readonly List<TreeListNode> filteredVisibleNodes = new List<TreeListNode>();

		public FilterNodesOperation(ColumnFilterConditionCollection filterConditions)
		{
			this.filterConditions = filterConditions;
		}

		private bool IsNodeFiltered(TreeListNode node)
		{
			int metConditions = 0;
			foreach ( ColumnFilterCondition condition in filterConditions )
			{
				object value = node.GetValue(condition.Column);
				if ( condition.CheckValue(value) )
					metConditions++;
			}

			if ( metConditions == filterConditions.Count )
				return false;

			return true;
		}

		public override void Execute(TreeListNode node)
		{
			bool visibleChildNodesResult = false;
			if ( node.Nodes.Count != 0 )
			{
				FilterNodesOperation childNodesOperation = new FilterNodesOperation(filterConditions);
				node.TreeList.NodesIterator.DoLocalOperation(childNodesOperation, node.Nodes);
				visibleChildNodesResult = childNodesOperation.HasVisibleChildNodes;
				filteredVisibleNodes.AddRange(childNodesOperation.FilteredVisibleNodes);
			}

			bool nodeFiltered = IsNodeFiltered(node);
			if ( !nodeFiltered || visibleChildNodesResult )
				hasVisibleChildNodes = true;

			if ( nodeFiltered && visibleChildNodesResult )
				filteredVisibleNodes.Add(node);

			node.Visible = !nodeFiltered || visibleChildNodesResult;
		}

		public override bool NeedsVisitChildren(TreeListNode node)
		{
			return false;
		}

		private bool hasVisibleChildNodes;
		public bool HasVisibleChildNodes
		{
			get { return hasVisibleChildNodes; }
		}
		
		public List<TreeListNode> FilteredVisibleNodes
		{
			get { return filteredVisibleNodes; }
		}
	}
}
