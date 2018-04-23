Imports Microsoft.VisualBasic
Imports System
Namespace FilterTreeListControl
	Partial Public Class CustomFilterForm
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
			Me.filterGroupPanel = New DevExpress.XtraEditors.GroupControl()
			Me.teValue = New DevExpress.XtraEditors.TextEdit()
			Me.cbeFilterConditions = New DevExpress.XtraEditors.ComboBoxEdit()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.sbOK = New DevExpress.XtraEditors.SimpleButton()
			Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.filterGroupPanel, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.filterGroupPanel.SuspendLayout()
			CType(Me.teValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cbeFilterConditions.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' filterGroupPanel
			' 
			Me.filterGroupPanel.Controls.Add(Me.teValue)
			Me.filterGroupPanel.Controls.Add(Me.cbeFilterConditions)
			Me.filterGroupPanel.Dock = System.Windows.Forms.DockStyle.Top
			Me.filterGroupPanel.Location = New System.Drawing.Point(0, 19)
			Me.filterGroupPanel.Name = "filterGroupPanel"
			Me.filterGroupPanel.Size = New System.Drawing.Size(310, 59)
			Me.filterGroupPanel.TabIndex = 0
			Me.filterGroupPanel.Text = "Column name"
			' 
			' teValue
			' 
			Me.teValue.Location = New System.Drawing.Point(166, 29)
			Me.teValue.Name = "teValue"
			Me.teValue.Size = New System.Drawing.Size(137, 20)
			Me.teValue.TabIndex = 1
'			Me.teValue.EditValueChanged += New System.EventHandler(Me.teValue_EditValueChanged);
			' 
			' cbeFilterConditions
			' 
			Me.cbeFilterConditions.EditValue = ""
			Me.cbeFilterConditions.Location = New System.Drawing.Point(5, 29)
			Me.cbeFilterConditions.Name = "cbeFilterConditions"
			Me.cbeFilterConditions.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.cbeFilterConditions.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
			Me.cbeFilterConditions.Size = New System.Drawing.Size(137, 20)
			Me.cbeFilterConditions.TabIndex = 0
'			Me.cbeFilterConditions.EditValueChanged += New System.EventHandler(Me.cbeFilterConditions_EditValueChanged);
			' 
			' labelControl1
			' 
			Me.labelControl1.Appearance.Options.UseTextOptions = True
			Me.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
			Me.labelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.labelControl1.Location = New System.Drawing.Point(0, 0)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
			Me.labelControl1.Size = New System.Drawing.Size(99, 19)
			Me.labelControl1.TabIndex = 1
			Me.labelControl1.Text = "Show rows where:"
			' 
			' sbOK
			' 
			Me.sbOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.sbOK.Enabled = False
			Me.sbOK.Location = New System.Drawing.Point(147, 81)
			Me.sbOK.Name = "sbOK"
			Me.sbOK.Size = New System.Drawing.Size(75, 23)
			Me.sbOK.TabIndex = 2
			Me.sbOK.Text = "OK"
			' 
			' sbCancel
			' 
			Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.sbCancel.Location = New System.Drawing.Point(228, 81)
			Me.sbCancel.Name = "sbCancel"
			Me.sbCancel.Size = New System.Drawing.Size(75, 23)
			Me.sbCancel.TabIndex = 3
			Me.sbCancel.Text = "Cancel"
			' 
			' CustomFilterForm
			' 
			Me.AcceptButton = Me.sbOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.sbCancel
			Me.ClientSize = New System.Drawing.Size(310, 116)
			Me.Controls.Add(Me.sbCancel)
			Me.Controls.Add(Me.sbOK)
			Me.Controls.Add(Me.filterGroupPanel)
			Me.Controls.Add(Me.labelControl1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
			Me.Name = "CustomFilterForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Custom filter"
'			Me.Load += New System.EventHandler(Me.customFilterForm_Load);
			CType(Me.filterGroupPanel, System.ComponentModel.ISupportInitialize).EndInit()
			Me.filterGroupPanel.ResumeLayout(False)
			CType(Me.teValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cbeFilterConditions.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private sbOK As DevExpress.XtraEditors.SimpleButton
		Private sbCancel As DevExpress.XtraEditors.SimpleButton
		Friend filterGroupPanel As DevExpress.XtraEditors.GroupControl
		Friend WithEvents teValue As DevExpress.XtraEditors.TextEdit
		Friend WithEvents cbeFilterConditions As DevExpress.XtraEditors.ComboBoxEdit
	End Class
End Namespace