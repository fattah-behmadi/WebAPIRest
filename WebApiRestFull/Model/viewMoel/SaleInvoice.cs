using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesMethod;

namespace Model
{
    public class SaleInvoice : TblParent_FrooshKala
    {
        [DisplayName("شماره فاکتور")]
        public long SaleInvoice_ID
        {
            get { return this.ForooshKalaParent_ID; }
            set { this.ForooshKalaParent_ID = value; }
        }

        [Browsable(false)]
        public long? Tafsil_ID
        {
            get
            {
                return this.ForooshKalaParent_Tafzili.ToLong();
            }
            set
            {
                this.ForooshKalaParent_Tafzili = value;
            }
        }

        [Browsable(false)]
        public System.DateTime SaleInvoiceDate { get { return this.ForooshKalaParent_Date.Value; } set { this.ForooshKalaParent_Date = value; } }

        [DisplayName("تاریخ شمسی فاکتور")]
        public string SaleInvoiceDate_SH
        {
            get
            {
                return this.SaleInvoiceDate.JulianToPersianDate();
            }
        }

        [DisplayName("ساعت سفارش")]
        public TimeSpan SaleTime
        {
            get
            {
                return this.ForooshKalaParent_Time.Value;
            }
            set
            {
                this.ForooshKalaParent_Time = value;
            }
        }

        [DisplayName("شرح فیش")]
        public string Description
        {
            get
            {
                if (this.ForooshKalaParent_Tozih == null)
                    return string.Empty;
                else
                    return this.ForooshKalaParent_Tozih;
            }
            set { this.ForooshKalaParent_Tozih = value; }
        }

        [DisplayName("مبلغ اصلی فاکتور")]
        /// <summary>
        /// مبلغ اصلی فاکتور
        /// </summary>
        public long SumPrice
        {
            get { return this.ForooshKalaParent_JameMablaghPaye.ToLong(); }
            set { this.ForooshKalaParent_JameMablaghPaye = value; }
        }


        /// <summary>
        /// مبلغ مالیات
        /// </summary>
        [DisplayName("مبلغ مالیات")]
        public long VatPrice
        {
            get { return this.ForooshKalaParent_JameMaliyat.ToLong(); }
            set
            {
                this.ForooshKalaParent_JameMaliyat = value;
            }
        }

        [DisplayName("مبلغ تخفیف")]
        /// <summary>
        /// مبلغ تخفیف
        /// </summary>
        public long DiscountPrice
        {
            get { return this.ForooshKalaParent_JameTakhfif.ToLong(); }
            set
            {
                this.ForooshKalaParent_JameTakhfif = value;
            }
        }

        [DisplayName("مبلغ خالص پرداختی")]
        /// <summary>
        /// مبلغ نهایی پس از محاسبه تخفیف و مالیات و سرویس
        /// </summary>
        public long NetPrice
        {
            get
            {
                var netprice = this.SumPrice - this.DiscountPrice.ToLong() + this.VatPrice.ToLong() + this.ServicePrice.ToLong();
                this.ForooshKalaParent_JameMablaghPasTakhfif = netprice;

                return netprice;
            }
            set
            {
                this.ForooshKalaParent_JameKol = value;
            }
        }

        [DisplayName("مبلغ سرویس")]
        /// <summary>
        /// مبلغ سرویس
        /// </summary>
        public long ServicePrice
        {
            get
            {
                return this.ForooshKalaParent_JameService.ToLong();
            }
            set { this.ForooshKalaParent_JameService = value; }
        }

        [DisplayName("کد صندوقدار")]
        public long UserID
        {
            get
            {
                return this.ForooshKalaParent_UserId.ToLong();

            }
            set { this.ForooshKalaParent_UserId = value; }
        }

        [Browsable(false)]
        public string GlID
        {
            get { return this.ForooshKalaParent_SerialSanad.ToInt().ToString(); }
            set { this.ForooshKalaParent_SerialSanad = value; }
        }

        [DisplayName("شماره میز")]
        public string NumDesk
        {
            get
            {
                return this.ForooshKalaParent_ShomareMiz;
            }
            set { this.ForooshKalaParent_ShomareMiz = value; }
        }

        [DisplayName("مدت انتظار")]
        public string WaitTime
        {
            get { return this.ForooshKalaParent_ModateEntezar; }

            set { this.ForooshKalaParent_ModateEntezar = value; }
        }

        [DisplayName("شماره فیش")]
        public long NumberOrder
        {
            get { return this.ForooshKalaParent_ShomareFish.ToLong(); }

            set { this.ForooshKalaParent_ShomareFish = value; }
        }


        [DisplayName("وضعیت ویرایش فاکتور")]
        /// <summary>
        /// وضعیت ویرایش فاکتور
        /// </summary>
        public string Edited
        {
            get { return this.ForooshKalaParent_StatusFact; }

            set { this.ForooshKalaParent_StatusFact = value; }
        }


        [DisplayName("نوع سفارش")]
        /// <summary>
        /// نوع سفارش که ایا بیرون بر است یا داخل سالن
        /// </summary>
        public string SaleInvoice_Type
        {
            get { return this.ForooshKalaParent_TypeFact; }

            set { this.ForooshKalaParent_TypeFact = value; }
        }

        [DisplayName("آدرس مشتری")]
        public string Address
        {
            get { return this.ForooshKalaParent_SelectedAdress; }

            set { this.ForooshKalaParent_SelectedAdress = value; }
        }

        [DisplayName("تلفن مشتری")]
        public string Tell
        {
            get { return this.ForooshKalaParent_SelectedTell; }

            set { this.ForooshKalaParent_SelectedTell = value; }
        }

        [DisplayName("مشتری")]
        public string CustomerFullName
        {
            get { return this.ForooshKalaParent_Tahvilgirande; }

            set { this.ForooshKalaParent_Tahvilgirande = value; }
        }

        [DisplayName("کد اشتراک مشتری")]
        public string CustomerCode { get; set; }

        [DisplayName("شماره پیجر")]
        public string NumberPager
        {
            get { return this.ForooshKalaParent_NumberPager; }

            set { this.ForooshKalaParent_NumberPager = value; }
        }

        [Browsable(false)]
        /// <summary>
        /// وضعیت تسویه
        /// </summary>
        public bool PaymentSaleInvoice
        {
            get { return this.ForooshKalaParent_TasvieFact.ToBool(); }

            set { this.ForooshKalaParent_TasvieFact = value; }
        }

        [DisplayName("وضعیت پرداخت")]
        public string CaptionPaymentSaleInvoice
        {
            get
            {
                if (this.PaymentSaleInvoice)
                {
                    return "فاکتور تسویه شده";
                }
                else
                {
                    return "فاکتور تسویه نشده";
                }

            }


        }

        [Browsable(false)]
        public Nullable<bool> IsReady
        {
            get { return this.ForooshKalaParent_Ready; }

            set { this.ForooshKalaParent_Ready = value; }
        }

        [Browsable(false)]
        public Nullable<bool> IsDelivery
        {
            get
            {
                return this.ForooshKalaParent_Delivery;
            }

            set
            {
                this.ForooshKalaParent_Delivery = value;
            }
        }

        [Browsable(false)]
        public List<SaleInvoiceDetaile> SaleInvoiceDetails { get; set; }


    }
}
