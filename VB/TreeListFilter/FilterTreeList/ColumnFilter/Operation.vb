Imports System.Collections.Generic
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Nodes.Operations

Namespace FilterTreeListControl
	Public Class NodesValuesOperation
		Inherits TreeListOperation
		Private ReadOnly column As TreeListColumn
		Private ReadOnly resultList As New List(Of ColumnFilterItem)()

		Public Sub New(ByVal column As TreeListColumn)
			Me.column = column
		End Sub

		Public Overrides Sub Execute(ByVal node As TreeListNode)
			resultList.Add(New ColumnFilterItem(node, column))
		End Sub

		Public ReadOnly Property Result() As List(Of ColumnFilterItem)
			Get
				Return resultList
			End Get
		End Property
	End Class

	Public Class FilterNodesOperation
		Inherits TreeListOperation
		Private ReadOnly filterConditions As ColumnFilterConditionCollection
		Private ReadOnly _filteredVisibleNodes As New List(Of TreeListNode)()

		Public Sub New(ByVal filterConditions As ColumnFilterConditionCollection)
			Me.filterConditions = filterConditions
		End Sub

		Private Function IsNodeFiltered(ByVal node As TreeListNode) As Boolean
			Dim metConditions As Integer = 0
			For Each condition As ColumnFilterCondition In filterConditions
				Dim value As Object = node.GetValue(condition.Column)
				If condition.CheckValue(value) Then
					metConditions += 1
				End If
			Next condition

			If metConditions = filterConditions.Count Then
				Return False
			End If

			Return True
		End Function

		Public Overrides Sub Execute(ByVal node As TreeListNode)
			Dim visibleChildNodesResult As Boolean = False
			If node.Nodes.Count <> 0 Then
				Dim childNodesOperation As New FilterNodesOperation(filterConditions)
				node.TreeList.NodesIterator.DoLocalOperation(childNodesOperation, node.Nodes)
				visibleChildNodesResult = childNodesOperation.HasVisibleChildNodes
				_filteredVisibleNodes.AddRange(childNodesOperation.FilteredVisibleNodes)
			End If

			Dim nodeFiltered As Boolean = IsNodeFiltered(node)
			If (Not nodeFiltered) OrElse visibleChildNodesResult Then
				_hasVisibleChildNodes = True
			End If

			If nodeFiltered AndAlso visibleChildNodesResult Then
				_filteredVisibleNodes.Add(node)
			End If

			node.Visible = (Not nodeFiltered) OrElse visibleChildNodesResult
		End Sub

		Public Overrides Function NeedsVisitChildren(ByVal node As TreeListNode) As Boolean
			Return False
		End Function

		Private _hasVisibleChildNodes As Boolean
		Public ReadOnly Property HasVisibleChildNodes() As Boolean
			Get
				Return _hasVisibleChildNodes
			End Get
		End Property

		Public ReadOnly Property FilteredVisibleNodes() As List(Of TreeListNode)
			Get
				Return _filteredVisibleNodes
			End Get
		End Property
	End Class
End Namespace
