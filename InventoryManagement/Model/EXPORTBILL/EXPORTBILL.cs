using InventoryManagement.Model.PRODUCT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.EXPORTBILL
{
    public class EXPORTBILL
    {
        public HOA_DON_XUAT hoaDonXuat { get; set; }

        public EXPORTBILL()
        {

        }

        public void AddNewExportBill(int idKhoXuat, int idNguoiXuat, string ngayXuat, string tongTien, ObservableCollection<PRODUCT_CARTLIST> importProductList)
        {
            hoaDonXuat = new HOA_DON_XUAT();
            hoaDonXuat.KHO = DataProvider.Ins.DB.KHO.Where(x => x.ID_KHO == idKhoXuat).SingleOrDefault();
            hoaDonXuat.TAI_KHOAN = DataProvider.Ins.DB.TAI_KHOAN.Where(x => x.ID_TK == idNguoiXuat).SingleOrDefault();
            hoaDonXuat.THOI_GIAN_XUAT = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            hoaDonXuat.TONG_TIEN = Convert.ToDouble(tongTien);
            DataProvider.Ins.DB.HOA_DON_XUAT.Add(hoaDonXuat);
            DataProvider.Ins.DB.SaveChanges();

            foreach (var item in importProductList)
            {
                EXPORTBILL_DETAIL exportBillDetail = new EXPORTBILL_DETAIL();
                exportBillDetail.AddNewExportBill_Detail(idKhoXuat, hoaDonXuat.ID_HOA_DON_XUAT, item.product.ID_MAT_HANG, item.quantity, item.product_Price);
            }
        }

        public void EditExportBill(int idHoaDonXuat, int idKhoXuat, int idnguoixuat, string ngayXuat, string tongTien, ObservableCollection<PRODUCT_CARTLIST> importProductList)
        {
            hoaDonXuat = DataProvider.Ins.DB.HOA_DON_XUAT.Where(x => x.ID_HOA_DON_XUAT == idHoaDonXuat).SingleOrDefault();
            hoaDonXuat.KHO = DataProvider.Ins.DB.KHO.Where(x => x.ID_KHO == idKhoXuat).SingleOrDefault();
            hoaDonXuat.TAI_KHOAN = DataProvider.Ins.DB.TAI_KHOAN.Where(x => x.ID_TK == idnguoixuat).SingleOrDefault();
            hoaDonXuat.THOI_GIAN_XUAT = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            hoaDonXuat.TONG_TIEN = Convert.ToDouble(tongTien);
            DataProvider.Ins.DB.SaveChanges();

            //Xoá chi tiết hóa đơn cũ
            ObservableCollection<CT_HOA_DON_XUAT> EXPORTBILL_PRODUCT_DETAIL = new ObservableCollection<CT_HOA_DON_XUAT>(DataProvider.Ins.DB.CT_HOA_DON_XUAT.Where(x => x.ID_HOA_DON_XUAT == hoaDonXuat.ID_HOA_DON_XUAT));

            foreach (var item in EXPORTBILL_PRODUCT_DETAIL)
            {
                MAT_HANG mat_hang = new MAT_HANG();
                mat_hang = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == item.ID_MAT_HANG).SingleOrDefault();
                mat_hang.SO_LUONG_TON += item.SO_LUONG;
                DataProvider.Ins.DB.SaveChanges();


                CT_KHO_MAT_HANG temp_CT_KHO_MAT_HANG = new CT_KHO_MAT_HANG();
                temp_CT_KHO_MAT_HANG = DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x => x.ID_KHO == idKhoXuat && x.ID_MAT_HANG == item.ID_MAT_HANG).SingleOrDefault();
                temp_CT_KHO_MAT_HANG.SO_LUONG += item.SO_LUONG;
                DataProvider.Ins.DB.SaveChanges();


                DataProvider.Ins.DB.CT_HOA_DON_XUAT.Remove(item);
            }

            foreach (var item in importProductList)
            {
                EXPORTBILL_DETAIL exportBillDetail = new EXPORTBILL_DETAIL();
                exportBillDetail.AddNewExportBill_Detail(idKhoXuat, hoaDonXuat.ID_HOA_DON_XUAT, item.product.ID_MAT_HANG, item.quantity, item.product_Price);
            }
        }
    }
}
