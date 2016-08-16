using HCMS.API.Models.CRM;
using HCMS.CRM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.CRM.ViewModels
{
    public class ProductPropertyViewModel: ObjectBase
    {
        public ProductPropertyViewModel(CRM_Product_Property model)
        {
            Model = model;
        }

        
        public CRM_Product_Property Model
        {
            get
            {
                return Model;
            }

            set
            {
                Model = value;
            }
        }
    }
}
