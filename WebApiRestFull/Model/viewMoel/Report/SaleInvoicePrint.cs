using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DisplayName("اصلاعات فاکتور")]
    public class SaleInvoicePrint
    {
        [DisplayName("اطلاعات اصلی فاکتور")]
        public SaleInvoice SaleInvoice { get; set; }

        [DisplayName("اقلام  فاکتور")]
        public List<SaleInvoiceDetaile> SaleInvoiceDetaile { get; set; }

        [DisplayName("اطلاعات مجموعه")]
        public tblCompany_Info Company { get; set; }

        [DisplayName("قابلیت ها")]
        public Setting SettingPrint { get; set; }

        public class Setting
        {
            [DisplayName("تاریخ امروز")]
            public string DateTimeToday { get; set; }
            [DisplayName("سخن")]
            public string Sokhan { get; set; }
            [DisplayName("متن مبلغ پرداختی")]
            public string PriceText { get; set; }
            [DisplayName("وضعیف سفارش")]
            public string StateSale { get; set; }
        }
    }
}
