Imports System.Drawing
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo

Namespace FilterTreeListControl
	Public Class FilterTreeListViewInfo
		Inherits TreeListViewInfo
		Private Const filterPanelHeight As Integer = 30

		Public Sub New(ByVal treeList As TreeList)
			MyBase.New(treeList)
		End Sub

		Protected Overridable Sub CalcFilterPanelRect(ByVal clientRect As Rectangle)
			If TreeList.FilterPanel Is Nothing Then
				Return
			End If

			TreeList.FilterPanel.Left = clientRect.Left
			TreeList.FilterPanel.Top = clientRect.Bottom
			If TreeList.IsNeededHScrollBar Then
				TreeList.FilterPanel.Top += TreeList.ScrollInfo.ScrollSize
			End If

			TreeList.FilterPanel.Width = clientRect.Width
			If TreeList.IsNeededVScrollBar Then
				TreeList.FilterPanel.Width += TreeList.ScrollInfo.ScrollSize
			End If

			TreeList.FilterPanel.Height = filterPanelHeight

			TreeList.FilterLabel.Left = TreeList.FilterPanel.Left + 5
			TreeList.FilterLabel.Top = TreeList.FilterPanel.Height \ 2 - TreeList.FilterLabel.Height \ 2
			TreeList.FilterLabel.Width = TreeList.FilterPanel.Width - 5
		End Sub

		Public Overrides Function CalcScrollRect(ByVal windowRect As Rectangle) As Rectangle
			Dim scrollRect As Rectangle = MyBase.CalcScrollRect(windowRect)
			If TreeList.FilterActive Then
				scrollRect.Height -= filterPanelHeight
			End If

			Return scrollRect
		End Function

		Protected Overrides Sub CalcViewRects()
			MyBase.CalcViewRects()
			CalcFilterPanelRect(ViewRects.Client)
		End Sub

		Public Shadows ReadOnly Property TreeList() As FilterTreeList
			Get
				Return CType(MyBase.TreeList, FilterTreeList)
			End Get
		End Property
	End Class
End Namespace
