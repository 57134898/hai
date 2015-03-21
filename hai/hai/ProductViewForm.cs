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
    public partial class ProductViewForm : hai.BaseViewForm
    {
        public ProductViewForm()
        {
            InitializeComponent();
        }

        private void ProductViewForm_Load(object sender, EventArgs e)
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
            this._megrfrom = new ProductMegrForm();
            this._megrfrom.Curd = ECurdOption.C;
            this._megrfrom.ParForm = this;
            this._megrfrom.ShowDialog();
        }

        public override void DoUpdate()
        {
            this._megrfrom = new ProductMegrForm();
            this._megrfrom.Dgvr = this.dgv.SelectedRows[0];
            this._megrfrom.Curd = ECurdOption.U;
            this._megrfrom.ParForm = this;
            this._megrfrom.ShowDialog();
        }

        public override void DoRefresh()
        {
            using (db = new haiEntities())
            {
                var ds = db.products.ToList();
                this.dgv.DataSource = ds;
                this.dgv.Columns["pid"].Visible = false;
                this.dgv.Columns["pname"].HeaderText = "产品名";
                this.dgv.Columns["price"].HeaderText = "价格";
                this.dgv.Columns["standard"].HeaderText = "规格";
                this.dgv.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgv.Columns["price"].DefaultCellStyle.Format = "N2";
                this.dgv.AutoResizeColumns();
            }

        }

        public override void DoDelete()
        {
            if (this.dgv.Rows.Count <= 0 || this.dgv.SelectedRows.Count <= 0)
                return;
            Guid guid = Guid.Parse(this.dgv.SelectedRows[0].Cells["pid"].Value.ToString());
            using (db = new haiEntities())
            {
                var product = db.products.SingleOrDefault(p => p.pid == guid);
                if (product != null)
                {
                    if (DialogResult.Yes != MessageBox.Show("确定要删除该行", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return;
                    db.products.Remove(product);
                    db.SaveChanges();
                    MessageBox.Show("操作成功！");
                    this.DoRefresh();
                }
            }
        }
    }
}
