using HCMS.CRM.Framework;
using HCMS.CRM.ViewInterfaces;
using HCMS.CRM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.CRM.ViewModels
{
    class HomeViewModel : ObjectBase, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Home";
            }
        }
    }
}
