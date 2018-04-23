Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic

Namespace FilterTreeListControl
	Partial Public Class PopupForm
		Inherits XtraForm
		Private Const WM_NCHITTEST As Integer = &H84
		Private Const HT_BOTTOMRIGHT As Integer = &H11

		Private ReadOnly ownerTreeList As FilterTreeList
		Private popupFormClosing As Boolean
		Private _selectedFilterItem As ColumnFilterItem

		Public Sub New(ByVal owner As FilterTreeList)
			InitializeComponent()
			ownerTreeList = owner
		End Sub

		Protected Overrides Sub WndProc(ByRef m As Message)
			If m.Msg = WM_NCHITTEST Then
				Dim pt As Point = Me.PointToClient(New Point(CInt(Fix(m.LParam))))

				If pt.X > Me.Width - 5 AndAlso pt.Y > Me.Height - 5 Then
					m.Result = New IntPtr(HT_BOTTOMRIGHT)
				End If
			Else
				MyBase.WndProc(m)
			End If
		End Sub

		Private Sub Form2_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Deactivate
			If (Not popupFormClosing) Then
				Me.Close()
			End If
		End Sub

		Private Sub filterItemsList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles filterItemsList.SelectedIndexChanged
			_selectedFilterItem = CType(filterItemsList.SelectedItem, ColumnFilterItem)
			popupFormClosing = True
			Me.Close()
		End Sub

		Public Function CalcPopupRect(ByVal filterButtonRect As Rectangle) As Rectangle
			Dim popupRect As New Rectangle()

			Dim maxWidth As Integer = 0
			Dim maxHeight As Integer = 0
			Dim graphics As Graphics = Me.CreateGraphics()
			Dim itemHeight As Integer = CInt(Fix(Math.Round(graphics.MeasureString("0", Me.filterItemsList.Font).Height))) + 3

			For i As Integer = 0 To Me.filterItemsList.ItemCount - 1
				Dim szText As SizeF = graphics.MeasureString(Me.filterItemsList.Items(i).ToString(), Me.filterItemsList.Font)
				Dim itemWidth As Integer = CInt(Fix(Math.Round(szText.Width)))

				If itemWidth > maxWidth Then
					maxWidth = itemWidth
				End If

				If i < 20 Then
					maxHeight += itemHeight
				End If
			Next i
			maxWidth += 10

			If maxWidth > ownerTreeList.Width \ 2 Then
				maxWidth = ownerTreeList.Width \ 2
			End If

			Dim vScroll As New DevExpress.XtraEditors.VScrollBar()
			Dim vScrollWidth As Integer = vScroll.Width
			vScroll.Dispose()

			If itemHeight * Me.filterItemsList.ItemCount > maxHeight Then
				maxWidth += vScrollWidth
			End If

			popupRect.X = filterButtonRect.X
			popupRect.Y = filterButtonRect.Bottom
			popupRect.Location = ownerTreeList.PointToScreen(popupRect.Location)

			popupRect.Width = maxWidth
			popupRect.Height = maxHeight

			Dim screenWorkingArea As Rectangle = Screen.GetWorkingArea(popupRect.Location)
			If popupRect.Right > screenWorkingArea.Right Then
				popupRect.X -= popupRect.Right - screenWorkingArea.Right
			End If

			If popupRect.Bottom > screenWorkingArea.Bottom Then
				popupRect.Y = ownerTreeList.PointToScreen(filterButtonRect.Location).Y - popupRect.Height
			End If

			Return popupRect
		End Function

		Public ReadOnly Property SelectedFilterItem() As Object
			Get
				Return _selectedFilterItem
			End Get
		End Property
	End Class
End Namespace
