using InventoryManagement.Model;
using InventoryManagement.Model.EXPORTBILL;
using InventoryManagement.View.Export;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Export
{
    public class Export_UC_ViewModel : BaseViewModel
    {
        #region Binding TEXT
        private TAI_KHOAN _LoggedInAccount;
        public TAI_KHOAN LoggedInAccount { get => _LoggedInAccount; set { _LoggedInAccount = value; OnPropertyChanged(); } }


        private ObservableCollection<HOA_DON_XUAT> _EXPORTBILLLIST;
        public ObservableCollection<HOA_DON_XUAT> EXPORTBILLLIST { get => _EXPORTBILLLIST; set { _EXPORTBILLLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<EXPORTBILL> _EXPORTBILLLISTDTG;
        public ObservableCollection<EXPORTBILL> EXPORTBILLLISTDTG { get => _EXPORTBILLLISTDTG; set { _EXPORTBILLLISTDTG = value; OnPropertyChanged(); } }

        private EXPORTBILL _selectedExportBill;
        public EXPORTBILL selectedExportBill { get => _selectedExportBill; set { _selectedExportBill = value; OnPropertyChanged(); } }

        private string _exportBillIDFind;
        public string exportBillIDFind { get => _exportBillIDFind; set { _exportBillIDFind = value; OnPropertyChanged(); } }

        private string _inventoryNameFind;
        public string inventoryNameFind { get => _inventoryNameFind; set { _inventoryNameFind = value; OnPropertyChanged(); } }

        private string _DayStart_ExportBill;
        public string DayStart_ExportBill { get => _DayStart_ExportBill; set { _DayStart_ExportBill = value; OnPropertyChanged(); } }

        private string _DayEnd_ExportBill;
        public string DayEnd_ExportBill { get => _DayEnd_ExportBill; set { _DayEnd_ExportBill = value; OnPropertyChanged(); } }
        #endregion
        #region Command
        public ICommand ExportBillFindCommand { get; set; }
        public ICommand ExportBillDefaultFilterCommand { get; set; }
        public ICommand Open_AddNewExportBill_WD_Command { get; set; }
        public ICommand Open_EditExportBill_WD_Command { get; set; }
        #endregion

        public Export_UC_ViewModel()
        {
            #region Handling Export_UC Command
            Open_AddNewExportBill_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewExportBill_WD addNewExportBill_WD = new AddNewExportBill_WD();
                var addNewExportBill_WD_DT = addNewExportBill_WD.DataContext as AddNewExportBill_WD_ViewModel;
                addNewExportBill_WD_DT.ResetBill();
                addNewExportBill_WD_DT.LoggedInAccount = LoggedInAccount;
                addNewExportBill_WD.ShowDialog();
                addNewExportBill_WD.Close();
            });

            #endregion
        }

        public void LoadExportBillList()
        {
            EXPORTBILLLIST = new ObservableCollection<HOA_DON_XUAT>(DataProvider.Ins.DB.HOA_DON_XUAT);
            EXPORTBILLLISTDTG = new ObservableCollection<EXPORTBILL>();
            foreach(var item in EXPORTBILLLIST)
            {
                EXPORTBILL tempExportBill = new EXPORTBILL();
                tempExportBill.hoaDonXuat = item;
                EXPORTBILLLISTDTG.Add(tempExportBill);
            }    
        }
    }
}
