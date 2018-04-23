Imports System
Imports DevExpress.XtraEditors

Namespace TreeListFilter
	Partial Public Class XtraForm1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub XtraForm1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Me.DepartmentsTableAdapter.Fill(Me.DepartmentsDataSet.Departments)
            filterTreeList1.ExpandAll()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			filterTreeList1.ColumnFilterConditions.SaveToXml("..\..\filters.xml")
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			filterTreeList1.ColumnFilterConditions.RestoreFromXml("..\..\filters.xml")
		End Sub
	End Class
End Namespace