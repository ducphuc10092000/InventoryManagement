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
    
    public partial class HOA_DON_NHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA_DON_NHAP()
        {
            this.CT_HOA_DON_NHAP = new HashSet<CT_HOA_DON_NHAP>();
        }
    
        public int ID_HOA_DON_NHAP { get; set; }
        public Nullable<int> ID_KHO_NHAP { get; set; }
        public Nullable<int> ID_NCC { get; set; }
        public Nullable<int> ID_NGUOI_NHAP_HANG { get; set; }
        public Nullable<double> TONG_TIEN { get; set; }
        public string GHI_CHU { get; set; }
        public string THOI_GIAN_NHAP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOA_DON_NHAP> CT_HOA_DON_NHAP { get; set; }
        public virtual KHO KHO { get; set; }
        public virtual NHA_CUNG_CAP NHA_CUNG_CAP { get; set; }
        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
    }
}
