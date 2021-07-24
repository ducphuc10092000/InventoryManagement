using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.EXPORTBILL
{
    public class EXPORTBILL_DETAIL
    {
        public CT_HOA_DON_XUAT exportBill_Detail { get; set; }

        public EXPORTBILL_DETAIL()
        {

        }
        public void AddNewExportBill_Detail(int idKhoXuat, int idHoaDonXuat, int idMatHang, int soLuong, string donGiaXuat)
        {
            exportBill_Detail = new CT_HOA_DON_XUAT();
            exportBill_Detail.HOA_DON_XUAT = DataProvider.Ins.DB.HOA_DON_XUAT.Where(x => x.ID_HOA_DON_XUAT == idHoaDonXuat).SingleOrDefault();
            exportBill_Detail.MAT_HANG = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == idMatHang).SingleOrDefault();
            exportBill_Detail.SO_LUONG = soLuong;
            exportBill_Detail.DON_GIA_XUAT = Convert.ToInt64(donGiaXuat);



            DataProvider.Ins.DB.CT_HOA_DON_XUAT.Add(exportBill_Detail);
            DataProvider.Ins.DB.SaveChanges();


            MAT_HANG mat_hang = new MAT_HANG();
            mat_hang = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == idMatHang).SingleOrDefault();
            mat_hang.SO_LUONG_TON -= soLuong;
            DataProvider.Ins.DB.SaveChanges();

            CT_KHO_MAT_HANG temp_CT_KHO_MAT_HANG = new CT_KHO_MAT_HANG();
            temp_CT_KHO_MAT_HANG = DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x => x.ID_KHO == idKhoXuat && x.ID_MAT_HANG == idMatHang).SingleOrDefault();

            temp_CT_KHO_MAT_HANG.SO_LUONG -= soLuong;
            temp_CT_KHO_MAT_HANG.TONG_TIEN = (soLuong * Convert.ToInt32(donGiaXuat)).ToString();
            DataProvider.Ins.DB.SaveChanges();

        }
    }
}
