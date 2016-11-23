using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO1_SMK_Restaurant.Class
{
    public interface ICallBack
    {
        void view(baseView view, string[] data);
    }
}
