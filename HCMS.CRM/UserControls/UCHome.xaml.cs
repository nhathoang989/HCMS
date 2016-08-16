using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCMS.CRM.Models;
using HCMS.API.Models.CRM;

namespace HCMS.CRM.UserControls
{
    /// <summary>
    /// Interaction logic for UCHome.xaml
    /// </summary>
    public partial class UCHome : UserControl
    {
        public List<CRM_Products> lstProduct = new List<CRM_Products>();
        public UCHome()
        {
            InitializeComponent();

            using (var context = new HCRMEntities())
            {
                lstProduct = context.CRM_Products.ToList();
                dataGrid.ItemsSource = lstProduct;

            }


        }
    }
}
