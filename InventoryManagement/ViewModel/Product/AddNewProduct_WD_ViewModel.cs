using InventoryManagement.Model;
using InventoryManagement.Model.PRODUCT;
using InventoryManagement.View.Product.ProductType;
using InventoryManagement.View.Product.ProductUnit;
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

namespace InventoryManagement.ViewModel.Product
{
    public class AddNewProduct_WD_ViewModel : BaseViewModel
    {
        #region Command EDITPRODUCT_WD
        public ICommand Confirm_EditProduct_Command { get; set; }
        #endregion
        #region Binding TEXT EDITPRODUCT_WD
        private int _selectedProductID;
        public int selectedProductID { get => _selectedProductID; set { _selectedProductID = value; OnPropertyChanged(); } }

        private string _selectedProductName;
        public string selectedProductName { get => _selectedProductName; set { _selectedProductName = value; OnPropertyChanged(); } }

        private string _selectedProductTypeName;
        public string selectedProductTypeName { get => _selectedProductTypeName; set { _selectedProductTypeName = value; OnPropertyChanged(); } }

        private string _selectedProductUnitName;
        public string selectedProductUnitName { get => _selectedProductUnitName; set { _selectedProductUnitName = value; OnPropertyChanged(); } }
        private string _selectedProductPrice;
        public string selectedProductPrice { get => _selectedProductPrice; set { _selectedProductPrice = value; OnPropertyChanged(); } }
        private string _selectedProductDescription;
        public string selectedProductDescription { get => _selectedProductDescription; set { _selectedProductDescription = value; OnPropertyChanged(); } }
        #endregion


        #region Binding TEXT ADDNEWPRODUCT_WD
        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private string _ProductType;
        public string ProductType { get => _ProductType; set { _ProductType = value; OnPropertyChanged(); } }

        private string _ProductUnit;
        public string ProductUnit { get => _ProductUnit; set { _ProductUnit = value; OnPropertyChanged(); } }
        private string _ProductPrice;
        public string ProductPrice { get => _ProductPrice; set { _ProductPrice = value; OnPropertyChanged(); } }
        private string _ProductDescription;
        public string ProductDescription { get => _ProductDescription; set { _ProductDescription = value; OnPropertyChanged(); } }

        private ImageSource _AvatarSource;
        public ImageSource AvatarSource { get => _AvatarSource; set { _AvatarSource = value; OnPropertyChanged(); } }

        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }
        #endregion


