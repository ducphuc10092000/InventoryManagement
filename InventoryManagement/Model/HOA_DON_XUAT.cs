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
    
    public partial class HOA_DON_XUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA_DON_XUAT()
        {
            this.CT_HOA_DON_XUAT = new HashSet<CT_HOA_DON_XUAT>();
        }
    
        public int ID_HOA_DON_XUAT { get; set; }
        public Nullable<int> ID_NGUOI_NHAN { get; set; }
        public Nullable<int> ID_NGUOI_XUAT_HANG { get; set; }
        public Nullable<System.DateTime> THOI_GIAN_XUAT { get; set; }
        public Nullable<double> TONG_TIEN { get; set; }
        public string GHI_CHU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOA_DON_XUAT> CT_HOA_DON_XUAT { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
    }
}
