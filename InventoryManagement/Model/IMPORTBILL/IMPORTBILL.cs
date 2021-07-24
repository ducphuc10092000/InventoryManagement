using InventoryManagement.Model.PRODUCT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.IMPORTBILL
{
    public class IMPORTBILL
    {
        public HOA_DON_NHAP hoaDonNhap {get; set;}

        public IMPORTBILL()
        {

        }

        public void AddNewImportBill(int idKhoNhap, int idNCC, int idnguoinhap, string ngayNhap, string tongTien, ObservableCollection<PRODUCT_CARTLIST> importProductList)
        {
            hoaDonNhap = new HOA_DON_NHAP();
            hoaDonNhap.KHO = DataProvider.Ins.DB.KHO.Where(x=>x.ID_KHO == idKhoNhap).SingleOrDefault();
            hoaDonNhap.NHA_CUNG_CAP = DataProvider.Ins.DB.NHA_CUNG_CAP.Where(x => x.ID_NCC == idNCC).SingleOrDefault();
            hoaDonNhap.TAI_KHOAN = DataProvider.Ins.DB.TAI_KHOAN.Where(x => x.ID_TK == idnguoinhap).SingleOrDefault();
            hoaDonNhap.THOI_GIAN_NHAP = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            hoaDonNhap.TONG_TIEN = Convert.ToDouble(tongTien);
            DataProvider.Ins.DB.HOA_DON_NHAP.Add(hoaDonNhap);
            DataProvider.Ins.DB.SaveChanges();

            foreach(var item in importProductList)
            {
                IMPORTBILL_DETAIL importBillDetail = new IMPORTBILL_DETAIL();
                importBillDetail.AddNewImportBill_Detail(idKhoNhap,hoaDonNhap.ID_HOA_DON_NHAP, item.product.ID_MAT_HANG, item.quantity, item.product_Price);
            }    
        }

        public void EditImportBill(int idHoaDonNhap,int idKhoNhap, int idNCC, int idnguoinhap, string ngayNhap, string tongTien, ObservableCollection<PRODUCT_CARTLIST> importProductList)
        {
            hoaDonNhap = DataProvider.Ins.DB.HOA_DON_NHAP.Where(x => x.ID_HOA_DON_NHAP == idHoaDonNhap).SingleOrDefault();
            hoaDonNhap.KHO = DataProvider.Ins.DB.KHO.Where(x => x.ID_KHO == idKhoNhap).SingleOrDefault();
            hoaDonNhap.NHA_CUNG_CAP = DataProvider.Ins.DB.NHA_CUNG_CAP.Where(x => x.ID_NCC == idNCC).SingleOrDefault();
            hoaDonNhap.TAI_KHOAN = DataProvider.Ins.DB.TAI_KHOAN.Where(x => x.ID_TK == idnguoinhap).SingleOrDefault();
            hoaDonNhap.THOI_GIAN_NHAP = ngayNhap;
            hoaDonNhap.TONG_TIEN = Convert.ToDouble(tongTien);
            DataProvider.Ins.DB.SaveChanges();

            //Xoá chi tiết hóa đơn cũ
            ObservableCollection<CT_HOA_DON_NHAP> IMPORTBILL_PRODUCT_DETAIL = new ObservableCollection<CT_HOA_DON_NHAP>(DataProvider.Ins.DB.CT_HOA_DON_NHAP.Where(x => x.ID_HOA_DON_NHAP == hoaDonNhap.ID_HOA_DON_NHAP));

            foreach (var item in IMPORTBILL_PRODUCT_DETAIL)
            {
                MAT_HANG mat_hang = new MAT_HANG();
                mat_hang = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == item.ID_MAT_HANG).SingleOrDefault();
                mat_hang.SO_LUONG_TON -= item.SO_LUONG;
                DataProvider.Ins.DB.SaveChanges();


                CT_KHO_MAT_HANG temp_CT_KHO_MAT_HANG = new CT_KHO_MAT_HANG();
                temp_CT_KHO_MAT_HANG = DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x => x.ID_KHO == idKhoNhap && x.ID_MAT_HANG == item.ID_MAT_HANG).SingleOrDefault();

                if (temp_CT_KHO_MAT_HANG == null)
                {
                    temp_CT_KHO_MAT_HANG = new CT_KHO_MAT_HANG();
                    temp_CT_KHO_MAT_HANG.ID_KHO = idKhoNhap;
                    temp_CT_KHO_MAT_HANG.ID_MAT_HANG = item.ID_MAT_HANG;
                    temp_CT_KHO_MAT_HANG.SO_LUONG = item.SO_LUONG;
                    temp_CT_KHO_MAT_HANG.TONG_TIEN = (item.SO_LUONG * Convert.ToInt32(item.DON_GIA_NHAP )).ToString();
                    DataProvider.Ins.DB.CT_KHO_MAT_HANG.Add(temp_CT_KHO_MAT_HANG);
                }
                else
                {
                    temp_CT_KHO_MAT_HANG.SO_LUONG -= item.SO_LUONG;
                }
                DataProvider.Ins.DB.SaveChanges();


                DataProvider.Ins.DB.CT_HOA_DON_NHAP.Remove(item);
            }

            foreach (var item in importProductList)
            {
                IMPORTBILL_DETAIL importBillDetail = new IMPORTBILL_DETAIL();
                importBillDetail.AddNewImportBill_Detail(idKhoNhap, hoaDonNhap.ID_HOA_DON_NHAP, item.product.ID_MAT_HANG, item.quantity, item.product_Price);
            }    
        }
    }
}
