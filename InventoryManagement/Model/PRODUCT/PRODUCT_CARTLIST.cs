using InventoryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.PRODUCT
{
    public class PRODUCT_CARTLIST : BaseViewModel
    {
        public MAT_HANG product { get; set; }

        private int _quantity;
        public int quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(); } }

        private string _product_Price;
        public string product_Price { get => _product_Price; set { _product_Price = value; OnPropertyChanged(); } }

        private string _product_TotalPrice;
        public string product_TotalPrice { get => _product_TotalPrice; set { _product_TotalPrice = value; OnPropertyChanged(); } }

        private string _Decription;
        public string Decription { get => _Decription; set { _Decription = value; OnPropertyChanged(); } }


        public PRODUCT_CARTLIST()
        {
            //Setup first Quantity = 1 when import PRODUCT
            quantity = 1;
        }
    }
}
