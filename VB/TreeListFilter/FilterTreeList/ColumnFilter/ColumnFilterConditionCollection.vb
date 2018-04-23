Imports System.Collections
Imports System.IO
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraTreeList.Columns

Namespace FilterTreeListControl
    Public Class ColumnFilterConditionCollection
        Inherits CollectionBase
        Private _ownerTreeList As FilterTreeList

        Public Sub New(ByVal treeList As FilterTreeList)
            OwnerTreeList = treeList
        End Sub
        Public Sub New(ByVal treeList As FilterTreeList, ByVal capacity As Integer)
            MyBase.New(capacity)
            OwnerTreeList = treeList
        End Sub

        Public Sub Assign(ByVal source As ColumnFilterConditionCollection)
            Clear()
            For Each condition As ColumnFilterCondition In source
                Dim newCondition As New ColumnFilterCondition()
                newCondition.Assign(condition)
                Add(newCondition)
            Next condition
        End Sub

        Public Function Add(ByVal item As ColumnFilterCondition) As Integer
            item.Collection = Me
            AddHandler item.FilterConditionPropertyChanged, AddressOf OnItemPropertyChanged
            Return List.Add(item)
        End Function

        Public Function IndexOf(ByVal item As ColumnFilterCondition) As Integer
            Return List.IndexOf(item)
        End Function

        Public Function Contains(ByVal item As ColumnFilterCondition) As Boolean
            Return List.Contains(item)
        End Function

        Public Function ContainsColumn(ByVal col As TreeListColumn) As Boolean
            For i As Integer = 0 To Count - 1
                If Me(i).Column Is col Then
                    Return True
                End If
            Next i

            Return False
        End Function

        Public Overrides Function ToString() As String
            Dim filterText As String = ""

            For Each condition As ColumnFilterCondition In Me
                Dim andString As String
                If condition IsNot Last Then
                    andString = " AND "
                Else
                    andString = ""
                End If

                filterText &= condition.ToString() & andString
            Next condition

            Return filterText
        End Function

        Protected Overridable Sub SerializeCore(ByVal serializer As XtraSerializer, ByVal path As Object)
            Dim filterSerializationHelper As New FilterSerializationHelper(Me)
            Dim stream As Stream = TryCast(path, Stream)

            If stream IsNot Nothing Then
                serializer.SerializeObject(filterSerializationHelper, stream, Me.GetType().Name)
            Else
                serializer.SerializeObject(filterSerializationHelper, path.ToString(), Me.GetType().Name)
            End If
        End Sub

        Public Overridable Sub SaveToXml(ByVal xmlFile As String)
            SerializeCore(New XmlXtraSerializer(), xmlFile)
        End Sub
        Public Overridable Sub SaveToRegistry(ByVal path As String)
            SerializeCore(New RegistryXtraSerializer(), path)
        End Sub
        Public Overridable Sub SaveToStream(ByVal stream As Stream)
            SerializeCore(New XmlXtraSerializer(), stream)
        End Sub

        Protected Overridable Sub DeserializeCore(ByVal serializer As XtraSerializer, ByVal path As Object)
            Dim filterSerializationHelper As New FilterSerializationHelper(Me)
            Dim stream As Stream = TryCast(path, Stream)

            If stream IsNot Nothing Then
                serializer.DeserializeObject(filterSerializationHelper, stream, Me.GetType().Name)
            Else
                serializer.DeserializeObject(filterSerializationHelper, path.ToString(), Me.GetType().Name)
            End If
        End Sub

        Public Overridable Sub RestoreFromXml(ByVal xmlFile As String)
            DeserializeCore(New XmlXtraSerializer(), xmlFile)
        End Sub
        Public Overridable Sub RestoreFromRegistry(ByVal path As String)
            DeserializeCore(New RegistryXtraSerializer(), path)
        End Sub
        Public Overridable Sub RestoreFromStream(ByVal stream As Stream)
            DeserializeCore(New XmlXtraSerializer(), stream)
        End Sub

        Protected Sub OnItemPropertyChanged(ByVal sender As Object, ByVal e As FilterConditionPropertyChangedEventArgs)
            If ToString() <> "" Then
                OwnerTreeList.FilterNodes()
                OwnerTreeList.SetFilterPanelVisibility(True)
            End If
        End Sub

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnInsertComplete(index, value)

            If ToString() <> "" Then
                OwnerTreeList.FilterNodes()
                OwnerTreeList.SetFilterPanelVisibility(True)
            End If
        End Sub

        Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnRemoveComplete(index, value)

            OwnerTreeList.FilterNodes()
            OwnerTreeList.SetFilterPanelVisibility(ToString() <> "")
        End Sub

        Protected Overrides Sub OnClearComplete()
            MyBase.OnClearComplete()

            OwnerTreeList.FilterNodes()
            OwnerTreeList.SetFilterPanelVisibility(ToString() <> "")
        End Sub

        Default Public Property Item(ByVal index As Integer) As ColumnFilterCondition
            Get
                Return TryCast(List(index), ColumnFilterCondition)
            End Get
            Set(ByVal value As ColumnFilterCondition)
                List(index) = value
            End Set
        End Property

        Public ReadOnly Property Last() As ColumnFilterCondition
            Get
                Return TryCast(List(Count - 1), ColumnFilterCondition)
            End Get
        End Property

        Public Property OwnerTreeList() As FilterTreeList
            Get
                Return _ownerTreeList
            End Get
            Set(ByVal value As FilterTreeList)
                _ownerTreeList = value
            End Set
        End Property
    End Class
End Namespace