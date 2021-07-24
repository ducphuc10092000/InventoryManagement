using InventoryManagement.Model;
using InventoryManagement.Model.INVENTORY;
using InventoryManagement.View.Inventory;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InventoryManagement.ViewModel.Inventory
{
    public class AddNewInventory_WD_Viewmodel : BaseViewModel
    {

        private INVENTORY _selectedInventory;
        public INVENTORY selectedInventory { get => _selectedInventory; set { _selectedInventory = value; OnPropertyChanged(); } }

        #region Declare Command AddNewInventory_WD
        public ICommand QuitCommand { get; set; }
        public ICommand AddNewInventoryCommand { get; set; }
        public ICommand ChangePictureCommand { get; set; }
        public ICommand DeletePictureCommand { get; set; }
        #endregion
        #region Binding TEXT ADDNEWPRODUCT_WD
        private string _InventoryName;
        public string InventoryName { get => _InventoryName; set { _InventoryName = value; OnPropertyChanged(); } }

        private string _InventoryAddress;
        public string InventoryAddress { get => _InventoryAddress; set { _InventoryAddress = value; OnPropertyChanged(); } }
        private string _InventoryDescription;
        public string InventoryDescription { get => _InventoryDescription; set { _InventoryDescription = value; OnPropertyChanged(); } }

        private ImageSource _AvatarSource;
        public ImageSource AvatarSource { get => _AvatarSource; set { _AvatarSource = value; OnPropertyChanged(); } }

        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }
        #endregion

        #region Declare Command EditInventory_WD
        public ICommand ConfirmEditInventoryCommand { get; set; }
        #endregion

        #region Biding TEXT EditInventory_WD
        private string _SumaryCostInventory;
        public string SumaryCostInventory { get => _SumaryCostInventory; set { _SumaryCostInventory = value; OnPropertyChanged(); } }

        private ObservableCollection<CT_KHO_MAT_HANG> _INVENTORYPRODUCTDETAILLIST;
        public ObservableCollection<CT_KHO_MAT_HANG> INVENTORYPRODUCTDETAILLIST { get => _INVENTORYPRODUCTDETAILLIST; set { _INVENTORYPRODUCTDETAILLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<INVENTORY_PRODUCT_DETAIL> _INVENTORYPRODUCTDETAILLISTDTG;
        public ObservableCollection<INVENTORY_PRODUCT_DETAIL> INVENTORYPRODUCTDETAILLISTDTG { get => _INVENTORYPRODUCTDETAILLISTDTG; set { _INVENTORYPRODUCTDETAILLISTDTG = value; OnPropertyChanged(); } }


        #endregion


        public AddNewInventory_WD_Viewmodel()
        {
            #region Handling Command AddNewInventory_WD
            AddNewInventoryCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                INVENTORY new_Inventory = new INVENTORY();

                new_Inventory.AddNewInventory(InventoryName, InventoryAddress, InventoryDescription, Avatar);

                //Reload lại nếu có thêm, không thì thôi
                Inventory_UC inventory_UC = new Inventory_UC();
                var inventory_UC_DT = inventory_UC.DataContext as Inventory_UC_ViewModel;
                inventory_UC_DT.LoadInventoryList();

                p.Close();
            });
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
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            ChangePictureCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Chọn ảnh đại diện",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "Images (*.JPG;*.PNG)|*.JPG;*.PNG",
                    RestoreDirectory = true,
                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    Avatar = ImageProvider.ImageToString(openFileDialog.FileName);
                    AvatarSource = ImageProvider.GetImage(Avatar);
                }

            });
            DeletePictureCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AvatarSource = null;
                Avatar = null;
            });
            #endregion

            #region Handling command EditInventory_WD
            ConfirmEditInventoryCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                INVENTORY new_Inventory = new INVENTORY();

                new_Inventory.EditInventory(selectedInventory.kho.ID_KHO, InventoryName, InventoryAddress, InventoryDescription, Avatar);

                //Reload lại nếu có thêm, không thì thôi
                Inventory_UC inventory_UC = new Inventory_UC();
                var inventory_UC_DT = inventory_UC.DataContext as Inventory_UC_ViewModel;
                inventory_UC_DT.LoadInventoryList();

                p.Close();
            });
            #endregion
        }

        public void ResetTextbox()
        {
            InventoryName = "";
            InventoryAddress = "";
            InventoryDescription = "";
            Avatar = "";
            AvatarSource = null;
        }
        public void LoadSelectedInventory(int selectedInventoryID)
        {
            
            selectedInventory = new INVENTORY();
            selectedInventory.kho = DataProvider.Ins.DB.KHO.Where(x => x.ID_KHO == selectedInventoryID).SingleOrDefault();

            Avatar = selectedInventory.kho.AVATAR;
            if (Avatar == null)
            {
                AvatarSource = null;
            }
            else
            {
                AvatarSource = ImageProvider.GetImage(Avatar);
            }


            INVENTORYPRODUCTDETAILLIST = new ObservableCollection<CT_KHO_MAT_HANG>(DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x => x.ID_KHO == selectedInventoryID && x.SO_LUONG > 0));
            INVENTORYPRODUCTDETAILLISTDTG = new ObservableCollection<INVENTORY_PRODUCT_DETAIL>();
            selectedInventory.kho.TONG_GIA_TRI = 0.ToString();

            double sumaryCost = new double();
            sumaryCost = 0;
            foreach (var item in INVENTORYPRODUCTDETAILLIST)
            {
                INVENTORY_PRODUCT_DETAIL temp = new INVENTORY_PRODUCT_DETAIL();
                temp.inventory_Product_Detail = item;
                INVENTORYPRODUCTDETAILLISTDTG.Add(temp);


                sumaryCost += Convert.ToDouble(item.TONG_TIEN);
            }
            selectedInventory.kho.TONG_GIA_TRI = sumaryCost.ToString();
            DataProvider.Ins.DB.SaveChanges();

            InventoryName = selectedInventory.kho.TEN_KHO;
            InventoryAddress = selectedInventory.kho.DIA_CHI_KHO;
            InventoryDescription = selectedInventory.kho.GHI_CHU;
            SumaryCostInventory = selectedInventory.kho.TONG_GIA_TRI;
        }
    }
}
