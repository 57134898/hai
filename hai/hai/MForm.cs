using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hai
{
    public partial class MForm : Form
    {
        #region sys
        private int childFormNumber = 0;

        public MForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count <= 0)
                return;
            if (this.tabControl1.SelectedTab == null)
                return;
            if (this.tabControl1.SelectedTab.Controls.Count <= 0)
                return;
            Control c = this.tabControl1.SelectedTab.Controls[0];
            if (c is IOrder)
            {
                (c as IOrder).DoAdd();
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MForm_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Nodes.Count > 0)
                return;
            Form form = null;
            form = DoFromSwitch(form);
            if (form == null)
                return;
            form.MdiParent = this;
            //this.tabControl1.Appearance = TabAppearance.FlatButtons;
            TabPage tp = new TabPage();
            tp.Size = new Size(50, 25);
            tp.Text = form.Text;
            tp.Padding = new System.Windows.Forms.Padding(3);
            tp.Size = new System.Drawing.Size(60, 25);
            tp.ImageIndex = 0;
            this.tabControl1.TabPages.Add(tp);
            tp.Controls.Add(form);
            form.Show();
            this.tabControl1.SelectedTab = tp;
        }

        private void MForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (TabPage item in this.tabControl1.TabPages)
            {
                if (item.Controls.Count > 0)
                {
                    if (item.Controls[0] is Form)
                    {
                        Form f = (Form)item.Controls[0];
                        f.WindowState = FormWindowState.Normal;
                        f.WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }

        private void delToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count <= 0)
                return;
            if (this.tabControl1.SelectedTab == null)
                return;
            if (this.tabControl1.SelectedTab.Controls.Count <= 0)
                return;
            Control c = this.tabControl1.SelectedTab.Controls[0];
            if (c is IOrder)
            {
                (c as IOrder).DoUpdate();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count <= 0)
                return;
            if (this.tabControl1.SelectedTab == null)
                return;
            if (this.tabControl1.SelectedTab.Controls.Count <= 0)
                return;
            Control c = this.tabControl1.SelectedTab.Controls[0];
            if (c is IOrder)
            {
                (c as IOrder).DoDelete();
            }
        }

        private void filterStripButton_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count <= 0)
                return;
            if (this.tabControl1.SelectedTab == null)
                return;
            if (this.tabControl1.SelectedTab.Controls.Count <= 0)
                return;
            Control c = this.tabControl1.SelectedTab.Controls[0];
            if (c is IOrder)
            {
                (c as IOrder).DoFilter();
            }
        }
        #endregion
        private Form DoFromSwitch(Form form)
        {
            switch (this.treeView1.SelectedNode.Text)
            {
                case "人员":
                    form = new EmpViewForm();
                    break;
                case "产品":
                    form = new ProductViewForm();
                    break;
                case "订单":
                    form = new OrderViewForm();
                    break;
                case "查询":
                    form = new Quary1();
                    break;
                default:
                    break;
            }
            return form;
        }

        private void closeTsBtn_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count <= 0)
                return;
            if (this.tabControl1.SelectedTab == null)
                return;
            if (this.tabControl1.SelectedTab.Controls.Count <= 0)
                return;
            Control c = this.tabControl1.SelectedTab.Controls[0];
            if (c is IOrder)
            {
                (c as IOrder).DoClose();
            }
        }
    }
}
