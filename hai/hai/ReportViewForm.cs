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
    public partial class ReportViewForm : Form, IOrder
    {
        public ReportViewForm()
        {
            InitializeComponent();
        }

        private void ReportViewForm_Load(object sender, EventArgs e)
        {

        }

        private void doSelectBTN_Click(object sender, EventArgs e)
        {
            if (this.reportListCBB.Text == "佣金表")
            {
                // TODO:  这行代码将数据加载到表“haiDataSet.v_rebate”中。您可以根据需要移动或删除它。
                this.v_rebateTableAdapter.FillBy(this.haiDataSet.v_rebate, this.dateTimePicker1.Value.ToShortDateString(), this.dateTimePicker2.Value.ToShortDateString());
                this.reportViewer1.RefreshReport();
            }

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

        private void ReportViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            (this.Parent.Parent as TabControl).TabPages.Remove(this.Parent as TabPage);
        }
    }
}
