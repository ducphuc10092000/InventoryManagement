using InventoryManagement.Model;
using InventoryManagement.Model.IMPORTBILL;
using InventoryManagement.View.Import;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Import
{
    public class Import_UC_ViewModel : BaseViewModel
    {
        #region Command
        public ICommand Open_AddNewImportBill_WD_Command { get; set; }

        public ICommand Open_EditImportBill_WD_Command { get; set; }
        #endregion

        #region Binding TEXT
        private TAI_KHOAN _LoggedInAccount;
        public TAI_KHOAN LoggedInAccount { get => _LoggedInAccount; set { _LoggedInAccount = value; OnPropertyChanged(); } }


        private ObservableCollection<HOA_DON_NHAP> _IMPORTBILLLIST;
        public ObservableCollection<HOA_DON_NHAP> IMPORTBILLLIST { get => _IMPORTBILLLIST; set { _IMPORTBILLLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<IMPORTBILL> _IMPORTBILLLISTDTG;
        public ObservableCollection<IMPORTBILL> IMPORTBILLLISTDTG { get => _IMPORTBILLLISTDTG; set { _IMPORTBILLLISTDTG = value; OnPropertyChanged(); } }

        private IMPORTBILL _selectedImportBill;
        public IMPORTBILL selectedImportBill { get => _selectedImportBill; set { _selectedImportBill = value; OnPropertyChanged(); } }
        #endregion

        public Import_UC_ViewModel()
        {
            LoadImportBillList();
            #region Handling Import_UC Command
            Open_AddNewImportBill_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewImportBill_WD addNewImportBill_WD = new AddNewImportBill_WD();
                //Reset before show
                var addNewImportBill_WD_DT = addNewImportBill_WD.DataContext as AddNewImportBill_WD_ViewModel;
                addNewImportBill_WD_DT.ResetTextboxProduct();
                addNewImportBill_WD_DT.ResetBill();
                addNewImportBill_WD_DT.LoggedInAccount = LoggedInAccount;

                addNewImportBill_WD.ShowDialog();
                addNewImportBill_WD.Close();

                LoadImportBillList();
            });

            Open_EditImportBill_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditImportBill_WD editImportBill_WD = new EditImportBill_WD();
                //Reset before show
                var editImportBill_WD_DT = editImportBill_WD.DataContext as AddNewImportBill_WD_ViewModel;

                editImportBill_WD_DT.LoggedInAccount = LoggedInAccount;
                editImportBill_WD_DT.SelectedImportBill = selectedImportBill;
                editImportBill_WD_DT.LoadSelectedImportBill();
                editImportBill_WD_DT.LoggedInAccount = LoggedInAccount;
                editImportBill_WD.ShowDialog();
                editImportBill_WD.Close();

                LoadImportBillList();
            });

            #endregion
        }

        public void LoadImportBillList()
        {
            IMPORTBILLLIST = new ObservableCollection<HOA_DON_NHAP>(DataProvider.Ins.DB.HOA_DON_NHAP);
            IMPORTBILLLISTDTG = new ObservableCollection<IMPORTBILL>();

            foreach(var item in IMPORTBILLLIST)
            {
                IMPORTBILL temp_importbill = new IMPORTBILL();
                temp_importbill.hoaDonNhap = item;

                IMPORTBILLLISTDTG.Add(temp_importbill);
            }    
        }
    }
}
