//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCMS.API.Models.CRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRM_Provider_Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public int CustomerID { get; set; }
    
        public virtual CRM_Provider CRM_Provider { get; set; }
    }
}