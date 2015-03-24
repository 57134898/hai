namespace hai
{
    partial class ReportViewForm
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.v_rebateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.haiDataSet = new hai.haiDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.reportListCBB = new System.Windows.Forms.ToolStripComboBox();
            this.doSelectBTN = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.v_rebateTableAdapter = new hai.haiDataSetTableAdapters.v_rebateTableAdapter();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.v_rebateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.haiDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // v_rebateBindingSource
            // 
            this.v_rebateBindingSource.DataMember = "v_rebate";
            this.v_rebateBindingSource.DataSource = this.haiDataSet;
            // 
            // haiDataSet
            // 
            this.haiDataSet.DataSetName = "haiDataSet";
            this.haiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.reportListCBB,
            this.doSelectBTN});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "报表";
            // 
            // reportListCBB
            // 
            this.reportListCBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportListCBB.Items.AddRange(new object[] {
            "佣金表"});
            this.reportListCBB.Name = "reportListCBB";
            this.reportListCBB.Size = new System.Drawing.Size(200, 25);
            // 
            // doSelectBTN
            // 
            this.doSelectBTN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.doSelectBTN.Image = ((System.Drawing.Image)(resources.GetObject("doSelectBTN.Image")));
            this.doSelectBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.doSelectBTN.Name = "doSelectBTN";
            this.doSelectBTN.Size = new System.Drawing.Size(52, 22);
            this.doSelectBTN.Text = "查询";
            this.doSelectBTN.Click += new System.EventHandler(this.doSelectBTN_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "v_r";
            reportDataSource2.Value = this.v_rebateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hai.佣金表.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(773, 411);
            this.reportViewer1.TabIndex = 1;
            // 
            // v_rebateTableAdapter
            // 
            this.v_rebateTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(275, 1);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(401, 1);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(111, 21);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // ReportViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 436);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报表浏览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportViewForm_FormClosed);
            this.Load += new System.EventHandler(this.ReportViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.v_rebateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.haiDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox reportListCBB;
        private System.Windows.Forms.ToolStripButton doSelectBTN;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource v_rebateBindingSource;
        private haiDataSet haiDataSet;
        private haiDataSetTableAdapters.v_rebateTableAdapter v_rebateTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}