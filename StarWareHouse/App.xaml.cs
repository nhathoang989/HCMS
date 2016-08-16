using StarWareHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StarWareHouse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LoginViewModel currUser = new LoginViewModel();
        public static string baseWebAPIAddress = "http://localhost:7000/";
    }
}
