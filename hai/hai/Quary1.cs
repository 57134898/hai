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
    public partial class Quary1 : Form, IOrder
    {
        public Quary1()
        {
            InitializeComponent();
        }

        private void Quary1_Load(object sender, EventArgs e)
        {
            using (haiEntities db = new haiEntities())
            {
                var list = db.brokeragevalue.ToList();
                this.textBox1.Text = list.SingleOrDefault(p => p.id == "A").value.ToString();
                this.textBox2.Text = list.SingleOrDefault(p => p.id == "B").value.ToString();
                this.textBox3.Text = list.SingleOrDefault(p => p.id == "C").value.ToString();

                var list1 = db.rmbvalue.ToList();
                this.textBox4.Text = list1.SingleOrDefault(p => p.id == "A").value.ToString();
                this.textBox5.Text = list1.SingleOrDefault(p => p.id == "B").value.ToString();
                this.textBox6.Text = list1.SingleOrDefault(p => p.id == "C").value.ToString();
            }
        }

        private void doSelectBTN_Click(object sender, EventArgs e)
        {
            using (haiEntities db = new haiEntities())
            {
                var list = db.v_orders.ToList();
                this.dgv.DataSource = list;
                //this.dgv.Columns["oid"].Visible = false;
                this.dgv.Columns["eid"].Visible = false;
                this.dgv.Columns["parid"].Visible = false;
                this.dgv.Columns["parparid"].Visible = false;
                this.dgv.Columns["oid"].Visible = false;
                this.dgv.Columns["oid"].HeaderText = "ID";
                this.dgv.Columns["odate"].HeaderText = "日期";
                this.dgv.Columns["todo"].HeaderText = "备注";
                this.dgv.Columns["ename"].HeaderText = "员工";
                this.dgv.Columns["parname"].HeaderText = "上级";
                this.dgv.Columns["parparname"].HeaderText = "上上级";
                this.dgv.Columns["rowcount"].HeaderText = "行数";
                this.dgv.Columns["total"].HeaderText = "小计";
                this.dgv.Columns["maxprice"].HeaderText = "最大价格";
                this.dgv.Columns["minprice"].HeaderText = "最小价格";
                this.dgv.Columns["coin"].HeaderText = "积分";
                this.dgv.Columns["parcoin"].HeaderText = "上级积分";
                this.dgv.Columns["parparcoin"].HeaderText = "上上级积分";
                this.dgv.Columns["parrmb"].HeaderText = "上级奖金";
                this.dgv.Columns["parparrmb"].HeaderText = "上上级奖金";

                this.dgv.Columns["rowcount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["maxprice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["minprice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["coin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["parcoin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["parparcoin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["parrmb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["parparrmb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgv.Columns["rowcount"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["total"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["maxprice"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["minprice"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["coin"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["parcoin"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["parparcoin"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["parrmb"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["parparrmb"].DefaultCellStyle.Format = "N2";

                this.dgv.AutoResizeColumns();
            }
        }

        private void copytoexcelBTN_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count <= 0)
            {
                MessageBox.Show("无可用数据");
                return;
            }
            string str = string.Empty;
            foreach (DataGridViewColumn c in this.dgv.Columns)
            {
                if (c.Index == 0)
                {
                    str += c.HeaderText;
                }
                else
                {
                    str += "\t" + c.HeaderText;
                }
            }
            foreach (DataGridViewRow r in this.dgv.Rows)
            {
                str += "\r\n";
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.ColumnIndex == 0)
                    {
                        if (c.Value != null)
                        {
                            str += c.Value.ToString();
                        }
                        else
                        {
                            str += "\t";
                        }
                    }
                    else
                    {
                        if (c.Value != null)
                        {
                            str += "\t" + c.Value.ToString();
                        }
                        else
                        {
                            str += "\t";
                        }
                    }
                }
            }
            Clipboard.SetData(DataFormats.Text, str);
            MessageBox.Show("已经复制到剪贴板");
        }

        public void DoAdd()
        {
            throw new NotImplementedException();
        }

        public void DoUpdate()
        {
            throw new NotImplementedException();
        }

        public void DoDelete()
        {
            throw new NotImplementedException();
        }

        public void DoView()
        {
            throw new NotImplementedException();
        }

        public void DoFilter()
        {
            throw new NotImplementedException();
        }

        public void DoRefresh()
        {
            throw new NotImplementedException();
        }

        public void DoClose()
        {
            this.Close();
        }

        private void Quary1_FormClosed(object sender, FormClosedEventArgs e)
        {
            (this.Parent.Parent as TabControl).TabPages.Remove(this.Parent as TabPage);
        }
    }
}
