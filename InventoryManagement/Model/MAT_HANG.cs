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
    
    public partial class MAT_HANG
    {
        public string TEN_MAT_HANG { get; set; }
        public Nullable<int> ID_DVT { get; set; }
        public Nullable<int> ID_LMH { get; set; }
        public Nullable<int> SO_LUONG_TON { get; set; }
        public Nullable<double> DON_GIA { get; set; }
        public string GHI_CHU { get; set; }
        public string AVATAR { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public int ID_MAT_HANG { get; set; }
    
        public virtual DON_VI_TINH DON_VI_TINH { get; set; }
        public virtual LOAI_MAT_HANG LOAI_MAT_HANG { get; set; }
    }
}