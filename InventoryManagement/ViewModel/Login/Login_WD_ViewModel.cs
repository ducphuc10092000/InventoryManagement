using InventoryManagement.Model;
using InventoryManagement.View.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Login
{
    public class Login_WD_ViewModel : BaseViewModel
    {
        #region Thuộc tính Binding
        private string _userName;
        public string userName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(userName)); } }

        public string _passWord;
        public string passWord { get => _passWord; set { _passWord = value; OnPropertyChanged(nameof(passWord)); } }

        public bool _isRegisted;
        public bool isRegisted { get => _isRegisted; set { _isRegisted = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand btnLoginCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }
        #endregion
        public Login_WD_ViewModel()
        {
            Load_login_WD();

            #region Handling command button
            btnLoginCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(passWord))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;

                }

                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(passWord))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Register_Login(p);
            });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            { return p == null ? false : true; }, (p) =>
            { passWord = p.Password; });

            #endregion

        }

        public void Register_Login(Window login_WD)
        {
            var account = DataProvider.Ins.DB.TAI_KHOAN.Where(x => x.TEN_DANG_NHAP == userName && x.MAT_KHAU == passWord).SingleOrDefault();

            if (account != null)
            {
                isRegisted = true;
            }
            else
            {
                isRegisted = false;
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (isRegisted == true)
            {

                login_WD.Hide();
                MainWindow mainWindow = new MainWindow();

                if (mainWindow.DataContext == null)
                    return;

                var mainVM = mainWindow.DataContext as MainViewModel;
                mainWindow.ShowDialog();


                login_WD.Close();
            }
        }

        public void Load_login_WD()
        {
            isRegisted = false;
            userName = "";
            passWord = "";
        }
    }
}
