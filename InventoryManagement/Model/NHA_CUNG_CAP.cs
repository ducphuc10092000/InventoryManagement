//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHA_CUNG_CAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHA_CUNG_CAP()
        {
            this.HOA_DON_NHAP = new HashSet<HOA_DON_NHAP>();
        }
    
        public int ID_NCC { get; set; }
        public string TEN_NCC { get; set; }
        public string GHI_CHU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON_NHAP> HOA_DON_NHAP { get; set; }
    }
}
