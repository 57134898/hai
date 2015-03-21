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
    public partial class ProductMegrForm : hai.BaseMgerForm
    {
        public ProductMegrForm()
        {
            InitializeComponent();
        }

        protected override void LoadIfU()
        {
            this.Text += "--更新";
            this.pnameTB.Text = Dgvr.Cells["pname"].Value.ToString();
            this.standardTB.Text = Dgvr.Cells["standard"].Value.ToString();
            this.priceTB.Text = Dgvr.Cells["price"].Value.ToString();
        }

        protected override void LoadIfC()
        {
            this.Text += "--新增";
        }

        protected override void Sav()
        {
            base.Sav();
            using (db = new haiEntities())
            {
                if (this.IsChecked)
                {
                    if (this.Curd == ECurdOption.U)
                    {
                        products pd = new products();
                        pd.pid = Guid.Parse(this.Dgvr.Cells["pid"].Value.ToString());
                        pd.pname = this.pnameTB.Text;
                        pd.standard = this.standardTB.Text;
                        pd.price = MyFuncs.StringToDcimal(this.priceTB.Text);
                        db.products.Attach(pd);
                        db.Entry(pd).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        this.ParForm.DoRefresh();
                        this.Close();
                    }
                    if (this.Curd == ECurdOption.C)
                    {
                        products pd = new products();
                        pd.pid = Guid.NewGuid();
                        pd.pname = this.pnameTB.Text;
                        pd.standard = this.standardTB.Text;
                        pd.price = MyFuncs.StringToDcimal(this.priceTB.Text);
                        db.products.Add(pd);
                        db.SaveChanges();
                        this.ParForm.DoRefresh();
                        MessageBox.Show("操作成功");
                        FormClear();
                    }
                }
            }
        }

        protected override void FormClear()
        {
            this.pnameTB.Text = string.Empty;
            this.priceTB.Text = string.Empty;
            this.standardTB.Text = string.Empty;
        }

        protected override string FormValidateor()
        {
            string str = string.Empty;
            if (this.pnameTB.Text == "")
                str += string.Format("产品名不能为空", Environment.NewLine);
            if (this.priceTB.Text == "")
                str += string.Format("价格不能为空", Environment.NewLine);
            return str;
        }
    }
}
