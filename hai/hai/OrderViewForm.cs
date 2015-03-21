using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace hai
{
    public partial class OrderViewForm : hai.BaseViewForm
    {
        public OrderViewForm()
        {
            InitializeComponent();
        }

        private void OrderViewForm_Load(object sender, EventArgs e)
        {

            this.dgv.CellDoubleClick += dgv_CellDoubleClick;
            this.DoRefresh();
        }

        void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DoUpdate();
        }

        public override void DoAdd()
        {
            this._megrfrom = new OrderMegrForm();
            this._megrfrom.Curd = ECurdOption.C;
            this._megrfrom.ParForm = this;
            this._megrfrom.ShowDialog();
        }

        public override void DoUpdate()
        {
            this._megrfrom = new OrderMegrForm();
            this._megrfrom.Dgvr = this.dgv.SelectedRows[0];
            this._megrfrom.Curd = ECurdOption.U;
            this._megrfrom.ParForm = this;
            this._megrfrom.ShowDialog();
        }

        public override void DoRefresh()
        {
            using (db = new haiEntities())
            {
                var ds = db.v_orders.ToList();
                this.dgv.DataSource = ds;

                this.dgv.Columns["oid"].Visible = false;
                this.dgv.Columns["eid"].Visible = false;

                this.dgv.Columns["odate"].HeaderText = "日期";
                this.dgv.Columns["ename"].HeaderText = "员工";
                this.dgv.Columns["total"].HeaderText = "金额";
                this.dgv.Columns["rowcount"].HeaderText = "行数";
                this.dgv.Columns["maxprice"].HeaderText = "最高价";
                this.dgv.Columns["minprice"].HeaderText = "最低价";
                this.dgv.Columns["todo"].HeaderText = "备注";

                this.dgv.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["total"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["rowcount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["rowcount"].DefaultCellStyle.Format = "N0";
                this.dgv.Columns["maxprice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["maxprice"].DefaultCellStyle.Format = "N2";
                this.dgv.Columns["minprice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["minprice"].DefaultCellStyle.Format = "N2";

                this.dgv.AutoResizeColumns();

            }
        }

        public override void DoDelete()
        {
            using (db = new haiEntities())
            {
                if (this.dgv.Rows.Count <= 0 || this.dgv.SelectedRows.Count <= 0)
                    return;
                if (DialogResult.Yes != MessageBox.Show("确定要删除该行", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;
                Guid guid = Guid.Parse(this.dgv.SelectedRows[0].Cells["oid"].Value.ToString());
                orders ord = new orders();
                ord.oid = guid;
                db.orders.Attach(ord);
                db.Entry(ord).State = System.Data.Entity.EntityState.Deleted;

                var rows = db.orderows.Where(p => p.oid == guid);
                db.orderows.RemoveRange(rows);
                db.SaveChanges();
                MessageBox.Show("操作成功！");
                this.DoRefresh();
            }
        }

    }
}
