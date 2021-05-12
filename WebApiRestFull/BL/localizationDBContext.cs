using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public static class localizationDBContext
    {

        public static ProductsRepository ProductRepo { get; set; }
        public static SaleInvoiceRepository SaleInvoiceRepo { get; set; }
        public static SettingRepository SettingRepo { get; set; }
        public static CustomersRepository CustomersRepo { get; set; }
        public static AccountingRepository AccRepo { get; set; }




        static localizationDBContext()
        {
            ProductRepo = new ProductsRepository();
            SaleInvoiceRepo = new SaleInvoiceRepository();
            SettingRepo = new SettingRepository();
            CustomersRepo = new CustomersRepository();
            AccRepo = new AccountingRepository();
        }
    }
}
