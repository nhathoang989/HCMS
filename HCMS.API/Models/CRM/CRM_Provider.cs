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
    
    public partial class CRM_Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRM_Provider()
        {
            this.CRM_Provider_Address = new HashSet<CRM_Provider_Address>();
        }
    
        public int CustomerID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_Provider_Address> CRM_Provider_Address { get; set; }
    }
}
