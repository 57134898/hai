using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hai
{
    public interface IOrder
    {
        void DoAdd();

        void DoUpdate();

        void DoDelete();

        void DoView();

        void DoFilter();

        void DoRefresh();
        void DoClose();
    }
}
