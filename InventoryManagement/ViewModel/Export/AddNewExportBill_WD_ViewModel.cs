using InventoryManagement.Model;
using InventoryManagement.Model.EXPORTBILL;
using InventoryManagement.Model.INVENTORY;
using InventoryManagement.Model.PRODUCT;
using InventoryManagement.View.Inventory;
using InventoryManagement.View.Product;
using InventoryManagement.ViewModel.Inventory;
using InventoryManagement.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Export
{
    public class AddNewExportBill_WD_ViewModel : BaseViewModel
    {
        #region Bool to check filled
        private bool _isSelectedProduct;
        public bool isSelectedProduct { get => _isSelectedProduct; set { _isSelectedProduct = value; OnPropertyChanged(); } }

        private bool _isSelectedInventory;
        public bool isSelectedInventory { get => _isSelectedInventory; set { _isSelectedInventory = value; OnPropertyChanged(); } }

        private bool _isFilledAll;
        public bool isFilledAll { get => _isFilledAll; set { _isFilledAll = value; OnPropertyChanged(); } }

        #endregion

        #region Binding TEXT AddNewExportBill_WD
        private double _SumaryExportBillCost;
        public double SumaryExportBillCost { get => _SumaryExportBillCost; set { _SumaryExportBillCost = value; OnPropertyChanged(); } }

        private ObservableCollection<PRODUCT_CARTLIST> _EXPORTPRODUCTLISTDTG;
        public ObservableCollection<PRODUCT_CARTLIST> EXPORTPRODUCTLISTDTG { get => _EXPORTPRODUCTLISTDTG; set { _EXPORTPRODUCTLISTDTG = value; OnPropertyChanged(); } }

        private TAI_KHOAN _LoggedInAccount;
        public TAI_KHOAN LoggedInAccount { get => _LoggedInAccount; set { _LoggedInAccount = value; OnPropertyChanged(); } }

        private string _InventoryName;
        public string InventoryName { get => _InventoryName; set { _InventoryName = value; OnPropertyChanged(); } }

        private INVENTORY _SelectedInventory;
        public INVENTORY SelectedInventory { get => _SelectedInventory; set { _SelectedInventory = value; OnPropertyChanged(); } }
        
        private string _ReceiverName;
        public string ReceiverName { get => _ReceiverName; set { _ReceiverName = value; OnPropertyChanged(); } }

        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private string _ProductPrice;
        public string ProductPrice { get => _ProductPrice; set { _ProductPrice = value; OnPropertyChanged(); } }

        private string _ProductQuantity;
        public string ProductQuantity { get => _ProductQuantity; set { _ProductQuantity = value; OnPropertyChanged(); } }

        private string _ExportDayTimeString;
        public string ExportDayTimeString { get => _ExportDayTimeString; set { _ExportDayTimeString = value; OnPropertyChanged(); } }

        private PRODUCT_CARTLIST _SelectedProduct;
        public PRODUCT_CARTLIST SelectedProduct { get => _SelectedProduct; set { _SelectedProduct = value; OnPropertyChanged(); } }
        #endregion
        #region Declare Command
        public ICommand QuitCommand { get; set; }
        public ICommand Open_InventoryList_WD_Command { get; set; }
        public ICommand Open_ProductList_WD_Command { get; set; }
        public ICommand AddProductToExportListCommand { get; set; }
        public ICommand ResetExportBillCommand { get; set; }
        public ICommand CreateExportBillCommand { get; set; }
        public ICommand DeleteProductFromCartListCommand { get; set; }
        #endregion

        public AddNewExportBill_WD_ViewModel()
        {
            isSelectedProduct = false;
            isSelectedInventory = false;
            isFilledAll = false;
            EXPORTPRODUCTLISTDTG = new ObservableCollection<PRODUCT_CARTLIST>();
            SumaryExportBillCost = 0;

            CreateExportBillCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn tạo hóa đơn?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    EXPORTBILL exportBill = new EXPORTBILL();
                    ExportDayTimeString = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    exportBill.AddNewExportBill(SelectedInventory.kho.ID_KHO, LoggedInAccount.ID_TK, ExportDayTimeString, SumaryExportBillCost.ToString(), EXPORTPRODUCTLISTDTG);

                    MessageBox.Show("Tạo hóa đơn xuất hàng thành công!!!", "Chúc mừng", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    ResetTextboxInventoryName();
                    p.Close();
                }
                else
                {
                    return;
                }
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
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ResetTextboxInventoryName();
                    p.Close();
                }
                else
                {
                    return;
                }
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
                productList_WD_DT.LoadProductListBaseID(SelectedInventory.kho.ID_KHO);

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
            AddProductToExportListCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                SelectedProduct.quantity = Convert.ToInt32(ProductQuantity);
                SelectedProduct.product_Price = ProductPrice;
                SelectedProduct.product_TotalPrice = (SelectedProduct.quantity * Convert.ToInt64(SelectedProduct.product_Price)).ToString();

                //SL lần 1 chọn đã lớn hơn
                if(Convert.ToInt16(ProductQuantity) > SelectedProduct.product.SO_LUONG_TON)
                {
                    MessageBox.Show("Không thể xuất kho mặt hàng này vì số lượng xuất vượt quá số lượng tồn!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }    


                //Sản phẩm đã tồn tại trong giỏ hàng
                if (EXPORTPRODUCTLISTDTG.Where(x => x.product == SelectedProduct.product).SingleOrDefault() != null)
                {
                    //Loop lấy item cần thay đổi
                    foreach (var item in EXPORTPRODUCTLISTDTG)
                    {
                        if (item.product.ID_MAT_HANG == SelectedProduct.product.ID_MAT_HANG)
                        {
                            if(item.quantity >= SelectedProduct.product.SO_LUONG_TON)
                            {
                                MessageBox.Show("Không thể xuất kho mặt hàng này vì số lượng xuất vượt quá số lượng tồn!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }    

                            //Nếu khác giá
                            if (ProductPrice != item.product_Price)
                            {
                                MessageBoxResult result = MessageBox.Show("Đơn giá xuất này khác với đơn giá xuất cũ, bạn chắc chắn muốn thay đổi đơn giá nhập?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

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
                        SumaryExportBillCost += Convert.ToDouble(item.product_TotalPrice);
                        isSelectedProduct = false;
                    }

                    return;
                }
                else
                {
                    EXPORTPRODUCTLISTDTG.Add(SelectedProduct);
                    SumaryExportBillCost += Convert.ToDouble(SelectedProduct.product_TotalPrice);
                    isSelectedProduct = false;
                    ResetTextboxProduct();

                }
                if (isFilledAll == false)
                {
                    if (EXPORTPRODUCTLISTDTG.Count() != 0)
                    {
                        if (isSelectedInventory == true)
                        {
                            isFilledAll = true;
                        }
                    }
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
                    foreach (var item in EXPORTPRODUCTLISTDTG)
                    {
                        if (item.product.ID_MAT_HANG == Convert.ToInt32(p))
                        {
                            EXPORTPRODUCTLISTDTG.Remove(item);
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
            ResetExportBillCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Những thông tin bạn nhập có thể chưa được lưu!!!\nBạn có chắc chắn muốn đặt lại!!!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ResetTextboxInventoryName();
                    ResetTextboxProduct();
                    ResetBill();
                }
                else
                {
                    return;
                }
            });
        }

        public void ResetTextboxInventoryName()
        {
            InventoryName = "";
            SelectedInventory = null;
        }
        public void ResetTextboxProduct()
        {
            ProductName = "";
            ProductPrice = "";
            ProductQuantity = "";
        }
        public void ResetBill()
        {
            isFilledAll = false;
            isSelectedInventory = false;
            isSelectedProduct = false;
            EXPORTPRODUCTLISTDTG = new ObservableCollection<PRODUCT_CARTLIST>();
            SumaryExportBillCost = 0;
            ResetTextboxInventoryName();
            ResetTextboxProduct();
        }
        public void CalculateCost()
        {

        }
    }
}
