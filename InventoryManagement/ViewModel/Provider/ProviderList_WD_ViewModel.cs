using InventoryManagement.Model;
using InventoryManagement.Model.PROVIDER;
using InventoryManagement.View.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Provider
{
    public class ProviderList_WD_ViewModel : BaseViewModel
    {
        #region Command Button
        public ICommand QuitCommand { get; set; }
        public ICommand DoubleClickSelectProviderCommand { get; set; }
        #endregion

        #region Binding TEXT
        private ObservableCollection<NHA_CUNG_CAP> _PROVIDERLIST;
        public ObservableCollection<NHA_CUNG_CAP> PROVIDERLIST { get => _PROVIDERLIST; set { _PROVIDERLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<PROVIDER> _PROVIDERLISTDTG;
        public ObservableCollection<PROVIDER> PROVIDERLISTDTG { get => _PROVIDERLISTDTG; set { _PROVIDERLISTDTG = value; OnPropertyChanged(); } }

        private PROVIDER _selectedProvider;
        public PROVIDER selectedProvider { get => _selectedProvider; set { _selectedProvider = value; OnPropertyChanged(); } }
        #endregion

        public ProviderList_WD_ViewModel()
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
                MessageBoxResult result = MessageBox.Show("Bạn chưa chọn nhà cung cấp!!!\nBạn có chắc chắn muốn thoát!!!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            DoubleClickSelectProviderCommand = new RelayCommand<ProviderList_WD>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (selectedProvider == null)
                {
                    return;
                }
                else
                {
                    p.Close();
                }
            });
            #endregion
        }

        public void LoadProviderList()
        {
            PROVIDERLIST = new ObservableCollection<NHA_CUNG_CAP>(DataProvider.Ins.DB.NHA_CUNG_CAP);
            PROVIDERLISTDTG = new ObservableCollection<PROVIDER>();

            foreach(var item in PROVIDERLIST)
            {
                PROVIDER temp_Provider = new PROVIDER();
                temp_Provider.provider = item;
                PROVIDERLISTDTG.Add(temp_Provider);
            }    

        }
    }
}
