﻿using System;
using Newtonsoft.Json;

namespace CustomAngularUmbraco.models
{
    public class MasterModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("templateUrl")]
        public string AngularTemplateUrl { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }
}