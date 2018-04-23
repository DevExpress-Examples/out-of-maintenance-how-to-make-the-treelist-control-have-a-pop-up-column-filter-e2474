Imports System
Imports System.Collections
Imports System.Collections.Generic

Namespace FilterTreeListControl
	Public Class FilterItemsComparer
		Implements IComparer(Of ColumnFilterItem)
		Public Function Compare(ByVal x As ColumnFilterItem, ByVal y As ColumnFilterItem) As Integer Implements IComparer(Of ColumnFilterItem).Compare
			If (x.Value Is Nothing OrElse x.Value Is DBNull.Value) AndAlso (y.Value Is Nothing OrElse y.Value Is DBNull.Value) Then
				Return 0
			End If

			If (x.Value Is Nothing OrElse x.Value Is DBNull.Value) AndAlso (y.Value IsNot Nothing AndAlso y.Value IsNot DBNull.Value) Then
				Return -1
			End If

			If (x.Value IsNot Nothing AndAlso x.Value IsNot DBNull.Value) AndAlso (y.Value Is Nothing OrElse y.Value Is DBNull.Value) Then
				Return 1
			End If

			Return Comparer.Default.Compare(x.Value, y.Value)
		End Function
	End Class
End Namespace
