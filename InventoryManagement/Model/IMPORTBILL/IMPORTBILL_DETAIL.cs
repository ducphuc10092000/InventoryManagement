using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.IMPORTBILL
{
    public class IMPORTBILL_DETAIL
    {
        public CT_HOA_DON_NHAP importBill_Detail { get; set; }

        public IMPORTBILL_DETAIL()
        {

        }

        public void AddNewImportBill_Detail(int idKhoNhap, int idHoaDonNhap, int idMatHang, int soLuong, string donGiaNhap)
        {
            importBill_Detail = new CT_HOA_DON_NHAP();
            importBill_Detail.HOA_DON_NHAP = DataProvider.Ins.DB.HOA_DON_NHAP.Where(x => x.ID_HOA_DON_NHAP == idHoaDonNhap).SingleOrDefault();
            importBill_Detail.MAT_HANG = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == idMatHang).SingleOrDefault();
            importBill_Detail.SO_LUONG = soLuong;
            importBill_Detail.DON_GIA_NHAP = Convert.ToInt64(donGiaNhap);



            DataProvider.Ins.DB.CT_HOA_DON_NHAP.Add(importBill_Detail);
            DataProvider.Ins.DB.SaveChanges();


            MAT_HANG mat_hang = new MAT_HANG();
            mat_hang = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == idMatHang).SingleOrDefault();
            mat_hang.SO_LUONG_TON += soLuong;
            DataProvider.Ins.DB.SaveChanges();

            CT_KHO_MAT_HANG temp_CT_KHO_MAT_HANG = new CT_KHO_MAT_HANG();
            temp_CT_KHO_MAT_HANG = DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x => x.ID_KHO == idKhoNhap && x.ID_MAT_HANG == idMatHang).SingleOrDefault();

            if (temp_CT_KHO_MAT_HANG == null)
            {
                temp_CT_KHO_MAT_HANG = new CT_KHO_MAT_HANG();
                temp_CT_KHO_MAT_HANG.ID_KHO = idKhoNhap;
                temp_CT_KHO_MAT_HANG.ID_MAT_HANG = idMatHang;
                temp_CT_KHO_MAT_HANG.SO_LUONG = soLuong;
                temp_CT_KHO_MAT_HANG.TONG_TIEN = (soLuong * Convert.ToInt32(donGiaNhap)).ToString();
                DataProvider.Ins.DB.CT_KHO_MAT_HANG.Add(temp_CT_KHO_MAT_HANG);
            }    
            else
            {
                temp_CT_KHO_MAT_HANG.SO_LUONG += soLuong;
                temp_CT_KHO_MAT_HANG.TONG_TIEN = (soLuong * Convert.ToInt32(donGiaNhap)).ToString();
            }
            DataProvider.Ins.DB.SaveChanges();

        }
    }
}
