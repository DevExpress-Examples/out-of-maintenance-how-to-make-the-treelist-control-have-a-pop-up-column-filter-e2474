Imports Microsoft.VisualBasic
Imports System
Namespace TreeListFilter
	Partial Public Class XtraForm1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.filterTreeList1 = New FilterTreeListControl.FilterTreeList
            Me.colIMAGEINDEX = New DevExpress.XtraTreeList.Columns.TreeListColumn
            Me.colDEPARTMENT = New DevExpress.XtraTreeList.Columns.TreeListColumn
            Me.colBUDGET = New DevExpress.XtraTreeList.Columns.TreeListColumn
            Me.colLOCATION = New DevExpress.XtraTreeList.Columns.TreeListColumn
            Me.colPHONE1 = New DevExpress.XtraTreeList.Columns.TreeListColumn
            Me.colPHONE2 = New DevExpress.XtraTreeList.Columns.TreeListColumn
            Me.repositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl
            Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton
            Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton
            Me.DepartmentsDataSet = New DepartmentsDataSet
            Me.DepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DepartmentsTableAdapter = New DepartmentsDataSetTableAdapters.DepartmentsTableAdapter
            CType(Me.filterTreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            CType(Me.DepartmentsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'filterTreeList1
            '
            Me.filterTreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colIMAGEINDEX, Me.colDEPARTMENT, Me.colBUDGET, Me.colLOCATION, Me.colPHONE1, Me.colPHONE2})
            Me.filterTreeList1.DataSource = Me.DepartmentsBindingSource
            Me.filterTreeList1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.filterTreeList1.Location = New System.Drawing.Point(0, 0)
            Me.filterTreeList1.Name = "filterTreeList1"
            Me.filterTreeList1.ParentFieldName = "PARENTID"
            Me.filterTreeList1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemCheckEdit1})
            Me.filterTreeList1.Size = New System.Drawing.Size(595, 355)
            Me.filterTreeList1.TabIndex = 0
            '
            'colIMAGEINDEX
            '
            Me.colIMAGEINDEX.FieldName = "IMAGEINDEX"
            Me.colIMAGEINDEX.Name = "colIMAGEINDEX"
            Me.colIMAGEINDEX.Visible = True
            Me.colIMAGEINDEX.VisibleIndex = 0
            Me.colIMAGEINDEX.Width = 82
            '
            'colDEPARTMENT
            '
            Me.colDEPARTMENT.FieldName = "DEPARTMENT"
            Me.colDEPARTMENT.Name = "colDEPARTMENT"
            Me.colDEPARTMENT.Visible = True
            Me.colDEPARTMENT.VisibleIndex = 1
            Me.colDEPARTMENT.Width = 82
            '
            'colBUDGET
            '
            Me.colBUDGET.FieldName = "BUDGET"
            Me.colBUDGET.Name = "colBUDGET"
            Me.colBUDGET.Visible = True
            Me.colBUDGET.VisibleIndex = 2
            Me.colBUDGET.Width = 82
            '
            'colLOCATION
            '
            Me.colLOCATION.FieldName = "LOCATION"
            Me.colLOCATION.Name = "colLOCATION"
            Me.colLOCATION.Visible = True
            Me.colLOCATION.VisibleIndex = 3
            Me.colLOCATION.Width = 82
            '
            'colPHONE1
            '
            Me.colPHONE1.FieldName = "PHONE1"
            Me.colPHONE1.Name = "colPHONE1"
            Me.colPHONE1.Visible = True
            Me.colPHONE1.VisibleIndex = 4
            Me.colPHONE1.Width = 82
            '
            'colPHONE2
            '
            Me.colPHONE2.FieldName = "PHONE2"
            Me.colPHONE2.Name = "colPHONE2"
            Me.colPHONE2.Visible = True
            Me.colPHONE2.VisibleIndex = 5
            Me.colPHONE2.Width = 82
            '
            'repositoryItemCheckEdit1
            '
            Me.repositoryItemCheckEdit1.AllowGrayed = True
            Me.repositoryItemCheckEdit1.AutoHeight = False
            Me.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1"
            '
            'panelControl1
            '
            Me.panelControl1.Controls.Add(Me.simpleButton2)
            Me.panelControl1.Controls.Add(Me.simpleButton1)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panelControl1.Location = New System.Drawing.Point(0, 355)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(595, 49)
            Me.panelControl1.TabIndex = 1
            '
            'simpleButton2
            '
            Me.simpleButton2.Location = New System.Drawing.Point(160, 13)
            Me.simpleButton2.Name = "simpleButton2"
            Me.simpleButton2.Size = New System.Drawing.Size(142, 23)
            Me.simpleButton2.TabIndex = 1
            Me.simpleButton2.Text = "Restore filter from XML"
            '
            'simpleButton1
            '
            Me.simpleButton1.Location = New System.Drawing.Point(12, 13)
            Me.simpleButton1.Name = "simpleButton1"
            Me.simpleButton1.Size = New System.Drawing.Size(142, 23)
            Me.simpleButton1.TabIndex = 0
            Me.simpleButton1.Text = "Save filter to XML"
            '
            'DepartmentsDataSet
            '
            Me.DepartmentsDataSet.DataSetName = "DepartmentsDataSet"
            Me.DepartmentsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'DepartmentsBindingSource
            '
            Me.DepartmentsBindingSource.DataMember = "Departments"
            Me.DepartmentsBindingSource.DataSource = Me.DepartmentsDataSet
            '
            'DepartmentsTableAdapter
            '
            Me.DepartmentsTableAdapter.ClearBeforeFill = True
            '
            'XtraForm1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(595, 404)
            Me.Controls.Add(Me.filterTreeList1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "XtraForm1"
            Me.Text = "XtraForm1"
            CType(Me.filterTreeList1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            CType(Me.DepartmentsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

		#End Region

		Private filterTreeList1 As FilterTreeListControl.FilterTreeList
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private repositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Private colIMAGEINDEX As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private colDEPARTMENT As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private colBUDGET As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private colLOCATION As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private colPHONE1 As DevExpress.XtraTreeList.Columns.TreeListColumn
        Private colPHONE2 As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents DepartmentsDataSet As DepartmentsDataSet
        Friend WithEvents DepartmentsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DepartmentsTableAdapter As DepartmentsDataSetTableAdapters.DepartmentsTableAdapter
	End Class
End Namespace