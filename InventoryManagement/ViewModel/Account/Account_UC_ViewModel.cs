using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManagement.ViewModel.Account
{
    public class Account_UC_ViewModel : BaseViewModel
    {

        #region Declare Button Command
        //public ICommand sth { get; set; }
        #endregion

        #region Binding TEXT Account_UC
        private int _isAdmin;
        public int isAdmin { get => _isAdmin; set { _isAdmin = value; OnPropertyChanged(); } }

        private TAI_KHOAN _loggedAccount;
        public TAI_KHOAN loggedAccount { get => _loggedAccount; set { _loggedAccount = value; OnPropertyChanged(); } }


        #endregion
        public Account_UC_ViewModel()
        {

        }

        public void CheckRule(int loggedAccountRule)
        {
            if(loggedAccountRule == 1)
            {
                isAdmin = 1;
            }    
            else
            {
                isAdmin = 0;
            }    
        }
    }
}
