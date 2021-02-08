using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UtilitiesMethod;

namespace Model
{
    public class SaleInvoiceDetaile : TblChild_ForooshKala
    {

        [Browsable(false)]
        public long SaleInvoiceDetaile_ID
        {
            get { return this.ChildForooshKala_ID; }
            set { this.ChildForooshKala_ID = value; }
        }
        [Browsable(false)]
        public long Product_ID
        {
            get { return this.ChildForooshKala_KalaID; }
            set { this.ChildForooshKala_KalaID = value; }
        }

        [Browsable(false)]
        public long SaleInvoice_ID
        {
            get { return this.ChildForooshKala_ParentID.ToLong(); }
            set { this.ChildForooshKala_ParentID = value; }
        }

        [DisplayName("توضیحات")]
        public string Description
        {
            get {
                if (this.ChildForooshKala_SharhKala == null)
                    return string.Empty;
                else
                return this.ChildForooshKala_SharhKala;
            }
            set { this.ChildForooshKala_SharhKala = value; }
        }

        [DisplayName("تعداد")]
        public double Qty
        {
            get { return this.ChildForooshKala_TedadAsli.ToDouble(); }
            set
            {
                this.ChildForooshKala_TedadAsli = value;
                this.ChildForooshKala_JameMablagh = (value * this.Price).ToLong();

            }
        }

        [DisplayName("فی")]
        public long Price
        {
            get { return this.ChildForooshKala_GheymatPaye.ToLong(); }
            set
            {
                this.ChildForooshKala_GheymatPaye = value;
            }
        }

        [DisplayName("جمع کل")]
        public long SumPrice
        {
            get
            {
                var sum = (this.Price.ToLong() * this.Qty.ToLong());
                this.ChildForooshKala_JameMablagh = sum;
                return sum;
            }

        }

        [DisplayName("مبلغ تخفیف")]
        public long DiscountPrice
        {
            get { return ((this.DiscountPercent.ToDouble() * this.SumPrice) / 100).ToLong(); }
        }


        [DisplayName("درصد تخفیف")]
        public double DiscountPercent
        {
            get { return this.ChildForooshKala_TakhfifDarsad.ToDouble(); }
            set
            {
                this.ChildForooshKala_TakhfifDarsad = value;
                this.ChildForooshKala_TakhfifMablagh = this.DiscountPrice;
            }
        }


        [DisplayName("مبلغ خالص")]
        /// <summary>
        /// مبلغ خالص محصول پس از محاسبه تخفیف ، مالیات
        /// </summary>
        public long NetPrice
        {
            get
            {
                var netprice = ((this.Price.ToLong() + this.VatPrice.ToLong()) - this.DiscountPrice.ToLong()) * this.Qty.ToLong();
                this.ChildForooshKala_JameKol = netprice;
                return netprice;
            }
        }


        [DisplayName("مبلغ مالیات")]
        public long VatPrice
        {
            get
            {
                return ((this.VatPercent.ToDouble() * this.SumPrice) / 100).ToLong();
            }

        }

        [DisplayName("درصد مالیات")]
        public double VatPercent
        {
            get { return this.ChildForooshKala_MaliyatDarsad.ToDouble(); }
            set
            {
                this.ChildForooshKala_MaliyatDarsad = value;
                this.ChildForooshKala_MaliyatMablagh = this.VatPrice;
            }
        }

        [Browsable(false)]
        public TblKala Product
        {
            get { return this.TblKala; }
            set { this.TblKala = value; }
        }
    }
}
