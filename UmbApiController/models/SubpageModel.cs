using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAngularUmbraco.models.helper;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace CustomAngularUmbraco.models
{
    public class SubpageModel : MasterModel
    {
        [JsonProperty("contentImages")]
        public IEnumerable<ImageModel> ContentImages { get; set; }

        [JsonProperty("contentBody")]
        public string ContentBody { get; set; }

        public static SubpageModel GetFromContent(IPublishedContent a)
        {
            return new SubpageModel
            {
                Id = a.Id,
                Name = a.Name,
                ContentImages = ImageModel.GetImages(a, "contentImages", 640, 480),
                ContentBody = a.GetPropertyValue<string>("contentBody"),
                AngularTemplateUrl = "/ng-views/subpage.html",
                Created = a.CreateDate,
                Updated = a.UpdateDate
            };
        }
    }
}
