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
    
    public partial class CT_KHO_MAT_HANG
    {
        public int ID_KHO { get; set; }
        public int ID_MAT_HANG { get; set; }
        public Nullable<int> SO_LUONG { get; set; }
        public string TONG_TIEN { get; set; }
    
        public virtual KHO KHO { get; set; }
        public virtual MAT_HANG MAT_HANG { get; set; }
    }
}