        #region Binding list combobox
        private ObservableCollection<LOAI_MAT_HANG> _PRODUCTTYPELIST;
        public ObservableCollection<LOAI_MAT_HANG> PRODUCTTYPELIST { get => _PRODUCTTYPELIST; set { _PRODUCTTYPELIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ProductTypeList;
        public ObservableCollection<string> ProductTypeList { get => _ProductTypeList; set { _ProductTypeList = value; OnPropertyChanged(); } }

        private ObservableCollection<DON_VI_TINH> _PRODUCTUNITLIST;
        public ObservableCollection<DON_VI_TINH> PRODUCTUNITLIST { get => _PRODUCTUNITLIST; set { _PRODUCTUNITLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ProductUnitList;
        public ObservableCollection<string> ProductUnitList { get => _ProductUnitList; set { _ProductUnitList = value; OnPropertyChanged(); } }
        #endregion

        #region Command ADDNEWPRODUCT_WD
        public ICommand QuitCommand { get; set; }
        public ICommand AddNewProductCommand { get; set; }
        public ICommand ChangePictureCommand { get; set; }
        public ICommand DeletePictureCommand { get; set; }

        public ICommand Open_AddNewProductType_WD_Command { get; set; }

        public ICommand Open_AddNewProductUnit_WD_Command { get; set; }
        #endregion

        #region Binding TEXT ADDNEWPRODUCT_TYPE_WD
        private string _newProductTypeName;
        public string newProductTypeName { get => _newProductTypeName; set { _newProductTypeName = value; OnPropertyChanged(); } }

        private string _newProductTypeDescription;
        public string newProductTypeDescription { get => _newProductTypeDescription; set { _newProductTypeDescription = value; OnPropertyChanged(); } }
        #endregion

        #region Command ADDNEWPRODUCT_TYPE_WD
        public ICommand AddNewProductTypeCommand { get; set; }
        #endregion

        #region Binding TEXT ADDNEWPRODUCT_UNIT_WD
        private string _newProductUnitName;
        public string newProductUnitName { get => _newProductUnitName; set { _newProductUnitName = value; OnPropertyChanged(); } }

        private string _newProductUnitDescription;
        public string newProductUnitDescription { get => _newProductUnitDescription; set { _newProductUnitDescription = value; OnPropertyChanged(); } }
        #endregion

        #region Command ADDNEWPRODUCT_UNIT_WD
        public ICommand AddNewProductUnitCommand { get; set; }
        #endregion

        public AddNewProduct_WD_ViewModel()
        {
            ResetTextbox();
            LoadProductTypeList();
            LoadProductUnitList();

            #region Handling ADDNEWPRODUCT_WD command

            //Mở window thêm mới loại mặt hàng
            Open_AddNewProductType_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //reset textbox
                newProductTypeName = null;
                newProductTypeDescription = null;  

                //Open window
                AddNewProductType_WD addNewProductType_WD = new AddNewProductType_WD();
                addNewProductType_WD.ShowDialog();

            });

            //Mở window thêm mới đơn vị tính
            Open_AddNewProductUnit_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //reset textbox 
                newProductUnitName = null;
                newProductUnitDescription = null;

                //Open window
                AddNewProductUnit_WD addNewProductUnit_WD = new AddNewProductUnit_WD();
                addNewProductUnit_WD.ShowDialog();

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
                    ResetTextbox();
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            AddNewProductCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                PRODUCT new_Product = new PRODUCT();
                
                LOAI_MAT_HANG selected_ProductType = DataProvider.Ins.DB.LOAI_MAT_HANG.Where(x => x.TEN_LOAI_MAT_HANG == ProductType).SingleOrDefault();
                DON_VI_TINH selected_ProductUnit = DataProvider.Ins.DB.DON_VI_TINH.Where(x => x.TEN_DVT == ProductUnit).SingleOrDefault();

                new_Product.AddNewProduct(ProductName, selected_ProductType.ID_LMH, selected_ProductUnit.ID_DVT, ProductPrice, ProductDescription, Avatar);
                p.Close();
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

            #region Handling ADDNEWPRODUCT_TYPE_WD command
            AddNewProductTypeCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                LOAI_MAT_HANG newProductType = new LOAI_MAT_HANG();
                newProductType.TEN_LOAI_MAT_HANG = newProductTypeName;
                newProductType.GHI_CHU = newProductTypeDescription;

                DataProvider.Ins.DB.LOAI_MAT_HANG.Add(newProductType);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm mới thành công loại mặt hàng!");
                LoadProductTypeList();
                p.Close();
            });
            #endregion

            #region Handling ADDNEWPRODUCT_Unit_WD command
            AddNewProductUnitCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if(string.IsNullOrEmpty(newProductUnitName))
                {
                    MessageBox.Show("Tên đơn vị tính không được để trống");
                    return;
                }    

                DON_VI_TINH newProductUnit = new DON_VI_TINH();
                newProductUnit.TEN_DVT = newProductUnitName;
                newProductUnit.GHI_CHU = newProductUnitDescription;

                DataProvider.Ins.DB.DON_VI_TINH.Add(newProductUnit);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm mới thành công đơn vị tính!");
                LoadProductUnitList();
                p.Close();
            });

            AddNewProductTypeCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (string.IsNullOrEmpty(newProductTypeName))
                {
                    MessageBox.Show("Tên loại mặt hàng không được để trống");
                    return;
                }

                LOAI_MAT_HANG newProductType = new LOAI_MAT_HANG();
                newProductType.TEN_LOAI_MAT_HANG = newProductTypeName;
                newProductType.GHI_CHU = newProductTypeDescription;

                DataProvider.Ins.DB.LOAI_MAT_HANG.Add(newProductType);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm mới thành công loại mặt hàng!");
                LoadProductTypeList();
                p.Close();
            });
            #endregion

            #region Handling Edit_Product_WD command
            Confirm_EditProduct_Command = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                PRODUCT selected_Product = new PRODUCT();

                LOAI_MAT_HANG selected_ProductType = DataProvider.Ins.DB.LOAI_MAT_HANG.Where(x => x.TEN_LOAI_MAT_HANG == selectedProductTypeName).SingleOrDefault();
                DON_VI_TINH selected_ProductUnit = DataProvider.Ins.DB.DON_VI_TINH.Where(x => x.TEN_DVT == selectedProductUnitName).SingleOrDefault();

                selected_Product.EditProduct(selectedProductID, selectedProductName, selected_ProductType.ID_LMH, selected_ProductUnit.ID_DVT, selectedProductPrice, selectedProductDescription, Avatar);
                p.Close();
            });
            #endregion

        }

        public void LoadProductUnitList()
        {

            PRODUCTUNITLIST = new ObservableCollection<DON_VI_TINH>(DataProvider.Ins.DB.DON_VI_TINH);
            ProductUnitList = new ObservableCollection<string>();
            foreach (var item in PRODUCTUNITLIST)
            {
                ProductUnitList.Add(item.TEN_DVT);
            }
        }

        public void LoadProductTypeList()
        {

            PRODUCTTYPELIST = new ObservableCollection<LOAI_MAT_HANG>(DataProvider.Ins.DB.LOAI_MAT_HANG);
            ProductTypeList = new ObservableCollection<string>();
            foreach (var item in PRODUCTTYPELIST)
            {
                ProductTypeList.Add(item.TEN_LOAI_MAT_HANG);
            }
        }
        public void ResetTextbox()
        {
            ProductName = "";
            ProductType = "";
            ProductUnit = "";
            ProductPrice = "";
            ProductDescription = "";
            Avatar = "";
            AvatarSource = null;

        }


        //Load window edit PRODUCT
        public void LoadSelectedProduct(int selectedProductID_from_Product_UC)
        {

            selectedProductID = selectedProductID_from_Product_UC;
            PRODUCT selectedProduct = new PRODUCT();
            selectedProduct.product = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MAT_HANG == selectedProductID_from_Product_UC).SingleOrDefault();
            selectedProductName = selectedProduct.product.TEN_MAT_HANG;
            selectedProductTypeName = selectedProduct.product.LOAI_MAT_HANG.TEN_LOAI_MAT_HANG;
            selectedProductUnitName = selectedProduct.product.DON_VI_TINH.TEN_DVT;
            selectedProductPrice = selectedProduct.product.DON_GIA.ToString();
            selectedProductDescription = selectedProduct.product.GHI_CHU;
            Avatar = selectedProduct.product.AVATAR;

            if (Avatar == null)
            {
                AvatarSource = null;
            }
            else
            {
                AvatarSource = ImageProvider.GetImage(Avatar);
            }
        }
    }
}
