Imports System
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList

Namespace FilterTreeListControl
	Partial Public Class CustomFilterForm
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub RemoveConditionFromList(ByVal condition As FilterConditionEnum)
			Dim index As Integer = cbeFilterConditions.Properties.Items.IndexOf(System.Enum.GetName(GetType(FilterConditionEnum), condition))
			If index <> -1 Then
				cbeFilterConditions.Properties.Items.RemoveAt(index)
			End If
		End Sub

		Private Sub customFilterForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			cbeFilterConditions.Properties.Items.AddRange(System.Enum.GetNames(GetType(FilterConditionEnum)))
			RemoveConditionFromList(FilterConditionEnum.Between)
			RemoveConditionFromList(FilterConditionEnum.NotBetween)
			RemoveConditionFromList(FilterConditionEnum.None)
		End Sub

		Private Sub cbeFilterConditions_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbeFilterConditions.EditValueChanged
			sbOK.Enabled = (CType(sender, ComboBoxEdit)).Text <> "" AndAlso teValue.Text <> ""
		End Sub

		Private Sub teValue_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles teValue.EditValueChanged
			sbOK.Enabled = (CType(sender, TextEdit)).Text <> "" AndAlso cbeFilterConditions.Text <> ""
		End Sub
	End Class
End Namespace