using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;

namespace hai
{
    public partial class OrderMegrForm : hai.BaseMgerForm
    {
        private List<products> productList = new List<products>();

        public OrderMegrForm()
        {
            InitializeComponent();
        }

        private void empbutton_Click(object sender, EventArgs e)
        {
            BaseItemForm bform = new BaseItemForm();
            bform.ItemHelper = (p) =>
            {
                this.empBTN.Tag = p.Cells["id"].Value.ToString();
                this.empBTN.Text = p.Cells["name"].Value.ToString();
            };
            bform.DataHelper = (dv) =>
            {
                using (haiEntities ddb = new haiEntities())
                {
                    var list = ddb.v_emp.ToList();
                    dv.DataSource = list;
                    dv.Columns["id"].Visible = false;
                    dv.Columns["parid"].Visible = false;
                    dv.Columns["name"].HeaderText = "姓名";
                    dv.Columns["sex"].HeaderText = "性别";
                    dv.Columns["address"].HeaderText = "地址";
                    dv.Columns["phone"].HeaderText = "手机";
                    dv.Columns["parname"].HeaderText = "上级";
                    dv.AutoResizeColumns();
                }
            };
            bform.FilterHelper = (p, q, m) =>
            {
                List<v_emp> list = m.DataSource as List<v_emp>;
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




        protected override void LoadIfU()
        {
            using (db = new haiEntities())
            {
                this.Text += "--更新";
                this.empBTN.Text = Dgvr.Cells["ename"].Value.ToString();
                this.empBTN.Tag = Dgvr.Cells["eid"].Value.ToString();
                this.todoTB.Text = Dgvr.Cells["todo"].Value.ToString();
                this.dateTimePicker1.Value = DateTime.Parse(Dgvr.Cells["odate"].Value.ToString());
                //MessageBox.Show(Dgvr.Cells["oid"].Value.ToString());
                Guid guid = Guid.Parse(Dgvr.Cells["oid"].Value.ToString());
                var list = db.orderows.Where(p => p.oid == guid).ToList();
                foreach (var item in list)
                {
                    var product = db.products.FirstOrDefault(q => q.pid == item.pid);
                    this.dgv.Rows.Add(new object[] { 
                         item.pid
                        ,product.pname
                        ,product.standard
                        ,item.price,item.count,item.price*item.count,item.todo
                });
                    this.dgv.AutoResizeColumns();
                }
            }
        }
        protected override void LoadIfC()
        {
            using (db = new haiEntities())
            {
                this.Text += "--新增";
            }
        }


        protected override void Sav()
        {
            base.Sav();
            if (this.IsChecked)
            {
                using (db = new haiEntities())
                {
                    if (this.Curd == ECurdOption.U)
                    {
                        orders ord = new orders();
                        var oid = Guid.Parse(this.Dgvr.Cells["oid"].Value.ToString());
                        ord.oid = oid;
                        ord.eid = Guid.Parse(this.empBTN.Tag.ToString());
                        ord.odate = this.dateTimePicker1.Value;
                        ord.todo = this.todoTB.Text;
                        db.orders.Attach(ord);
                        db.Entry(ord).State = System.Data.Entity.EntityState.Modified;
                        db.orderows.RemoveRange(db.orderows.Where(p => p.oid == oid));
                        foreach (DataGridViewRow r in this.dgv.Rows)
                        {
                            orderows ordr = new orderows();
                            ordr.oid = oid;
                            ordr.pid = Guid.Parse(r.Cells["guidColumn"].Value.ToString());
                            ordr.price = decimal.Parse(r.Cells["priceColumn"].Value.ToString());
                            ordr.count = int.Parse(r.Cells["countColumn"].Value.ToString());
                            ordr.todo = r.Cells["todoColumn"].Value.ToString();
                            db.orderows.Add(ordr);
                        }
                        db.SaveChanges();
                        this.ParForm.DoRefresh();
                        this.Close();
                    }
                    else
                    {
                        var oid = Guid.NewGuid();
                        orders ord = new orders();
                        ord.oid = oid;
                        ord.eid = Guid.Parse(this.empBTN.Tag.ToString());
                        ord.odate = this.dateTimePicker1.Value;
                        ord.todo = this.todoTB.Text;
                        db.orders.Add(ord);
                        foreach (DataGridViewRow r in this.dgv.Rows)
                        {
                            orderows ordr = new orderows();
                            ordr.oid = oid;
                            ordr.pid = Guid.Parse(r.Cells["guidColumn"].Value.ToString());
                            ordr.price = decimal.Parse(r.Cells["priceColumn"].Value.ToString());
                            ordr.count = int.Parse(r.Cells["countColumn"].Value.ToString());
                            ordr.todo = r.Cells["todoColumn"].Value.ToString();
                            db.orderows.Add(ordr);
                        }
                        db.SaveChanges();
                        MessageBox.Show("操作成功");
                        this.ParForm.DoRefresh();
                        FormClear();
                    }
                }
            }
        }

        protected override void FormClear()
        {
            this.todoTB.Text = "";
            this.dgv.Rows.Clear();
        }

        protected override string FormValidateor()
        {
            string str = string.Empty;
            if (this.empBTN.Text == "-请选择-")
                str += string.Format("员工不能为空", Environment.NewLine);
            if (this.dgv.Rows.Count <= 0)
                str += string.Format("产品不能为空", Environment.NewLine);
            return str;
        }

        private void newrowTSBTN_Click(object sender, EventArgs e)
        {
            OrderRowForm orf = new OrderRowForm();
            orf.DoAdd = (dgvr, price, count, total, todo) =>
            {
                this.dgv.Rows.Add(new object[] { 
                         dgvr.Cells["pid"].Value
                        ,dgvr.Cells["pname"].Value.ToString() 
                        ,dgvr.Cells["standard"].Value.ToString()
                        ,price,count,total,todo
                });
                this.dgv.AutoResizeColumns();
            };
            orf.ShowDialog();
        }

        private void delrowTSBTN_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count > 0)
            {
                this.dgv.Rows.Remove(this.dgv.SelectedRows[0]);
            }
        }

        private void inportTSBTN_Click(object sender, EventArgs e)
        {

        }

        private void OrderMegrForm_Load(object sender, EventArgs e)
        {

        }
    }
}
