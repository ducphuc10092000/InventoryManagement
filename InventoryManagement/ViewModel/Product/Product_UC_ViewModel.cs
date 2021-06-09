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

        public Product_UC_ViewModel()
        {
            //Load list PRODUCT
            LoadProductList();

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
    }
}
