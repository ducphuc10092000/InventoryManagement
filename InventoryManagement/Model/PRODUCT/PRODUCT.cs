using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagement.Model.PRODUCT
{
    public class PRODUCT
    {
        public MAT_HANG product { get; set; }

        public PRODUCT()
        {

        }

        public void AddNewProduct(string productName, int idProductType, int idProductUnit, string productPrice, string productDescription, string avatar)
        {
            product = new MAT_HANG();
            product.TEN_MAT_HANG = productName;
            product.LOAI_MAT_HANG = DataProvider.Ins.DB.LOAI_MAT_HANG.Where(x => x.ID_LMH == idProductType).SingleOrDefault();
            product.DON_VI_TINH = DataProvider.Ins.DB.DON_VI_TINH.Where(x => x.ID_DVT == idProductUnit).SingleOrDefault();
            product.ID_LMH = idProductType;
            product.ID_DVT = idProductUnit;
            product.DON_GIA = Convert.ToDouble(productPrice.ToString());
            product.GHI_CHU = productDescription;
            if(avatar != null)
            {
                product.AVATAR = avatar;
            }    
            product.ACTIVE = true;

            DataProvider.Ins.DB.MAT_HANG.Add(product);
            DataProvider.Ins.DB.SaveChanges();


            MessageBox.Show("Thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }    

        public void EditProduct(int selectedProductID, string productName, int idProductType, int idProductUnit, string productPrice, string productDescription, string avatar)
        {
            product = new MAT_HANG();
            product = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == selectedProductID).SingleOrDefault();
            product.TEN_MAT_HANG = productName;
            product.LOAI_MAT_HANG = DataProvider.Ins.DB.LOAI_MAT_HANG.Where(x => x.ID_LMH == idProductType).SingleOrDefault();
            product.DON_VI_TINH = DataProvider.Ins.DB.DON_VI_TINH.Where(x => x.ID_DVT == idProductUnit).SingleOrDefault();
            product.DON_GIA = Convert.ToDouble(productPrice.ToString());
            product.GHI_CHU = productDescription;
            product.AVATAR = avatar;

            DataProvider.Ins.DB.SaveChanges();

            MessageBox.Show("Chỉnh sửa thông tin sản phẩm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
