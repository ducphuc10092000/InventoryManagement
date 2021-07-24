using InventoryManagement.Model;
using InventoryManagement.Model.IMPORTBILL;
using InventoryManagement.Model.INVENTORY;
using InventoryManagement.Model.PRODUCT;
using InventoryManagement.Model.PROVIDER;
using InventoryManagement.View.Inventory;
using InventoryManagement.View.Product;
using InventoryManagement.View.Provider;
using InventoryManagement.ViewModel.Inventory;
using InventoryManagement.ViewModel.Product;
using InventoryManagement.ViewModel.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InventoryManagement.ViewModel.Import
{
    public class AddNewImportBill_WD_ViewModel : BaseViewModel
    {
        #region Bool to check filled
        private bool _isSelectedProduct;
        public bool isSelectedProduct { get => _isSelectedProduct; set { _isSelectedProduct = value; OnPropertyChanged(); } }

        private bool _isSelectedInventory;
        public bool isSelectedInventory { get => _isSelectedInventory; set { _isSelectedInventory = value; OnPropertyChanged(); } }

        private bool _isSelectedProvider;
        public bool isSelectedProvider { get => _isSelectedProvider; set { _isSelectedProvider = value; OnPropertyChanged(); } }

        private bool _isFilledAll;
        public bool isFilledAll { get => _isFilledAll; set { _isFilledAll = value; OnPropertyChanged(); } }



        private bool _isChangedInventory;
        public bool isChangedInventory { get => _isChangedInventory; set { _isChangedInventory = value; OnPropertyChanged(); } }

        private bool _isChangedProvider;
        public bool isChangedProvider { get => _isChangedProvider; set { _isChangedProvider = value; OnPropertyChanged(); } }

        #endregion

        #region Binding TEXT AddNewImportBill_WD

        private double _SumaryBillCost;
        public double SumaryBillCost { get => _SumaryBillCost; set { _SumaryBillCost = value; OnPropertyChanged(); } }

        private ObservableCollection<PRODUCT_CARTLIST> _IMPORTPRODUCTLISTDTG;
        public ObservableCollection<PRODUCT_CARTLIST> IMPORTPRODUCTLISTDTG { get => _IMPORTPRODUCTLISTDTG; set { _IMPORTPRODUCTLISTDTG = value; OnPropertyChanged(); } }

        private TAI_KHOAN _LoggedInAccount;
        public TAI_KHOAN LoggedInAccount { get => _LoggedInAccount; set { _LoggedInAccount = value; OnPropertyChanged(); } }

        private string _InventoryName;
        public string InventoryName { get => _InventoryName; set { _InventoryName = value; OnPropertyChanged(); } }

        private INVENTORY _SelectedInventory;
        public INVENTORY SelectedInventory { get => _SelectedInventory; set { _SelectedInventory = value; OnPropertyChanged(); } }

        private string _ProviderName;
        public string ProviderName { get => _ProviderName; set { _ProviderName = value; OnPropertyChanged(); } }

        private PROVIDER _SelectedProvider;
        public PROVIDER SelectedProvider { get => _SelectedProvider; set { _SelectedProvider = value; OnPropertyChanged(); } }

        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private string _ProductPrice;
        public string ProductPrice { get => _ProductPrice; set { _ProductPrice = value; OnPropertyChanged(); } }

        private string _ProductQuantity;
        public string ProductQuantity { get => _ProductQuantity; set { _ProductQuantity = value; OnPropertyChanged(); } }

        private DateTime _ImportDay;
        public DateTime ImportDay { get => _ImportDay; set { _ImportDay = value; OnPropertyChanged(); } }

        private TimeSpan _ImportTime;
        public TimeSpan ImportTime { get => _ImportTime; set { _ImportTime = value; OnPropertyChanged(); } }

        private string _ImportDayTimeString;
        public string ImportDayTimeString { get => _ImportDayTimeString; set { _ImportDayTimeString = value; OnPropertyChanged(); } }

        private PRODUCT_CARTLIST _SelectedProduct;
        public PRODUCT_CARTLIST SelectedProduct { get => _SelectedProduct; set { _SelectedProduct = value; OnPropertyChanged(); } }
        #endregion

        #region Binding TEXT EditImportBill_WD
        private IMPORTBILL _SelectedImportBill;
        public IMPORTBILL SelectedImportBill { get => _SelectedImportBill; set { _SelectedImportBill = value; OnPropertyChanged(); } }
        #endregion

        #region Declare Command WD_ADDNEWIMPORTBILL
        public ICommand QuitCommand { get; set; }
        public ICommand Open_InventoryList_WD_Command { get; set; }
        public ICommand Open_ProductList_WD_Command { get; set; }
        public ICommand Open_ProviderList_WD_Command { get; set; }
        public ICommand AddProductToImportListCommand { get; set; }
        public ICommand ResetImportBillCommand { get; set; }
        public ICommand CreateImportBillCommand { get; set; }
        public ICommand DeleteProductFromCartListCommand { get; set; }
        #endregion

        #region Declare Command EditImportBIll_WD
        public ICommand Open_EditImportBill_Command { get; set; }

        public ICommand Reset_EditImportBill_Command { get; set; }

        public ICommand ConfirmEditImportBillCommand { get; set; }
        #endregion

        public AddNewImportBill_WD_ViewModel()
        {
            isSelectedProduct = false;
            isSelectedInventory = false;
            isSelectedProvider = false;
            isFilledAll = false;
            IMPORTPRODUCTLISTDTG = new ObservableCollection<PRODUCT_CARTLIST>();
            ImportDayTimeString = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            #region Handling Command Button AddNewImportBill_WD

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
            DeleteProductFromCartListCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm khỏi giỏ hàng?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var item in IMPORTPRODUCTLISTDTG)
                    {
                        if(item.product.ID_MAT_HANG == Convert.ToInt32(p))
                        {
                            IMPORTPRODUCTLISTDTG.Remove(item);
                            CalculateCost();
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            });
            ResetImportBillCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Những thông tin bạn nhập có thể chưa được lưu!!!\nBạn có chắc chắn muốn đặt lại!!!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ResetTextboxProduct();
                    ResetBill();
                }
                else
                {
                    return;
                }
            });
            CreateImportBillCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                IMPORTBILL importBill = new IMPORTBILL();
                importBill.AddNewImportBill(SelectedInventory.kho.ID_KHO, SelectedProvider.provider.ID_NCC, LoggedInAccount.ID_TK, ImportDayTimeString, SumaryBillCost.ToString(), IMPORTPRODUCTLISTDTG);

                MessageBox.Show("Tạo hóa đơn nhập hàng thành công!!!", "Chúc mừng", MessageBoxButton.YesNo, MessageBoxImage.Information);
                p.Close();
            });
            Open_InventoryList_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                InventoryList_WD inventoryList_WD = new InventoryList_WD();
                //LoadInventoryList
                var inventoryList_WD_DT = inventoryList_WD.DataContext as Inventory_UC_ViewModel;
                inventoryList_WD_DT.LoadInventoryList();

                inventoryList_WD.ShowDialog();
                inventoryList_WD.Close();

                if (inventoryList_WD_DT.selectedInventory == null)
                {
                    return;
                }
                else
                {
                    SelectedInventory = inventoryList_WD_DT.selectedInventory;
                    InventoryName = SelectedInventory.kho.TEN_KHO;
                    isSelectedInventory = true;
                    if (isSelectedProvider == true && IMPORTPRODUCTLISTDTG.Count()!= 0 )
                    {
                        isFilledAll = true;
                    }
                }
            });
            Open_ProviderList_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ProviderList_WD providerList_WD = new ProviderList_WD();
                //LoadInventoryList
                var providerList_WD_DT = providerList_WD.DataContext as ProviderList_WD_ViewModel;
                providerList_WD_DT.LoadProviderList();

                providerList_WD.ShowDialog();
                providerList_WD.Close();

                if (providerList_WD_DT.selectedProvider == null)
                {
                    return;
                }
                else
                {
                    SelectedProvider = providerList_WD_DT.selectedProvider;
                    ProviderName = SelectedProvider.provider.TEN_NCC;
                    isSelectedProvider = true;
                    if (isSelectedInventory == true && IMPORTPRODUCTLISTDTG.Count() != 0)
                    {
                        isFilledAll = true;
                    }
                }
            });
            Open_ProductList_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ProductList_WD productList_WD = new ProductList_WD();

                //LoadProductList
                var productList_WD_DT = productList_WD.DataContext as Product_UC_ViewModel;
                productList_WD_DT.LoadProductList();

                productList_WD.ShowDialog();
                productList_WD.Close();

                if (productList_WD_DT.selectedProduct == null)
                {
                    return;
                }
                else
                {
                    SelectedProduct = new PRODUCT_CARTLIST();
                    SelectedProduct.product = productList_WD_DT.selectedProduct.product;
                    ProductName = SelectedProduct.product.TEN_MAT_HANG;
                    ProductPrice = SelectedProduct.product.DON_GIA.ToString();
                    ProductQuantity = 1.ToString();
                    isSelectedProduct = true;
                }
            });
            AddProductToImportListCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                SelectedProduct.quantity = Convert.ToInt32(ProductQuantity);
                SelectedProduct.product_Price = ProductPrice;
                SelectedProduct.product_TotalPrice = (SelectedProduct.quantity * Convert.ToInt64(SelectedProduct.product_Price)).ToString();


                //Sản phẩm đã tồn tại trong giỏ hàng
                if (IMPORTPRODUCTLISTDTG.Where(x => x.product == SelectedProduct.product).SingleOrDefault() != null)
                {
                    //Loop lấy item cần thay đổi
                    foreach (var item in IMPORTPRODUCTLISTDTG)
                    {
                        if (item.product.ID_MAT_HANG == SelectedProduct.product.ID_MAT_HANG)
                        {
                            //Nếu khác giá
                            if (ProductPrice != item.product_Price)
                            {
                                MessageBoxResult result = MessageBox.Show("Đơn giá nhập này khác với đơn giá nhập cũ, bạn chắc chắn muốn thay đổi đơn giá nhập?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (result == MessageBoxResult.Yes)
                                {
                                    item.quantity += Convert.ToInt32(ProductQuantity);
                                    item.product_Price = ProductPrice;
                                    ResetTextboxProduct();
                                    CalculateCost();
                                    return;
                                }
                                else
                                {
                                    ResetTextboxProduct();
                                    return;
                                }
                            } 

                            //Nếu cùng giá
                            else
                            {
                                item.quantity += Convert.ToInt32(ProductQuantity);
                                CalculateCost();
                                ResetTextboxProduct();
                                return;
                            }    
                        }
                        item.product_TotalPrice = (item.quantity * Convert.ToInt32(item.product_Price)).ToString();
                        SumaryBillCost += Convert.ToDouble(item.product_TotalPrice);
                    }

                    return;
                }
                else
                {
                    IMPORTPRODUCTLISTDTG.Add(SelectedProduct);
                    SumaryBillCost += Convert.ToDouble(SelectedProduct.product_TotalPrice);
                    ResetTextboxProduct();

                }
                if (isFilledAll == false)
                {
                    if(IMPORTPRODUCTLISTDTG.Count() != 0)
                    {
                        if(isSelectedInventory == true && isSelectedProvider == true)
                        {
                            isFilledAll = true;
                        }    
                    }    
                }    
            });
            #endregion

            #region Handling Command Button EditImportBill_WD
            ConfirmEditImportBillCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ImportDayTimeString = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                IMPORTBILL importBill = new IMPORTBILL();
                importBill.EditImportBill(SelectedImportBill.hoaDonNhap.ID_HOA_DON_NHAP,SelectedInventory.kho.ID_KHO, SelectedProvider.provider.ID_NCC, LoggedInAccount.ID_TK, ImportDayTimeString, SumaryBillCost.ToString(), IMPORTPRODUCTLISTDTG);

                MessageBox.Show("Chỉnh sửa thông tin hóa đơn nhập hàng thành công!!!", "Chúc mừng", MessageBoxButton.YesNo, MessageBoxImage.Information);
                p.Close();
            });
            #endregion
        }

        public void ResetTextboxProduct()
        {

            SelectedProduct = null;
            ProductQuantity = "";
            ProductName = "";
            ProductPrice = "";
            isSelectedProduct = false;
        }

        public void CalculateCost()
        {
            SumaryBillCost = 0;
            foreach(var item in IMPORTPRODUCTLISTDTG)
            {
                item.product_TotalPrice = (item.quantity * Convert.ToInt32(item.product_Price)).ToString();
                SumaryBillCost += Convert.ToDouble(item.product_TotalPrice);
            }    
        }
        public void ResetBill()
        {
            isFilledAll = false;
            SelectedInventory = null;
            InventoryName = "";
            SelectedProvider = null;
            ProviderName = "";
            IMPORTPRODUCTLISTDTG = new ObservableCollection<PRODUCT_CARTLIST>();
            SumaryBillCost = 0;
        }

        public void LoadSelectedImportBill()
        {
            SelectedInventory = new INVENTORY();
            SelectedProvider = new PROVIDER();
            SelectedInventory.kho = SelectedImportBill.hoaDonNhap.KHO;
            SelectedProvider.provider = SelectedImportBill.hoaDonNhap.NHA_CUNG_CAP;
            SumaryBillCost = Convert.ToDouble(SelectedImportBill.hoaDonNhap.TONG_TIEN);
            InventoryName = SelectedImportBill.hoaDonNhap.KHO.TEN_KHO;
            ProviderName = SelectedImportBill.hoaDonNhap.NHA_CUNG_CAP.TEN_NCC;
            ImportDayTimeString = SelectedImportBill.hoaDonNhap.THOI_GIAN_NHAP;

            ObservableCollection<CT_HOA_DON_NHAP> IMPORT_PRODUCT_DETAIL = new ObservableCollection<CT_HOA_DON_NHAP>(DataProvider.Ins.DB.CT_HOA_DON_NHAP.Where(x => x.ID_HOA_DON_NHAP == SelectedImportBill.hoaDonNhap.ID_HOA_DON_NHAP));

            IMPORTPRODUCTLISTDTG = new ObservableCollection<PRODUCT_CARTLIST>();

            foreach(var item in IMPORT_PRODUCT_DETAIL)
            {
                PRODUCT_CARTLIST tempProduct = new PRODUCT_CARTLIST();
                tempProduct.product = item.MAT_HANG;
                tempProduct.product_TotalPrice = (item.MAT_HANG.DON_GIA * item.SO_LUONG).ToString();
                tempProduct.product_Price = item.MAT_HANG.DON_GIA.ToString();

                IMPORTPRODUCTLISTDTG.Add(tempProduct);
            }    
        }
    }
}
