using InventoryManagement.Model;
using InventoryManagement.Model.INVENTORY;
using InventoryManagement.View.Inventory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Inventory
{
    public class Inventory_UC_ViewModel : BaseViewModel
    {

        #region Binding TEXT INVENTORY_UC
        private ObservableCollection<KHO> _INVENTORYLIST;
        public ObservableCollection<KHO> INVENTORYLIST { get => _INVENTORYLIST; set { _INVENTORYLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<INVENTORY> _INVENTORYLISTDTG;
        public ObservableCollection<INVENTORY> INVENTORYLISTDTG { get => _INVENTORYLISTDTG; set { _INVENTORYLISTDTG = value; OnPropertyChanged(); } }

        private INVENTORY _selectedInventory;
        public INVENTORY selectedInventory { get => _selectedInventory; set { _selectedInventory = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand InventoryFindCommand { get; set; }
        public ICommand InventoryDefaultCommand { get; set; }
        public ICommand Open_AddNewInventory_WD_Command { get; set; }
        public ICommand Open_EditInventory_WD_Command { get; set; }
        #endregion

        #region Declare Command InventoryList_WD
        public ICommand QuitCommand { get; set; }
        public ICommand DoubleClickSelectInventoryCommand { get; set; }
        #endregion


        public Inventory_UC_ViewModel()
        {
            #region Handling command Button InventoryList_WD
            QuitCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Những thông tin bạn nhập có thể chưa được lưu!!!\nBạn có chắc chắn muốn thoát!!!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            DoubleClickSelectInventoryCommand = new RelayCommand<InventoryList_WD>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (selectedInventory == null)
                {
                    return;
                }
                else
                {
                    p.Close();
                }
            });
            #endregion
            #region Handling command Button
            Open_AddNewInventory_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewInventory_WD addNewInventory_WD = new AddNewInventory_WD();
                var addNewInventory_WD_DT = addNewInventory_WD.DataContext as AddNewInventory_WD_Viewmodel;
                addNewInventory_WD_DT.ResetTextbox();
                addNewInventory_WD.ShowDialog();
                addNewInventory_WD.Close();

            });

            Open_EditInventory_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditInventory_WD editInventory_WD = new EditInventory_WD();
                var editProduct_WD_DT = editInventory_WD.DataContext as AddNewInventory_WD_Viewmodel;
                editProduct_WD_DT.LoadSelectedInventory(Convert.ToInt32(p));
                editInventory_WD.ShowDialog();
                editInventory_WD.Close();
            });


            InventoryFindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

            });

            InventoryDefaultCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

            });
            #endregion

        }
        public void LoadInventoryList()
        {
            INVENTORYLIST = new ObservableCollection<KHO>(DataProvider.Ins.DB.KHO);
            INVENTORYLISTDTG = new ObservableCollection<INVENTORY>();
            foreach (var item in INVENTORYLIST)
            {
                INVENTORY temp_inventory = new INVENTORY();
                

                ObservableCollection<CT_KHO_MAT_HANG> INVENTORYPRODUCTDETAILLIST = new ObservableCollection<CT_KHO_MAT_HANG>(DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x=>x.ID_KHO == item.ID_KHO));
                double sumaryCost = new double();
                sumaryCost = 0;
                foreach (var itemDetail in INVENTORYPRODUCTDETAILLIST)
                {
                    INVENTORY_PRODUCT_DETAIL temp = new INVENTORY_PRODUCT_DETAIL();
                    temp.inventory_Product_Detail = itemDetail;
                    temp.inventory_Product_Detail.TONG_TIEN = itemDetail.TONG_TIEN;
                    sumaryCost += Convert.ToDouble(itemDetail.TONG_TIEN);
                }
                item.TONG_GIA_TRI = sumaryCost.ToString();

                temp_inventory.kho = item;
                INVENTORYLISTDTG.Add(temp_inventory);


            }
        }
    }
}
