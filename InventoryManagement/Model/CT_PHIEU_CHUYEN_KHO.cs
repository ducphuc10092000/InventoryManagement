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
    
    public partial class CT_PHIEU_CHUYEN_KHO
    {
        public int ID_PHIEU_CHUYEN_KHO { get; set; }
        public int ID_MAT_HANG { get; set; }
        public Nullable<int> SO_LUONG { get; set; }
        public string GHI_CHU { get; set; }
    
        public virtual MAT_HANG MAT_HANG { get; set; }
        public virtual PHIEU_CHUYEN_KHO PHIEU_CHUYEN_KHO { get; set; }
    }
}