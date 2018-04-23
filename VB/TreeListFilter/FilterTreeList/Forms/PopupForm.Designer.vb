Imports Microsoft.VisualBasic
Imports System
Namespace FilterTreeListControl
	Partial Public Class PopupForm
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
			Me.filterItemsList = New DevExpress.XtraEditors.ListBoxControl()
			CType(Me.filterItemsList, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' filterItemsList
			' 
			Me.filterItemsList.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.filterItemsList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
			Me.filterItemsList.HotTrackItems = True
			Me.filterItemsList.Location = New System.Drawing.Point(0, 0)
			Me.filterItemsList.Name = "filterItemsList"
			Me.filterItemsList.Size = New System.Drawing.Size(80, 149)
			Me.filterItemsList.TabIndex = 0
'			Me.filterItemsList.SelectedIndexChanged += New System.EventHandler(Me.filterItemsList_SelectedIndexChanged);
			' 
			' PopupForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(80, 151)
			Me.ControlBox = False
			Me.Controls.Add(Me.filterItemsList)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(80, 150)
			Me.Name = "PopupForm"
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
			Me.Text = "Form2"
'			Me.Deactivate += New System.EventHandler(Me.Form2_Deactivate);
			CType(Me.filterItemsList, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Friend WithEvents filterItemsList As DevExpress.XtraEditors.ListBoxControl



	End Class
End Namespace