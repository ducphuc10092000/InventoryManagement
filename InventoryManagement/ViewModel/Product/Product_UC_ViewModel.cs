using InventoryManagement.Model;
using InventoryManagement.Model.PRODUCT;
using InventoryManagement.View.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Product
{
    public class Product_UC_ViewModel : BaseViewModel
    {
        #region Binding PRODUCT_UC
        private ObservableCollection<MAT_HANG> _PRODUCTLIST;
        public ObservableCollection<MAT_HANG> PRODUCTLIST { get => _PRODUCTLIST; set { _PRODUCTLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<PRODUCT> _PRODUCTLISTDTG;
        public ObservableCollection<PRODUCT> PRODUCTLISTDTG { get => _PRODUCTLISTDTG; set { _PRODUCTLISTDTG = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand ProductFindCommand { get; set; }
        public ICommand ProductDefaultCommand { get; set; }
        public ICommand Open_AddNewProduct_WD_Command { get; set; }
        public ICommand Open_EditProductWD_Command { get; set; }
        #endregion

        #region Declare Command ProductList_WD 
        public ICommand QuitCommand { get; set; }
        public ICommand DoubleClickSelectProductCommand { get; set; }
        #endregion

        #region Binding TEXT ProductList_WD
        private PRODUCT _selectedProduct;
        public PRODUCT selectedProduct { get => _selectedProduct; set { _selectedProduct = value; OnPropertyChanged(); } }

        #endregion
        public Product_UC_ViewModel()
        {
            //Load list PRODUCT
            //LoadProductList();
            #region handling COmmand Button ProductList_WD
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

            DoubleClickSelectProductCommand = new RelayCommand<ProductList_WD>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (selectedProduct == null)
                {
                    return;
                }
                else
                {
                    p.Close();
                }
            });
            #endregion

            #region Handling command button
            Open_AddNewProduct_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewProduct_WD addNewProduct_WD = new AddNewProduct_WD();
                addNewProduct_WD.ShowDialog();
                addNewProduct_WD.Close();
                LoadProductList();
            });

            Open_EditProductWD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditProduct_WD editProduct_WD = new EditProduct_WD();
                var editProduct_WD_DT = editProduct_WD.DataContext as AddNewProduct_WD_ViewModel;
                editProduct_WD_DT.LoadSelectedProduct(Convert.ToInt32(p));
                editProduct_WD.ShowDialog();
                editProduct_WD.Close();
                LoadProductList();
            });

            ProductFindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

            });

            ProductDefaultCommand = new RelayCommand<object>((p) =>
            { return true; 
            }, (p) =>
            {
                    
            });
            
            #endregion
        }

        public void LoadProductList()
        {
            PRODUCTLIST = new ObservableCollection<MAT_HANG>(DataProvider.Ins.DB.MAT_HANG.Where(x => x.ACTIVE == true));
            PRODUCTLISTDTG = new ObservableCollection<PRODUCT>();
            foreach (var item in PRODUCTLIST)
            {
                PRODUCT temp_product = new PRODUCT();

                temp_product.product = item;

                PRODUCTLISTDTG.Add(temp_product);
            }
        }

        public void LoadProductListBaseID(int selectedInventoryID)
        {

            ObservableCollection<CT_KHO_MAT_HANG> INVENTORYPRODUCTDETAILLIST = new ObservableCollection<CT_KHO_MAT_HANG>(DataProvider.Ins.DB.CT_KHO_MAT_HANG.Where(x=>x.SO_LUONG > 0));

            PRODUCTLISTDTG = new ObservableCollection<PRODUCT>();

            foreach (var item in INVENTORYPRODUCTDETAILLIST)
            {
                PRODUCT temp = new PRODUCT();

                if(item.ID_KHO == selectedInventoryID)
                {
                    temp.product = item.MAT_HANG;
                    temp.product.SO_LUONG_TON = item.SO_LUONG;
                    PRODUCTLISTDTG.Add(temp);
                }
            }    
        }
    }
}
