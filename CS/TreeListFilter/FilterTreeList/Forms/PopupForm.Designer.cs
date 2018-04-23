namespace FilterTreeListControl
{
	partial class PopupForm
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
			this.filterItemsList = new DevExpress.XtraEditors.ListBoxControl();
			((System.ComponentModel.ISupportInitialize)(this.filterItemsList)).BeginInit();
			this.SuspendLayout();
			// 
			// filterItemsList
			// 
			this.filterItemsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.filterItemsList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.filterItemsList.HotTrackItems = true;
			this.filterItemsList.Location = new System.Drawing.Point(0, 0);
			this.filterItemsList.Name = "filterItemsList";
			this.filterItemsList.Size = new System.Drawing.Size(80, 149);
			this.filterItemsList.TabIndex = 0;
			this.filterItemsList.SelectedIndexChanged += new System.EventHandler(this.filterItemsList_SelectedIndexChanged);
			// 
			// PopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(80, 151);
			this.ControlBox = false;
			this.Controls.Add(this.filterItemsList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(80, 150);
			this.Name = "PopupForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form2";
			this.Deactivate += new System.EventHandler(this.Form2_Deactivate);
			((System.ComponentModel.ISupportInitialize)(this.filterItemsList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		internal DevExpress.XtraEditors.ListBoxControl filterItemsList;



	}
}