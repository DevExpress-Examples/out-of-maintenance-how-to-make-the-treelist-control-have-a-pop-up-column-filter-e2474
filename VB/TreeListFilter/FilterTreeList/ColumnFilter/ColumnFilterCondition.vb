Imports System.ComponentModel
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns

Namespace FilterTreeListControl
	Public Delegate Sub FilterConditionPropertyChangedEventHandler(ByVal sender As Object, ByVal e As FilterConditionPropertyChangedEventArgs)

	Public Class ColumnFilterCondition
		Private _fieldName As String
		Private _condition As FilterConditionEnum
		Private _value As Object
		Private _displayText As String
		Private storageCollection As ColumnFilterConditionCollection

		Public Sub New()
		End Sub
		Public Sub New(ByVal fieldName As String, ByVal condition As FilterConditionEnum, ByVal value As Object, ByVal displayText As String)
			Me._fieldName = fieldName
			Me._condition = condition
			Me._value = value
			Me._displayText = displayText
		End Sub

		Public Function CheckValue(ByVal valueToCheck As Object) As Boolean
			If Collection Is Nothing OrElse Column Is Nothing Then
				Return False
			End If

            Dim innerCondition As New FilterCondition(Condition, Column, Value)
			Return innerCondition.CheckValue(valueToCheck)
		End Function

		Public Sub Assign(ByVal source As ColumnFilterCondition)
			Collection = source.Collection
			FieldName = source.FieldName
			Condition = source.Condition
			Value = source.Value
			DisplayText = source.DisplayText
		End Sub

		Protected Function FindTreeListColumn() As TreeListColumn
			If Collection Is Nothing Then
				Return Nothing
			End If

			Return Collection.OwnerTreeList.Columns(FieldName)
		End Function


		Protected Sub RaisePropertyChangedEvent(ByVal propertyName As String)
			Dim args As New FilterConditionPropertyChangedEventArgs(propertyName)
			RaiseEvent FilterConditionPropertyChanged(Me, args)
		End Sub

		Public Overrides Function ToString() As String
			If String.IsNullOrEmpty(FieldName) OrElse Condition = FilterConditionEnum.None OrElse Collection Is Nothing Then
				Return ""
			End If

			If (Condition = FilterConditionEnum.IsBlank OrElse Condition = FilterConditionEnum.IsNotBlank) Then
				Return String.Format("[{0}] {1}", Column.GetCaption(), Condition)
			End If

			Dim condValue As Object = Nothing
			If Value IsNot Nothing Then
				If Value.GetType() Is GetType(String) Then
					condValue = String.Format("'{0}'", DisplayText)
				Else
					condValue = DisplayText
				End If
			End If

			If condValue Is Nothing Then
				Return ""
			End If

			Return String.Format("[{0}] {1} {2}", Column.GetCaption(), Condition, condValue)
		End Function

		<XtraSerializableProperty(XtraSerializationVisibility.Visible)> _
		Public Property FieldName() As String
			Get
				Return _fieldName
			End Get
			Set(ByVal value As String)
				If _fieldName Is value Then
					Return
				End If

				_fieldName = value
				RaisePropertyChangedEvent("FieldName")
			End Set
		End Property


		<XtraSerializableProperty(XtraSerializationVisibility.Visible)> _
		Public Property Condition() As FilterConditionEnum
			Get
				Return _condition
			End Get
			Set(ByVal value As FilterConditionEnum)
                If _condition = value Then
                    Return
                End If

				_condition = value
				RaisePropertyChangedEvent("Condition")
			End Set
		End Property


		<XtraSerializableProperty(XtraSerializationVisibility.Visible)> _
		Public Property Value() As Object
			Get
				Return _value
			End Get
			Set(ByVal value As Object)
				If Me._value Is value Then
					Return
				End If

				Me._value = value
				RaisePropertyChangedEvent("Value")
			End Set
		End Property

		<XtraSerializableProperty(XtraSerializationVisibility.Visible)> _
		Public Property DisplayText() As String
			Get
				Return _displayText
			End Get
			Set(ByVal value As String)
				If _displayText Is value Then
					Return
				End If

				_displayText = value
				RaisePropertyChangedEvent("DisplayText")
			End Set
		End Property

		<Browsable(False)> _
		Public Property Collection() As ColumnFilterConditionCollection
			Get
				Return storageCollection
			End Get
			Set(ByVal value As ColumnFilterConditionCollection)
				storageCollection = value
			End Set
		End Property

		<Browsable(False)> _
		Public ReadOnly Property Column() As TreeListColumn
			Get
				Return FindTreeListColumn()
			End Get
		End Property

		Public Event FilterConditionPropertyChanged As FilterConditionPropertyChangedEventHandler
	End Class
End Namespace