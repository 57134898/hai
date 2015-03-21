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
    public partial class BaseItemForm : Form
    {
        public BaseItemForm()
        {
            InitializeComponent();
        }
        public Action<DataGridViewRow> ItemHelper { get; set; }
        public Action<string, string, DataGridView> FilterHelper { get; set; }
        public Action<DataGridView> DataHelper { get; set; }
        private void BaseItemForm_Load(object sender, EventArgs e)
        {
            this.DataHelper(this.dgv);
            foreach (DataGridViewColumn item in this.dgv.Columns)
            {
                if (item.Visible)
                {
                    this.itemtoolStripComboBox.Items.Add(item.HeaderText);
                }
            }
        }

        private void filtertoolStripButton_Click(object sender, EventArgs e)
        {
            if (this.valuetoolStripTextBox.Text == "")
                return;
            if (this.itemtoolStripComboBox.SelectedIndex < 0)
                return;
            foreach (DataGridViewColumn item in this.dgv.Columns)
            {
                if (item.HeaderText == itemtoolStripComboBox.Text)
                {
                    this.FilterHelper(item.Name, this.valuetoolStripTextBox.Text, dgv);
                    break;
                }
            }

        }

        private void entertoolStripButton_Click(object sender, EventArgs e)
        {
            if (this.ItemHelper == null)
                return;
            if (this.dgv.Rows.Count <= 0)
                return;
            this.ItemHelper(this.dgv.SelectedRows[0]);
            this.Close();
        }

        private void alltoolStripButton_Click(object sender, EventArgs e)
        {
            this.DataHelper(this.dgv);
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.ItemHelper == null)
                return;
            if (this.dgv.Rows.Count <= 0)
                return;
            this.ItemHelper(this.dgv.SelectedRows[0]);
            this.Close();
        }

    }
}
