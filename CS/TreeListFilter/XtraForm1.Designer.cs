namespace TreeListFilter
{
	partial class XtraForm1
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
			this.components = new System.ComponentModel.Container();
			this.filterTreeList1 = new FilterTreeListControl.FilterTreeList();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.departmentsDataSet = new TreeListFilter.DepartmentsDataSet();
			this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.departmentsTableAdapter = new TreeListFilter.DepartmentsDataSetTableAdapters.DepartmentsTableAdapter();
			this.colIMAGEINDEX = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colDEPARTMENT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colBUDGET = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colLOCATION = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colPHONE1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colPHONE2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			((System.ComponentModel.ISupportInitialize)(this.filterTreeList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.departmentsDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// filterTreeList1
			// 
			this.filterTreeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colIMAGEINDEX,
            this.colDEPARTMENT,
            this.colBUDGET,
            this.colLOCATION,
            this.colPHONE1,
            this.colPHONE2});
			this.filterTreeList1.DataSource = this.departmentsBindingSource;
			this.filterTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filterTreeList1.Location = new System.Drawing.Point(0, 0);
			this.filterTreeList1.Name = "filterTreeList1";
			this.filterTreeList1.ParentFieldName = "PARENTID";
			this.filterTreeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
			this.filterTreeList1.Size = new System.Drawing.Size(595, 355);
			this.filterTreeList1.TabIndex = 0;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AllowGrayed = true;
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton2);
			this.panelControl1.Controls.Add(this.simpleButton1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point(0, 355);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(595, 49);
			this.panelControl1.TabIndex = 1;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Location = new System.Drawing.Point(160, 13);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(142, 23);
			this.simpleButton2.TabIndex = 1;
			this.simpleButton2.Text = "Restore filter from XML";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(12, 13);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(142, 23);
			this.simpleButton1.TabIndex = 0;
			this.simpleButton1.Text = "Save filter to XML";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// departmentsDataSet
			// 
			this.departmentsDataSet.DataSetName = "DepartmentsDataSet";
			this.departmentsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// departmentsBindingSource
			// 
			this.departmentsBindingSource.DataMember = "Departments";
			this.departmentsBindingSource.DataSource = this.departmentsDataSet;
			// 
			// departmentsTableAdapter
			// 
			this.departmentsTableAdapter.ClearBeforeFill = true;
			// 
			// colIMAGEINDEX
			// 
			this.colIMAGEINDEX.FieldName = "IMAGEINDEX";
			this.colIMAGEINDEX.Name = "colIMAGEINDEX";
			this.colIMAGEINDEX.Visible = true;
			this.colIMAGEINDEX.VisibleIndex = 0;
			this.colIMAGEINDEX.Width = 82;
			// 
			// colDEPARTMENT
			// 
			this.colDEPARTMENT.FieldName = "DEPARTMENT";
			this.colDEPARTMENT.Name = "colDEPARTMENT";
			this.colDEPARTMENT.Visible = true;
			this.colDEPARTMENT.VisibleIndex = 1;
			this.colDEPARTMENT.Width = 82;
			// 
			// colBUDGET
			// 
			this.colBUDGET.FieldName = "BUDGET";
			this.colBUDGET.Name = "colBUDGET";
			this.colBUDGET.Visible = true;
			this.colBUDGET.VisibleIndex = 2;
			this.colBUDGET.Width = 82;
			// 
			// colLOCATION
			// 
			this.colLOCATION.FieldName = "LOCATION";
			this.colLOCATION.Name = "colLOCATION";
			this.colLOCATION.Visible = true;
			this.colLOCATION.VisibleIndex = 3;
			this.colLOCATION.Width = 82;
			// 
			// colPHONE1
			// 
			this.colPHONE1.FieldName = "PHONE1";
			this.colPHONE1.Name = "colPHONE1";
			this.colPHONE1.Visible = true;
			this.colPHONE1.VisibleIndex = 4;
			this.colPHONE1.Width = 82;
			// 
			// colPHONE2
			// 
			this.colPHONE2.FieldName = "PHONE2";
			this.colPHONE2.Name = "colPHONE2";
			this.colPHONE2.Visible = true;
			this.colPHONE2.VisibleIndex = 5;
			this.colPHONE2.Width = 82;
			// 
			// XtraForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(595, 404);
			this.Controls.Add(this.filterTreeList1);
			this.Controls.Add(this.panelControl1);
			this.Name = "XtraForm1";
			this.Text = "XtraForm1";
			this.Load += new System.EventHandler(this.XtraForm1_Load);
			((System.ComponentModel.ISupportInitialize)(this.filterTreeList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.departmentsDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private FilterTreeListControl.FilterTreeList filterTreeList1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DepartmentsDataSet departmentsDataSet;
		private System.Windows.Forms.BindingSource departmentsBindingSource;
		private TreeListFilter.DepartmentsDataSetTableAdapters.DepartmentsTableAdapter departmentsTableAdapter;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colIMAGEINDEX;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colDEPARTMENT;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colBUDGET;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colLOCATION;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colPHONE1;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colPHONE2;
	}
}