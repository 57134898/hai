using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hai
{
    public partial class BaseViewForm : Form, IOrder
    {
        protected haiEntities db;//= new haiEntities();
        protected BaseMgerForm _megrfrom;

        public BaseViewForm()
        {
            InitializeComponent();
        }

        private void BaseViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            (this.Parent.Parent as TabControl).TabPages.Remove(this.Parent as TabPage);
        }

        public virtual void DoAdd()
        {
            this._megrfrom.Curd = ECurdOption.C;
            this._megrfrom.ShowDialog();
        }

        public virtual void DoUpdate()
        {
            throw new NotImplementedException();
        }

        public virtual void DoDelete()
        {
            throw new NotImplementedException();
        }

        public virtual void DoView()
        {
            throw new NotImplementedException();
        }

        public virtual void DoFilter()
        {
            throw new NotImplementedException();
        }

        public virtual void DoRefresh()
        {
            throw new NotImplementedException();
        }

        public virtual void DoClose()
        {
            this.Close();
        }
    }
}
