using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMS.CRM.ViewInterfaces;
using HCMS.CRM.ViewModels;
namespace HCMS.CRM.Helpers
{
    class MenuHelper
    {
        public static IPageViewModel GetPageView(string menuArg) {
            switch (menuArg.ToLower())
            {
                case "login":
                    return new LoginViewModel();
                default:
                    return new HomeViewModel();
            }
        }
    }
}
