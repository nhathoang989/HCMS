using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.CRM.ViewInterfaces
{
    public interface IView
    {
        object DataContext { get; set; }
        void Close();
    }
}
