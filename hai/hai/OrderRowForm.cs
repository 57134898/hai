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
    public partial class OrderRowForm : Form
    {
        public Action<DataGridViewRow, decimal, decimal, decimal, string> DoAdd { get; set; }
        public OrderRowForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DoAdd(this.productBTN.Tag as DataGridViewRow, decimal.Parse(this.priceTB.Text), decimal.Parse(this.countTB.Text), decimal.Parse(this.totalTB.Text), this.todoTB.Text);
            this.countTB.Text = "";
            this.todoTB.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaseItemForm bform = new BaseItemForm();
            bform.ItemHelper = (p) =>
            {
                this.productBTN.Tag = p;//.Cells["pid"].Value.ToString();
                this.productBTN.Text = p.Cells["pname"].Value.ToString();
                this.priceTB.Text = p.Cells["price"].Value.ToString();
            };
            bform.DataHelper = (dv) =>
            {
                using (haiEntities ddb = new haiEntities())
                {
                    var ds = ddb.products.ToList();
                    dv.DataSource = ds;
                    dv.Columns["pid"].Visible = false;
                    dv.Columns["pname"].HeaderText = "产品名";
                    dv.Columns["price"].HeaderText = "价格";
                    dv.Columns["standard"].HeaderText = "规格";
                    dv.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dv.Columns["price"].DefaultCellStyle.Format = "N2";
                    dv.AutoResizeColumns();

                }
            };
            bform.FilterHelper = (p, q, m) =>
            {
                List<products> list = m.DataSource as List<products>;
                var newlist = list.Where(
                                    u =>
                                    {
                                        Type t = u.GetType();
                                        string s = t.GetProperty(p).GetValue(u).ToString();
                                        if (s.IndexOf(q) < 0)
                                            return false;
                                        else
                                            return true;
                                    }).ToList();
                m.DataSource = newlist;
            };
            bform.ShowDialog();
        }

        private void countTB_TextChanged(object sender, EventArgs e)
        {
            if (this.priceTB.Text == "" || this.countTB.Text == "")
            {
                this.totalTB.Text = "0";
            }
            else
            {
                try
                {
                    this.totalTB.Text = (decimal.Parse(this.priceTB.Text) * decimal.Parse(this.countTB.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.countTB.Text = "0";
                    this.totalTB.Text = "0";
                }
            }
        }
    }
}
