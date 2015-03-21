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
    public partial class BaseMgerForm : Form
    {
        protected haiEntities db;//= new haiEntities();
        public ECurdOption Curd { get; set; }
        public DataGridViewRow Dgvr { get; set; }

        protected bool IsChecked = false;

        public IOrder ParForm { get; set; }
        public BaseMgerForm()
        {
            InitializeComponent();
        }

        protected virtual string FormValidateor()
        {
            throw new NotImplementedException("验证方法未覆盖！");
        }

        protected virtual void Sav()
        {
            var str = this.FormValidateor();
            if (string.IsNullOrEmpty(str))
            {
                this.IsChecked = true;
            }
            else
            {
                MessageBox.Show(str, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void FormClear()
        {
            throw new NotImplementedException("表单清空方法未覆盖！");
        }

        protected virtual void LoadIfC() { }

        protected virtual void LoadIfU() { }

        protected virtual void LoadIfD() { }

        protected virtual void LoadIfR() { }

        private void BaseMgerForm_Load(object sender, EventArgs e)
        {
            switch (Curd)
            {
                case ECurdOption.C:
                    LoadIfC();
                    break;
                case ECurdOption.U:
                    LoadIfU();
                    break;
                case ECurdOption.R:
                    LoadIfR();
                    break;
                case ECurdOption.D:
                    LoadIfD();
                    break;
                default:
                    break;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Sav();
        }
    }
}
