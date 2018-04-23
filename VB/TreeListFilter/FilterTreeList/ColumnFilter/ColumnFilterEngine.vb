Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns

Namespace FilterTreeListControl
	Public Class ColumnFilterEngine
		Implements IDisposable
		Private _ownerTreeList As FilterTreeList
		Private filterPopupForm As PopupForm
		Private _filterShowingColumn As TreeListColumn

		Public Sub New(ByVal owner As FilterTreeList)
			_ownerTreeList = owner
		End Sub

		Protected Overridable Function CreatePopupForm() As PopupForm
			Return New PopupForm(_ownerTreeList)
		End Function

		Private Sub ShowPopupForm(ByVal filterButtonBounds As Rectangle)
			Dim filterPopupFormBounds As Rectangle = filterPopupForm.CalcPopupRect(filterButtonBounds)
			filterPopupForm.Bounds = filterPopupFormBounds
			filterPopupForm.Show()
		End Sub

		Public Sub ProcessFilterButtonClick(ByVal column As TreeListColumn, ByVal filterButtonBounds As Rectangle)
			_filterShowingColumn = column

			filterPopupForm = CreatePopupForm()
			AddHandler filterPopupForm.FormClosing, AddressOf filterPopupFormOnFormClosing
			PopulateFilterList()
			ShowPopupForm(filterButtonBounds)
		End Sub

		Protected Overridable Function GetFilterValues() As List(Of ColumnFilterItem)
			Dim nodesOperation As New NodesValuesOperation(_filterShowingColumn)
			OwnerTreeList.NodesIterator.DoOperation(nodesOperation)
			Return nodesOperation.Result
		End Function

		Private Shared Sub RemoveColumnDataDuplicates(ByVal columnValuesList As List(Of ColumnFilterItem))
			Dim item As ColumnFilterItem = columnValuesList(0)
			Dim sameIndex As Integer = 0
			Dim sameCount As Integer = 0
			Dim i As Integer = 1

			Do While i < columnValuesList.Count
				If columnValuesList(i) = item Then
					sameCount += 1
					i += 1
				Else
					If sameCount > 0 Then
						columnValuesList.RemoveRange(sameIndex, sameCount)
						i = i - sameCount
						sameCount = 0
						sameIndex = i
						item = columnValuesList(i)
						i += 1
					Else
						sameIndex = i
						item = columnValuesList(i)
						i += 1
					End If
				End If
			Loop

			If sameCount > 0 Then
				columnValuesList.RemoveRange(sameIndex, sameCount)
			End If
		End Sub

		Private Shared Function IsFilterItemValueEmpty(ByVal value As ColumnFilterItem) As Boolean
			Return value.IsEmpty
		End Function

		Protected Sub PopulateFilterList()
			Dim columnValuesList As List(Of ColumnFilterItem) = GetFilterValues()
			If columnValuesList.Count = 0 Then
				Return
			End If

			columnValuesList.Sort(New FilterItemsComparer())
			columnValuesList.Insert(0, New ColumnFilterCustomItem())
			Dim blanksItemIndex As Integer = 1
			If OwnerTreeList.ColumnFilterConditions.ContainsColumn(_filterShowingColumn) Then
				columnValuesList.Insert(0, New ColumnFilterAllItem())
				blanksItemIndex += 1
			End If

			RemoveColumnDataDuplicates(columnValuesList)
			If columnValuesList.RemoveAll(AddressOf IsFilterItemValueEmpty) <> 0 Then
				columnValuesList.Insert(blanksItemIndex, New ColumnFilterBlanksItem())
				columnValuesList.Insert(blanksItemIndex + 1, New ColumnFilterNonBlanksItem())
			End If

			filterPopupForm.filterItemsList.Items.Clear()
			filterPopupForm.filterItemsList.Items.AddRange(columnValuesList.ToArray())
		End Sub

		Private Sub AddSingleFilterCondition(ByVal filterConditionString As String, ByVal filterValue As ColumnFilterItem)
			OwnerTreeList.FilteredVisibleNodes.Clear()

			Dim condition As FilterConditionEnum
			Dim newCondition As ColumnFilterCondition

			If TypeOf filterValue Is ColumnFilterBlanksItem Then
				newCondition = New ColumnFilterCondition(_filterShowingColumn.FieldName, FilterConditionEnum.IsBlank, Nothing, Nothing)
			ElseIf TypeOf filterValue Is ColumnFilterNonBlanksItem Then
				newCondition = New ColumnFilterCondition(_filterShowingColumn.FieldName, FilterConditionEnum.IsNotBlank, Nothing, Nothing)
			Else
				condition = CType(System.Enum.Parse(GetType(FilterConditionEnum), filterConditionString), FilterConditionEnum)
				newCondition = New ColumnFilterCondition(_filterShowingColumn.FieldName, condition, filterValue.Value, filterValue.DisplayText)
			End If

			For i As Integer = 0 To OwnerTreeList.ColumnFilterConditions.Count - 1
				If OwnerTreeList.ColumnFilterConditions(i).Column Is _filterShowingColumn Then
					OwnerTreeList.ColumnFilterConditions.RemoveAt(i)
					Exit For
				End If
			Next i

			If Not(TypeOf filterValue Is ColumnFilterAllItem) Then
				OwnerTreeList.ColumnFilterConditions.Add(newCondition)
			End If
		End Sub

		Protected Overridable Function CreateCustomFilterForm() As CustomFilterForm
			Return New CustomFilterForm()
		End Function

		Protected Overridable Sub PopuplateFilterConditions(ByVal frm As CustomFilterForm)
			frm.filterGroupPanel.Text = _filterShowingColumn.GetCaption()
			For i As Integer = 0 To OwnerTreeList.ColumnFilterConditions.Count - 1
				If OwnerTreeList.ColumnFilterConditions(i).Column Is _filterShowingColumn Then
					frm.cbeFilterConditions.Text = OwnerTreeList.ColumnFilterConditions(i).Condition.ToString()
					frm.teValue.Text = OwnerTreeList.ColumnFilterConditions(i).Value.ToString()
					Exit For
				End If
			Next i
		End Sub

		Protected Overridable Function GetCustomFilterValue(ByVal frm As CustomFilterForm) As ColumnFilterItem
			Dim filterValue As ColumnFilterItem
			Try
				filterValue = New ColumnFilterItem(Convert.ChangeType(frm.teValue.EditValue, _filterShowingColumn.ColumnType), frm.teValue.Text)
			Catch
				filterValue = New ColumnFilterItem(frm.teValue.Text, frm.teValue.Text)
			End Try

			Return filterValue
		End Function

		Private Sub ProcessItemSelection(ByVal sender As Object)
			Dim filterValue As ColumnFilterItem = CType((CType(sender, PopupForm)).SelectedFilterItem, ColumnFilterItem)
			If filterValue Is Nothing Then
				Return
			End If

			If TypeOf filterValue Is ColumnFilterCustomItem AndAlso _filterShowingColumn IsNot Nothing Then
				Dim frm As CustomFilterForm = CreateCustomFilterForm()
				PopuplateFilterConditions(frm)

				If frm.ShowDialog() = DialogResult.OK Then
					filterValue = GetCustomFilterValue(frm)
					AddSingleFilterCondition(frm.cbeFilterConditions.Text, filterValue)
				End If
			ElseIf (Not filterValue.IsEmpty) AndAlso _filterShowingColumn IsNot Nothing Then
				AddSingleFilterCondition("Equals", filterValue)
			End If

			_filterShowingColumn = Nothing
		End Sub

		Private Sub filterPopupFormOnFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			ProcessItemSelection(sender)
		End Sub

		Public Sub Dispose() Implements IDisposable.Dispose
			_ownerTreeList = Nothing
			_filterShowingColumn = Nothing
		End Sub

		Public ReadOnly Property OwnerTreeList() As FilterTreeList
			Get
				Return _ownerTreeList
			End Get
		End Property

		Public ReadOnly Property FilterShowingColumn() As TreeListColumn
			Get
				Return _filterShowingColumn
			End Get
		End Property
	End Class
End Namespace
