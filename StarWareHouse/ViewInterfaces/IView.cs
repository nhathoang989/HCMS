using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWareHouse.ViewInterfaces
{
    public interface IView
    {
        string Name { get; }
        object DataContext { get; set; }
        void Close();
    }
}
