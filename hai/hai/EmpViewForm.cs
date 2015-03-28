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
    public partial class EmpViewForm : hai.BaseViewForm
    {
        public EmpViewForm()
        {
            InitializeComponent();
        }

        private void EmpForm_Load(object sender, EventArgs e)
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
            this._megrfrom = new EmpMegrForm();
            this._megrfrom.Curd = ECurdOption.C;
            this._megrfrom.ParForm = this;
            this._megrfrom.ShowDialog();
        }

        public override void DoUpdate()
        {
            this._megrfrom = new EmpMegrForm();
            this._megrfrom.Dgvr = this.dgv.SelectedRows[0];
            this._megrfrom.Curd = ECurdOption.U;
            this._megrfrom.ParForm = this;
            this._megrfrom.ShowDialog();
        }

        public override void DoRefresh()
        {
            using (db = new haiEntities())
            {
                var ds = db.v_emp.ToList();
                this.dgv.DataSource = ds;
                this.dgv.Columns["id"].Visible = false;
                this.dgv.Columns["parid"].Visible = false;
                this.dgv.Columns["parparid"].Visible = false;
                this.dgv.Columns["name"].HeaderText = "姓名";
                this.dgv.Columns["parparname"].HeaderText = "上上级";
                this.dgv.Columns["sex"].HeaderText = "性别";
                this.dgv.Columns["address"].HeaderText = "地址";
                this.dgv.Columns["phone"].HeaderText = "手机";
                this.dgv.Columns["parname"].HeaderText = "上级";
                this.dgv.Columns["code"].HeaderText = "编号";
                this.dgv.Columns["idcardno"].HeaderText = "身份证号";
                this.dgv.AutoResizeColumns();
            }
        }

        public override void DoDelete()
        {
            using (db = new haiEntities())
            {
                if (this.dgv.Rows.Count <= 0 || this.dgv.SelectedRows.Count <= 0)
                    return;
                Guid guid = Guid.Parse(this.dgv.SelectedRows[0].Cells["id"].Value.ToString());
                employees emp = new employees();
                emp.id = guid;
                db.employees.Attach(emp);
                db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                //var emp = db.employees.SingleOrDefault(p => p.id == guid);
                //if (emp != null)
                //{
                if (DialogResult.Yes != MessageBox.Show("确定要删除该行", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;
                //db.employees.Remove(emp);
                db.SaveChanges();
                MessageBox.Show("操作成功！");
                this.DoRefresh();
            }
            //}
        }
    }
}
