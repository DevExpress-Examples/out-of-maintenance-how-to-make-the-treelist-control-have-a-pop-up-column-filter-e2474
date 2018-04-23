Imports System
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes

Namespace FilterTreeListControl
	Public Class ColumnFilterItem
		Private ReadOnly _value As Object
        Private ReadOnly _displayText As String

		Public Sub New(ByVal value As Object, ByVal displayText As String)
			Me._value = value
			Me._displayText = displayText
		End Sub
		Public Sub New(ByVal node As TreeListNode, ByVal col As TreeListColumn)
			_value = node.GetValue(col)
			_displayText = node.GetDisplayText(col)
		End Sub

		Protected Overridable Function GetItemIsEmpty() As Boolean
			Return (_value Is Nothing OrElse _value Is DBNull.Value)
		End Function

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			If Not(TypeOf obj Is ColumnFilterItem) Then
				Return MyBase.Equals(obj)
			End If

			Dim item As ColumnFilterItem = CType(obj, ColumnFilterItem)
			Return Object.Equals(Me.Value, item.Value) AndAlso Me.DisplayText = item.DisplayText
		End Function

		Public Overrides Function GetHashCode() As Integer
			Return MyBase.GetHashCode()
		End Function

		Public Shared Operator =(ByVal item1 As ColumnFilterItem, ByVal item2 As ColumnFilterItem) As Boolean
			If Object.Equals(item1, Nothing) AndAlso Object.Equals(item2, Nothing) Then
				Return True
			End If

			If Object.Equals(item1, Nothing) AndAlso (Not Object.Equals(item2, Nothing)) Then
				Return False
			End If

			If (Not Object.Equals(item1, Nothing)) AndAlso Object.Equals(item2, Nothing) Then
				Return False
			End If

			Return item1.Equals(item2)
		End Operator

		Public Shared Operator <>(ByVal item1 As ColumnFilterItem, ByVal item2 As ColumnFilterItem) As Boolean
			Return Not(item1 = item2)
		End Operator

		Public Overrides Function ToString() As String
			If DisplayText Is Nothing Then
				Return String.Empty
			End If

			Return DisplayText
		End Function

		Public ReadOnly Property Value() As Object
			Get
				Return _value
			End Get
		End Property

		Public ReadOnly Property DisplayText() As String
			Get
				Return _displayText
			End Get
		End Property

		Public ReadOnly Property IsEmpty() As Boolean
			Get
				Return GetItemIsEmpty()
			End Get
		End Property
	End Class

	Public Class ColumnFilterCustomItem
		Inherits ColumnFilterItem
		Public Sub New()
			MyBase.New("(Custom)", "(Custom)")
		End Sub
	End Class

	Public Class ColumnFilterAllItem
		Inherits ColumnFilterItem
		Public Sub New()
			MyBase.New("(All)", "(All)")
		End Sub
	End Class

	Public Class ColumnFilterBlanksItem
		Inherits ColumnFilterItem
		Public Sub New()
			MyBase.New("(Blanks)", "(Blanks)")
		End Sub
	End Class

	Public Class ColumnFilterNonBlanksItem
		Inherits ColumnFilterItem
		Public Sub New()
			MyBase.New("(Non blanks)", "(Non blanks)")
		End Sub
	End Class
End Namespace
