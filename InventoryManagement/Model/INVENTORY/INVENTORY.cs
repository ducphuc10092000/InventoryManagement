using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagement.Model.INVENTORY
{
    public class INVENTORY
    {
        public KHO kho { get; set; }

        public INVENTORY()
        {

        }

        public void AddNewInventory(string inventoryName, string inventoryAddress, string inventoryDescription, string avatar)
        {
            kho = new KHO();
            kho.TEN_KHO = inventoryName;
            kho.DIA_CHI_KHO = inventoryAddress;
            kho.GHI_CHU = inventoryDescription;
            kho.TONG_GIA_TRI = "0";
            if(!string.IsNullOrEmpty(avatar))
            {
                kho.AVATAR = avatar;
            }
            DataProvider.Ins.DB.KHO.Add(kho);
            DataProvider.Ins.DB.SaveChanges();


            MessageBox.Show("Thêm mới kho hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void EditInventory(int inventoryID, string inventoryName, string inventoryAddress, string inventoryDescription, string avatar)
        {
            kho = DataProvider.Ins.DB.KHO.Where(x => x.ID_KHO == inventoryID).SingleOrDefault();
            kho.TEN_KHO = inventoryName;
            kho.DIA_CHI_KHO = inventoryAddress;
            kho.GHI_CHU = inventoryDescription;
            if (!string.IsNullOrEmpty(avatar))
            {
                kho.AVATAR = avatar;
            }
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Chỉnh sửa thông tin kho hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
