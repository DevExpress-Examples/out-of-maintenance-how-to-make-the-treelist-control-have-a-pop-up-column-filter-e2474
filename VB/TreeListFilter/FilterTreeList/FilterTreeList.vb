Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Scrolling
Imports DevExpress.XtraTreeList.ViewInfo

Namespace FilterTreeListControl
	Public Class FilterTreeList
		Inherits TreeList
		Private ReadOnly columnFilterEngine As ColumnFilterEngine
		Private ReadOnly _filterPanel As PanelControl
		Private ReadOnly _scrollInfo As ScrollInfo
		Private _filterLabel As LabelControl

		Private ReadOnly _columnFilterConditions As ColumnFilterConditionCollection
		Private ReadOnly _filteredVisibleNodes As New List(Of TreeListNode)()

		Public Sub New()
			columnFilterEngine = CreateColumnFilterEngine()
			_scrollInfo = New ScrollInfo(Me)

			_columnFilterConditions = CreateColumnFilterConditions()
			_filterPanel = CreateFilterPanel()
			_filterPanel.Parent = Me
			_filterPanel.LookAndFeel.Style = Me.LookAndFeel.Style

			AddHandler CustomDrawColumnHeader, AddressOf OnCustomDrawColumnHeader
			AddHandler NodeCellStyle, AddressOf OnNodeCellStyle
			AddHandler MouseMove, AddressOf OnMouseMove
			AddHandler MouseDown, AddressOf OnMouseDown
			AddHandler MouseUp, AddressOf OnMouseUp
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			RemoveHandler CustomDrawColumnHeader, AddressOf OnCustomDrawColumnHeader
			RemoveHandler NodeCellStyle, AddressOf OnNodeCellStyle
			RemoveHandler MouseMove, AddressOf OnMouseMove
			RemoveHandler MouseDown, AddressOf OnMouseDown
			RemoveHandler MouseUp, AddressOf OnMouseUp

			MyBase.Dispose(disposing)
		End Sub

		Protected Overridable Function CreateColumnFilterEngine() As ColumnFilterEngine
			Return New ColumnFilterEngine(Me)
		End Function

		Protected Overridable Function CreateColumnFilterConditions() As ColumnFilterConditionCollection
			Return New ColumnFilterConditionCollection(Me)
		End Function

		Protected Overridable Function CreateFilterPanel() As PanelControl
			Dim panel As New PanelControl()
			_filterLabel = New LabelControl()
			_filterLabel.Parent = panel
			_filterLabel.AutoSizeMode = LabelAutoSizeMode.None

			Return panel
		End Function

		Private Shared Function GetFilterButtonInfoArgs(ByVal colInfo As ColumnInfo) As GridFilterButtonInfoArgs
			If colInfo Is Nothing Then
				Return Nothing
			End If

			Dim elementInfo As DrawElementInfo = colInfo.InnerElements.Find(GetType(GridFilterButtonInfoArgs))
			If elementInfo IsNot Nothing Then
				Return CType(elementInfo.ElementInfo, GridFilterButtonInfoArgs)
			End If

			Return Nothing
		End Function

		Protected Friend Sub SetFilterPanelVisibility(ByVal visible As Boolean)
			If _filterPanel Is Nothing Then
				Return
			End If

			If visible Then
				_filterLabel.Text = _columnFilterConditions.ToString()
			End If

			_filterPanel.Visible = visible
		End Sub

		Private Sub OnCustomDrawColumnHeader(ByVal sender As Object, ByVal e As CustomDrawColumnHeaderEventArgs)
			If e.Column Is Nothing Then
				Return
			End If

			Dim info As ColumnInfo = CType(e.ObjectArgs, ColumnInfo)
			For i As Integer = 0 To info.InnerElements.Count - 1
				If TypeOf info.InnerElements(i).ElementInfo Is GridFilterButtonInfoArgs Then
					Return
				End If
			Next i

			Dim painter As New GridSmartSkinFilterButtonPainter(UserLookAndFeel.Default)
			Dim filterButtonInfo As New GridFilterButtonInfoArgs()
			filterButtonInfo.Cache = e.Cache
			filterButtonInfo.Graphics = e.Graphics

			Dim elementInfo As DrawElementInfo = info.InnerElements.Add(painter, filterButtonInfo)
			elementInfo.RequireTotalBounds = True
			info.InnerElements.CalcBounds(e.ObjectArgs, e.Cache, e.Painter.GetObjectClientRectangle(e.ObjectArgs), e.Bounds)

			Dim captionRect As Rectangle = e.CaptionRect
			captionRect.Width -= elementInfo.ElementInfo.Bounds.Width
			info.CaptionRect = captionRect
		End Sub

		Private Sub OnNodeCellStyle(ByVal sender As Object, ByVal e As GetCustomNodeCellStyleEventArgs)
			If _columnFilterConditions.Count = 0 Then
				Return
			End If

			If _filteredVisibleNodes.Contains(e.Node) AndAlso (Not e.Node.Selected) Then
				e.Appearance.BackColor = Color.LightGray
			End If
		End Sub

		Private Overloads Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			If e.Button <> MouseButtons.None Then
				Return
			End If

			Dim hitInfo As TreeListHitInfo = (CType(sender, TreeList)).CalcHitInfo(e.Location)
			If hitInfo.HitInfoType = HitInfoType.Column Then
				Dim colInfo As ColumnInfo = (CType(sender, TreeList)).ViewInfo.ColumnsInfo(hitInfo.Column)
				Dim filterButtonInfo As GridFilterButtonInfoArgs = GetFilterButtonInfoArgs(colInfo)
				If filterButtonInfo IsNot Nothing Then
					If filterButtonInfo.Bounds.Contains(e.Location) Then
						filterButtonInfo.State = ObjectState.Hot
					ElseIf hitInfo.Column Is columnFilterEngine.FilterShowingColumn Then
						filterButtonInfo.State = ObjectState.Pressed
					Else
						filterButtonInfo.State = ObjectState.Normal
					End If

					CType(sender, TreeList).InvalidateColumnHeader(hitInfo.Column)
				End If
			Else
				For Each col As TreeListColumn In (CType(sender, TreeList)).Columns
					Dim colInfo As ColumnInfo = (CType(sender, TreeList)).ViewInfo.ColumnsInfo(col)
					Dim filterButtonInfo As GridFilterButtonInfoArgs = GetFilterButtonInfoArgs(colInfo)
					If col IsNot columnFilterEngine.FilterShowingColumn AndAlso filterButtonInfo IsNot Nothing Then
						If _columnFilterConditions.ContainsColumn(col) Then
							filterButtonInfo.State = ObjectState.Selected
						Else
							filterButtonInfo.State = ObjectState.Normal
						End If

						CType(sender, TreeList).InvalidateColumnHeader(col)
					End If
				Next col
			End If
		End Sub

		Private Overloads Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			If e.Button <> MouseButtons.Left Then
				Return
			End If

			Dim hitInfo As TreeListHitInfo = (CType(sender, TreeList)).CalcHitInfo(e.Location)
			If hitInfo.HitInfoType = HitInfoType.Column Then
				Dim colInfo As ColumnInfo = (CType(sender, TreeList)).ViewInfo.ColumnsInfo(hitInfo.Column)
				Dim filterButtonInfo As GridFilterButtonInfoArgs = GetFilterButtonInfoArgs(colInfo)
				If filterButtonInfo IsNot Nothing AndAlso filterButtonInfo.Bounds.Contains(e.Location) Then
					filterButtonInfo.State = ObjectState.Pressed
					CType(sender, TreeList).InvalidateColumnHeader(hitInfo.Column)

					Throw New HideException()
				End If
			End If
		End Sub

		Private Overloads Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			If e.Button <> MouseButtons.Left Then
				Return
			End If

			Dim hitInfo As TreeListHitInfo = (CType(sender, TreeList)).CalcHitInfo(e.Location)
			If hitInfo.HitInfoType = HitInfoType.Column Then
				Dim colInfo As ColumnInfo = (CType(sender, TreeList)).ViewInfo.ColumnsInfo(hitInfo.Column)
				Dim filterButtonInfo As GridFilterButtonInfoArgs = GetFilterButtonInfoArgs(colInfo)
				If filterButtonInfo IsNot Nothing AndAlso filterButtonInfo.Bounds.Contains(e.Location) Then
					columnFilterEngine.ProcessFilterButtonClick(hitInfo.Column, filterButtonInfo.Bounds)

					filterButtonInfo.State = ObjectState.Pressed
					CType(sender, TreeList).InvalidateColumnHeader(hitInfo.Column)

					Throw New HideException()
				End If
			End If
		End Sub

		Public Overrides Overloads Sub FilterNodes()
			Me.BeginUpdate()
			Try
				Dim filterNodesOperation As New FilterNodesOperation(_columnFilterConditions)
				Me.NodesIterator.DoLocalOperation(filterNodesOperation, Me.Nodes)
				_filteredVisibleNodes.AddRange(filterNodesOperation.FilteredVisibleNodes)
			Finally
				Me.EndUpdate()
			End Try
		End Sub

		Public ReadOnly Property FilteredVisibleNodes() As List(Of TreeListNode)
			Get
				Return _filteredVisibleNodes
			End Get
		End Property

		Friend ReadOnly Property FilterActive() As Boolean
			Get
				Return _columnFilterConditions.ToString() <> ""
			End Get
		End Property

		Friend ReadOnly Property FilterPanel() As PanelControl
			Get
				Return _filterPanel
			End Get
		End Property

		Friend ReadOnly Property FilterLabel() As LabelControl
			Get
				Return _filterLabel
			End Get
		End Property

		Friend ReadOnly Overloads Property ScrollInfo() As ScrollInfo
			Get
				Return _scrollInfo
			End Get
		End Property

		Friend Shadows ReadOnly Property IsNeededHScrollBar() As Boolean
			Get
				Return MyBase.IsNeededHScrollBar
			End Get
		End Property

		Friend Shadows ReadOnly Property IsNeededVScrollBar() As Boolean
			Get
				Return MyBase.IsNeededVScrollBar
			End Get
		End Property

		Protected Overrides Function CreateViewInfo() As TreeListViewInfo
			Return New FilterTreeListViewInfo(Me)
		End Function

		Public Shadows ReadOnly Property ViewInfo() As TreeListViewInfo
			Get
				Return CType(MyBase.ViewInfo, TreeListViewInfo)
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content), XtraSerializableProperty(XtraSerializationVisibility.Collection, True, False, True, 1001)> _
		Public ReadOnly Property ColumnFilterConditions() As ColumnFilterConditionCollection
			Get
				Return _columnFilterConditions
			End Get
		End Property
		Friend Sub XtraClearColumnFilterConditions(ByVal e As XtraItemEventArgs)
			ColumnFilterConditions.Clear()
		End Sub
		Friend Function XtraCreateColumnFilterConditionsItem(ByVal e As XtraItemEventArgs) As Object
			Dim filterCondition As New ColumnFilterCondition()
			ColumnFilterConditions.Add(filterCondition)
			Return filterCondition
		End Function
	End Class
End Namespace