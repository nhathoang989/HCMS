using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.CRM.ViewInterfaces
{
    public interface IPageViewModel
    {
        string Title { get; }
        string Key { get; }

    }
}
