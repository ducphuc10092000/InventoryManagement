using InventoryManagement.Model;
using InventoryManagement.View.Account;
using InventoryManagement.View.Export;
using InventoryManagement.View.Import;
using InventoryManagement.View.Inventory;
using InventoryManagement.View.Login;
using InventoryManagement.View.Product;
using InventoryManagement.ViewModel.Account;
using InventoryManagement.ViewModel.Export;
using InventoryManagement.ViewModel.Import;
using InventoryManagement.ViewModel.Inventory;
using InventoryManagement.ViewModel.Login;
using InventoryManagement.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        #region Account Logged in system
        private TAI_KHOAN _loggedAccount;
        public TAI_KHOAN loggedAccount { get => _loggedAccount; set { _loggedAccount = value; OnPropertyChanged(); } }

        #endregion

        //Xử lý ở đây
        #region Chức năng Button chuyển UC
        public enum CHUCNANG
        {
            DashBoard, ManageInventory, ManageProduct, ManageImport, ManageExport, ManageTransfer, ManageReport, ManageAccount, ManageSetting
        }
        private int _ChucNang;
        public int ChucNang { get => _ChucNang; set { _ChucNang = value; OnPropertyChanged(); } }
        #endregion

        #region Declare Binding Command
        public ICommand QuitCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public ICommand BtnDashBoardCommand { get; set; }
        public ICommand BtnManageProductCommand { get; set; }
        public ICommand BtnManageImportCommand { get; set; }
        public ICommand BtnManageExportCommand { get; set; }
        public ICommand BtnManageTransferCommand { get; set; }
        public ICommand BtnManageInventoryCommand { get; set; }
        public ICommand BtnManageReportCommand { get; set; }
        public ICommand BtnManageAccountCommand { get; set; }

        public ICommand BtnManageSettingCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            #region Handle Binding Command Swap UserControl
            BtnDashBoardCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.DashBoard;
            });
            BtnManageProductCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageProduct;
                //Load product LIST khi bấm vào button swap control, đỡ lag
                Product_UC product_UC = new Product_UC();
                var product_UC_DT = product_UC.DataContext as Product_UC_ViewModel;
                product_UC_DT.LoadProductList();
            });
            BtnManageImportCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageImport;

                //Load product LIST khi bấm vào button swap control, đỡ lag
                Import_UC import_UC = new Import_UC();
                var import_UC_DT = import_UC.DataContext as Import_UC_ViewModel;
                import_UC_DT.LoadImportBillList();
                import_UC_DT.LoggedInAccount = loggedAccount;
            });
            BtnManageExportCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageExport;

                //Load product LIST khi bấm vào button swap control, đỡ lag
                Export_UC export_UC = new Export_UC();
                var export_UC_DT = export_UC.DataContext as Export_UC_ViewModel;
                export_UC_DT.LoadExportBillList();
                export_UC_DT.LoggedInAccount = loggedAccount;
            });
            BtnManageInventoryCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageInventory;
                //Load product LIST khi bấm vào button swap control, đỡ lag
                Inventory_UC inventory_UC = new Inventory_UC();
                var inventory_UC_DT = inventory_UC.DataContext as Inventory_UC_ViewModel;
                inventory_UC_DT.LoadInventoryList();
            });
            BtnManageTransferCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageTransfer;
            });
            BtnManageReportCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageReport;
            });
            BtnManageAccountCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageAccount;

                //Load Rule Account
                Account_UC account_UC = new Account_UC();
                var account_UC_DT = account_UC.DataContext as Account_UC_ViewModel;
                account_UC_DT.CheckRule(Convert.ToInt32(loggedAccount.ID_LTK));
            });
            BtnManageSettingCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageSetting;
            });
            #endregion

            #region Handle Binding Command
            QuitCommand = new RelayCommand<MainWindow>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            LogOutCommand = new RelayCommand<MainWindow>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                    Login_WD loginWD = new Login_WD();
                    var loginWD_VM = loginWD.DataContext as Login_WD_ViewModel;
                    loginWD_VM.Load_login_WD();
                    loginWD.ShowDialog();
                }
                else
                {
                    return;
                }
            });
            #endregion
        }
    }
}
