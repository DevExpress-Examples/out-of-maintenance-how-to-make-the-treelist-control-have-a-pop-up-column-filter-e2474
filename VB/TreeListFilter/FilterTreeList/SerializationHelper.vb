Imports DevExpress.Utils.Serializing

Namespace FilterTreeListControl
	Friend Class FilterSerializationHelper
		Private ReadOnly filterCollection As ColumnFilterConditionCollection

		Public Sub New(ByVal collection As ColumnFilterConditionCollection)
			filterCollection = collection
		End Sub

		<XtraSerializableProperty(XtraSerializationVisibility.Collection, True, False, True, 1001)> _
		Public ReadOnly Property FilterConditions() As ColumnFilterConditionCollection
			Get
				Return filterCollection
			End Get
		End Property

		Private Function XtraShouldSerializeFilterConditions() As Boolean
			Return True
		End Function
		Friend Sub XtraClearFilterConditions(ByVal e As XtraItemEventArgs)
			filterCollection.Clear()
		End Sub
		Friend Function XtraCreateFilterConditionsItem(ByVal e As XtraItemEventArgs) As Object
			Dim filterCondition As New ColumnFilterCondition()
			filterCollection.Add(filterCondition)
			Return filterCondition
		End Function
	End Class
End Namespace
