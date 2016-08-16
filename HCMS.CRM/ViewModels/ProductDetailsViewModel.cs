using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HCMS.CRM.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(JObject model)
        {
            Model = model;
        }

        public JObject Model { get; set; }
    }
}
