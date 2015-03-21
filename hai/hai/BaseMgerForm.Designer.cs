namespace hai
{
    partial class BaseMgerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseMgerForm));
            this.savbutton = new System.Windows.Forms.Button();
            this.canbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // savbutton
            // 
            this.savbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savbutton.Location = new System.Drawing.Point(616, 427);
            this.savbutton.Name = "savbutton";
            this.savbutton.Size = new System.Drawing.Size(75, 23);
            this.savbutton.TabIndex = 0;
            this.savbutton.Text = "保存";
            this.savbutton.UseVisualStyleBackColor = true;
            this.savbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // canbutton
            // 
            this.canbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.canbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canbutton.Location = new System.Drawing.Point(697, 427);
            this.canbutton.Name = "canbutton";
            this.canbutton.Size = new System.Drawing.Size(75, 23);
            this.canbutton.TabIndex = 1;
            this.canbutton.Text = "关闭";
            this.canbutton.UseVisualStyleBackColor = true;
            this.canbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(15, 415);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 5);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BaseMgerForm
            // 
            this.AcceptButton = this.savbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.canbutton;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canbutton);
            this.Controls.Add(this.savbutton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseMgerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BaseFormMger";
            this.Load += new System.EventHandler(this.BaseMgerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button savbutton;
        protected System.Windows.Forms.Button canbutton;
        protected System.Windows.Forms.GroupBox groupBox1;

    }
}