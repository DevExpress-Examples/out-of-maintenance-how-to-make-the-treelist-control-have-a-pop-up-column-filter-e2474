Imports System

Namespace FilterTreeListControl
	Public Class FilterConditionPropertyChangedEventArgs
		Inherits EventArgs
		Private ReadOnly _changedPropertyName As String = ""

		Public Sub New(ByVal propertyName As String)
			Me._changedPropertyName = propertyName
		End Sub

		Public ReadOnly Property ChangedPropertyName() As String
			Get
				Return _changedPropertyName
			End Get
		End Property
	End Class
End Namespace
