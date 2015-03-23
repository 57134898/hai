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
    public partial class Quary1 : Form
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

                this.dgv.AutoResizeColumns();
            }
        }
    }
}
