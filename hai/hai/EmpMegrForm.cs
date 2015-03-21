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
    public partial class EmpMegrForm : hai.BaseMgerForm
    {
        public EmpMegrForm()
        {
            InitializeComponent();
        }

        private void EmpMegrForm_Load(object sender, EventArgs e)
        {

        }

        protected override void LoadIfU()
        {
            using (db = new haiEntities())
            {
                this.Text += "--更新";
                this.nameTB.Text = Dgvr.Cells["name"].Value.ToString();
                this.phoneTB.Text = Dgvr.Cells["phone"].Value.ToString();
                this.addressTB.Text = Dgvr.Cells["address"].Value.ToString();
                this.sexCBB.Text = Dgvr.Cells["sex"].Value.ToString();
                var list = db.employees.OrderBy(p => p.name).ToList();
                this.parCBB.DataSource = list;
                this.parCBB.DisplayMember = "name";
                this.parCBB.ValueMember = "id";
                foreach (var item in list)
                {

                    if (item.id == Guid.Parse(Dgvr.Cells["parid"].Value.ToString()))
                    {

                        this.parCBB.SelectedItem = item;
                    }
                }
            }
        }
        protected override void LoadIfC()
        {
            using (db = new haiEntities())
            {
                this.Text += "--新增";
                this.parCBB.DataSource = db.employees.OrderBy(p => p.name).ToList();
                this.parCBB.DisplayMember = "name";
                this.parCBB.ValueMember = "id";
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
                        employees emp = new employees();
                        emp.id = Guid.Parse(Dgvr.Cells["id"].Value.ToString());
                        emp.name = this.nameTB.Text;
                        emp.phone = this.phoneTB.Text;
                        emp.address = this.addressTB.Text;
                        emp.parid = Guid.Parse(this.parCBB.SelectedValue.ToString());
                        emp.sex = this.sexCBB.Text;
                        db.employees.Attach(emp);
                        db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        this.ParForm.DoRefresh();
                        this.Close();
                    }
                    else
                    {
                        employees emp = new employees();
                        emp.id = Guid.NewGuid();
                        emp.name = this.nameTB.Text;
                        emp.phone = this.phoneTB.Text;
                        emp.address = this.addressTB.Text;
                        emp.parid = Guid.Parse(this.parCBB.SelectedValue.ToString());
                        emp.sex = this.sexCBB.Text;
                        db.employees.Add(emp);
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
            this.nameTB.Text = string.Empty;
            this.addressTB.Text = string.Empty;
            this.phoneTB.Text = string.Empty;
            var list = db.employees.OrderBy(p => p.name).ToList();
            this.parCBB.DataSource = list;
            this.parCBB.DisplayMember = "name";
            this.parCBB.ValueMember = "id";
        }

        protected override string FormValidateor()
        {
            string str = string.Empty;
            if (this.nameTB.Text == "")
                str += string.Format("姓名不能为空", Environment.NewLine);
            //if (this.parCBB.SelectedIndex < 0)
            //    str += string.Format("上级不能为空", Environment.NewLine);
            return str;
        }
    }
}
