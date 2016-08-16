using HCMS.API.Models.CRM;
using HCMS.CRM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMS.CRM.ViewInterfaces;

namespace HCMS.CRM.ViewModels
{
    public class ProductViewModel: ViewModelBase<IDialogView>
    {
        public ProductViewModel() : base(new ProductViewModel())
        {
        }

        public ProductViewModel(CRM_Products model)
        {

        }
        public CRM_Products Model { get; private set; }
        public List<CRM_Product_Property> PropertyModels { get; private set; }
    }
}
