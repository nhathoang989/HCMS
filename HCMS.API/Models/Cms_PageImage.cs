//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCMS.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cms_PageImage
    {
        public int ImageID { get; set; }
        public string Caption { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public int PageID { get; set; }
        public string Src { get; set; }
    
        public virtual Cms_Page Cms_Page { get; set; }
    }
}