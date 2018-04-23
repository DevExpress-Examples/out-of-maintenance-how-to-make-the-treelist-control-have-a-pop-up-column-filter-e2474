namespace FilterTreeListControl
{
	partial class CustomFilterForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.filterGroupPanel = new DevExpress.XtraEditors.GroupControl();
			this.teValue = new DevExpress.XtraEditors.TextEdit();
			this.cbeFilterConditions = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.sbOK = new DevExpress.XtraEditors.SimpleButton();
			this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.filterGroupPanel)).BeginInit();
			this.filterGroupPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.teValue.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbeFilterConditions.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// filterGroupPanel
			// 
			this.filterGroupPanel.Controls.Add(this.teValue);
			this.filterGroupPanel.Controls.Add(this.cbeFilterConditions);
			this.filterGroupPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.filterGroupPanel.Location = new System.Drawing.Point(0, 19);
			this.filterGroupPanel.Name = "filterGroupPanel";
			this.filterGroupPanel.Size = new System.Drawing.Size(310, 59);
			this.filterGroupPanel.TabIndex = 0;
			this.filterGroupPanel.Text = "Column name";
			// 
			// teValue
			// 
			this.teValue.Location = new System.Drawing.Point(166, 29);
			this.teValue.Name = "teValue";
			this.teValue.Size = new System.Drawing.Size(137, 20);
			this.teValue.TabIndex = 1;
			this.teValue.EditValueChanged += new System.EventHandler(this.teValue_EditValueChanged);
			// 
			// cbeFilterConditions
			// 
			this.cbeFilterConditions.EditValue = "";
			this.cbeFilterConditions.Location = new System.Drawing.Point(5, 29);
			this.cbeFilterConditions.Name = "cbeFilterConditions";
			this.cbeFilterConditions.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbeFilterConditions.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.cbeFilterConditions.Size = new System.Drawing.Size(137, 20);
			this.cbeFilterConditions.TabIndex = 0;
			this.cbeFilterConditions.EditValueChanged += new System.EventHandler(this.cbeFilterConditions_EditValueChanged);
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Options.UseTextOptions = true;
			this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(0, 0);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.labelControl1.Size = new System.Drawing.Size(99, 19);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Show rows where:";
			// 
			// sbOK
			// 
			this.sbOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbOK.Enabled = false;
			this.sbOK.Location = new System.Drawing.Point(147, 81);
			this.sbOK.Name = "sbOK";
			this.sbOK.Size = new System.Drawing.Size(75, 23);
			this.sbOK.TabIndex = 2;
			this.sbOK.Text = "OK";
			// 
			// sbCancel
			// 
			this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbCancel.Location = new System.Drawing.Point(228, 81);
			this.sbCancel.Name = "sbCancel";
			this.sbCancel.Size = new System.Drawing.Size(75, 23);
			this.sbCancel.TabIndex = 3;
			this.sbCancel.Text = "Cancel";
			// 
			// CustomFilterForm
			// 
			this.AcceptButton = this.sbOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.sbCancel;
			this.ClientSize = new System.Drawing.Size(310, 116);
			this.Controls.Add(this.sbCancel);
			this.Controls.Add(this.sbOK);
			this.Controls.Add(this.filterGroupPanel);
			this.Controls.Add(this.labelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CustomFilterForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Custom filter";
			this.Load += new System.EventHandler(this.customFilterForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.filterGroupPanel)).EndInit();
			this.filterGroupPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.teValue.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbeFilterConditions.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SimpleButton sbOK;
		private DevExpress.XtraEditors.SimpleButton sbCancel;
		internal DevExpress.XtraEditors.GroupControl filterGroupPanel;
		internal DevExpress.XtraEditors.TextEdit teValue;
		internal DevExpress.XtraEditors.ComboBoxEdit cbeFilterConditions;
	}
}