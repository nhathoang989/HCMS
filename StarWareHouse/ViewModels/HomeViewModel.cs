using StarWareHouse.Framework;
using StarWareHouse.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWareHouse.ViewModels
{
    class HomeViewModel : BaseDialogWindow, IView
    {
        public new string Name
        {
            get
            {
                return "Home Page";
            }
        }

    }
}
