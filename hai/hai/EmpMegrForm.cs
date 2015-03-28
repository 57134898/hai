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
                this.nameTB.Text = MyFuncs.GetCellValue(Dgvr.Cells["name"]);
                this.phoneTB.Text = MyFuncs.GetCellValue(Dgvr.Cells["phone"]);
                this.addressTB.Text = MyFuncs.GetCellValue(Dgvr.Cells["address"]);
                this.codeTB.Text = MyFuncs.GetCellValue(Dgvr.Cells["code"]);
                this.idcardnoTB.Text = MyFuncs.GetCellValue(Dgvr.Cells["idcardno"]);
                this.sexCBB.Text = MyFuncs.GetCellValue(Dgvr.Cells["sex"]);
                var list = db.employees.OrderBy(p => p.name).ToList();
                list.Insert(0, new employees() { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), name = "无" });
                this.parCBB.DataSource = list;
                this.parCBB.DisplayMember = "name";
                this.parCBB.ValueMember = "id";
                foreach (var item in list)
                {
                    if (Dgvr.Cells["parid"].Value == null)
                        return;
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
                var list = db.employees.OrderBy(p => p.name).ToList();
                list.Insert(0, new employees() { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), name = "无" });
                this.parCBB.DataSource = list;
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
                        emp.code = this.codeTB.Text;
                        emp.idcardno = this.idcardnoTB.Text;
                        if (Guid.Parse(this.parCBB.SelectedValue.ToString()) != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                        {
                            emp.parid = Guid.Parse(this.parCBB.SelectedValue.ToString());
                        }
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
                        emp.code = this.codeTB.Text;
                        emp.idcardno = this.idcardnoTB.Text;
                        if (Guid.Parse(this.parCBB.SelectedValue.ToString()) != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                        {
                            emp.parid = Guid.Parse(this.parCBB.SelectedValue.ToString());
                        }
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
            this.codeTB.Text = string.Empty;
            this.idcardnoTB.Text = string.Empty;
            var list = db.employees.OrderBy(p => p.name).ToList();
            list.Insert(0, new employees() { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), name = "无" });
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
