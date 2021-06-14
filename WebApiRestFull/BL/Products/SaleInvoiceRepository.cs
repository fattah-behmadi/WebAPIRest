using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using UtilitiesMethod;

namespace BL
{
    public class SaleInvoiceRepository
    {
        AccountingRepository acc;
        SettingRepository settingRepo;

        internal GenericRepository<TblParent_FrooshKala> SaleInvoiceRepo { get; set; }
        internal GenericRepository<TblChild_ForooshKala> SaleInvoiceDetaileRepo { get; set; }
        internal GenericRepository<Vw_PrintFroosh> vwSaleInvoicePrint { get; set; }


        public SaleInvoiceRepository()
        {
            acc = new AccountingRepository();
            settingRepo = new SettingRepository();
            SaleInvoiceRepo = new GenericRepository<TblParent_FrooshKala>(DBAccess.GetNewContext());
            SaleInvoiceDetaileRepo = new GenericRepository<TblChild_ForooshKala>(DBAccess.GetNewContext());
            vwSaleInvoicePrint = new GenericRepository<Vw_PrintFroosh>(DBAccess.GetNewContext());
        }


        #region SaleInvoice

        /// <summary>
        /// شماره فاکتور جدید
        /// </summary>
        /// <returns></returns>
        long GetNewSaleInvoice_ID()
        {
            string sql = string.Format($@"
                                                select	ISNULL(
                                                 (SELECT   max([ForooshKalaParent_ID]) FROM  [dbo].[TblParent_FrooshKala]),			
                                                (select isnull(StartID,0)-1 from tblSettingIDFactor)
                                                )  + (select isnull(Increment,1) from tblSettingIDFactor ) as SaleInvoice_ID
                                                ");
            var dt = this.SaleInvoiceRepo.SqlQueryGetData(sql);
            var result = dt.First_DataTableToClass<SaleInvoice>();
            return result.SaleInvoice_ID;
        }
        /// <summary>
        /// دریافت شماره فیش جدید
        /// </summary>
        /// <returns></returns>
        long GetNewNumberOrder()
        {
            var result = SaleInvoiceRepo.RunProcedure("Sp_GetFishNumber", "FishNumber");
            return result.ToLong();
        }
        public bool InsertSaleInvoice(SaleInvoice saleinvoice)
        {
            saleinvoice.SaleInvoice_ID = this.GetNewSaleInvoice_ID();
            saleinvoice.NumberOrder = this.GetNewNumberOrder();
            saleinvoice.SaleInvoiceDate = DateTime.Now;
            saleinvoice.SaleTime = DateTime.Now.TimeOfDay;
            saleinvoice.GlID = this.acc.GetNewGLID().ToString();

            return SaleInvoiceRepo.Insert(saleinvoice.CopyCalss<TblParent_FrooshKala>()).ToBool();
        }
        public bool UpdateSaleInvoice(SaleInvoice saleinvoice)
        {
            TblParent_FrooshKala saleEntity = saleinvoice.Mapper<SaleInvoice, TblParent_FrooshKala>();
            return SaleInvoiceRepo.Update(saleinvoice.SaleInvoice_ID, saleEntity).ToBool();
        }

        /// <summary>
        /// حذف فاکتور فروش و اقلام آن
        /// </summary>
        /// <param name="_SaleInvoiceID">شماره فاکتور</param>
        /// <returns>اگر 1 بود حذف شده است</returns>
        public int DeleteSaleInvoice(long _SaleInvoiceID)
        {
            var saleinvoice = SaleInvoiceRepo.Find(_SaleInvoiceID);
            if (DeleteSaleDetaileBy_SaleInvoiceID(_SaleInvoiceID))
            {

                return SaleInvoiceRepo.Delete(saleinvoice);
            }
            else return 0;
        }

        /// <summary>
        /// جستجو بر اساس شماره فاکتور
        /// </summary>
        /// <param name="_SaleInvoiceID">شماره فاکتور</param>
        /// <returns></returns>
        public SaleInvoice GetSaleInvoice(long _SaleInvoiceID)
        {
            TblParent_FrooshKala result = SaleInvoiceRepo.FindBySingle(c => c.ForooshKalaParent_ID == _SaleInvoiceID);
            var saleinvoice = result.Mapper<TblParent_FrooshKala, SaleInvoice>();
            return saleinvoice;
        }
        /// <summary>
        /// دریافت تعداد اخرین فاکتورهای فروش
        /// </summary>
        /// <param name="count">تعداد فاکتورهای بازگشتی</param>
        /// <returns></returns>
        public List<SaleInvoice> GetLastSaleInvoice(int count)
        {
            DateTime nowDate = DateTime.Now.ToString("yyyy-MM-dd").ToDateTime();
            DateTime yesterday = nowDate.AddDays(-1);

            TblParent_FrooshKala saleinvoice = SaleInvoiceRepo.FindByLasted(c =>
                                                            c.ForooshKalaParent_Date.Value >= yesterday &&
                                                             c.ForooshKalaParent_Date.Value <= nowDate
                                                             , o => o.ForooshKalaParent_Date.Value, 1
                                                            ).FirstOrDefault();

            return saleinvoice.MapperList<TblParent_FrooshKala, SaleInvoice>();
        }

        /// <summary>
        /// جستجو بر اساس شماره فیش و تاریخ سفارش
        /// </summary>
        /// <param name="NumberOrdersaleinvoice">شماره فیش</param>
        /// <param name="datetime">تاریخ سفارش</param>
        /// <returns></returns>
        public SaleInvoice GetSaleInvoice(long NumberOrdersaleinvoice, DateTime datetime)
        {
            DateTime nowDate = datetime.ToString("yyyy-MM-dd").ToDateTime();
            DateTime yesterday = nowDate.AddDays(-1);

            TblParent_FrooshKala saleinvoice = SaleInvoiceRepo.FindByLasted(c =>

                                                            c.ForooshKalaParent_ShomareFish == NumberOrdersaleinvoice &&
                                                            c.ForooshKalaParent_Date.Value >= yesterday &&
                                                             c.ForooshKalaParent_Date.Value <= nowDate
                                                             , o => o.ForooshKalaParent_Date.Value, 1
                                                            ).FirstOrDefault();

            return saleinvoice.Mapper<TblParent_FrooshKala, SaleInvoice>();

        }


        public SaleInvoice CancelSaleInvoice(long _saleInvoice_ID, long GL_ID, int UserID)
        {
            if (acc.DeleteGL_ByID(GL_ID))
            {
                var user = settingRepo.GetUser(UserID);
                var saleInvoice = this.GetSaleInvoice(_saleInvoice_ID);

                saleInvoice.Description = string.Format($"لغو فاکتور توسط کاربر {user.Login_Name} ");
                saleInvoice.Edited = "لغو";
                saleInvoice.UserID = UserID;
                var result = this.UpdateSaleInvoice(saleInvoice);
                if (result == 1)
                    return saleInvoice;
                else return null;
            }
            else
                return null;
        }

        #endregion

        #region SaleInvoiceDetails

        public bool InsertSaleDetailes(List<SaleInvoiceDetaile> detailes)
        {
            if (detailes == null) return 0;
            var _detaile = detailes.CopyCalss<List<TblChild_ForooshKala>>();
            return SaleInvoiceDetaileRepo.InsertAll(_detaile).ToBool();

        }
        public int UpdateSaleDetailes(List<SaleInvoiceDetaile> detailes)
        {
            var result = this.DeleteSaleDetaileBy_SaleInvoiceID(detailes.FirstOrDefault().ChildForooshKala_ParentID.ToLong());
            if (result)
            {
                var _detaile = detailes.MapperList<SaleInvoiceDetaile, TblChild_ForooshKala>();
                _detaile.Select(c => c.TblKala = null).ToList();

                return SaleInvoiceDetaileRepo.InsertAll(_detaile);
            }
            else return 0;

        }

        /// <summary>
        /// حذف اقلام فاکتور 
        /// </summary>
        /// <param name="saleInvoiceID">شماره فاکتور</param>
        /// <returns></returns>
        public bool DeleteSaleDetaileBy_SaleInvoiceID(long saleInvoiceID)
        {
            string sql = string.Format($@"
                    DELETE FROM TblChild_ForooshKala 
                    WHERE ChildForooshKala_ParentID = {saleInvoiceID}
                    ");
            return SaleInvoiceDetaileRepo.SqlQuery(sql);
        }
        public List<SaleInvoiceDetaile> GetSaleInvoiceDetaile(long _SaleInvoiceID)
        {
            var result = SaleInvoiceDetaileRepo.FindByInclude(c => c.ChildForooshKala_ParentID == _SaleInvoiceID, x => x.TblKala);
            List<SaleInvoiceDetaile> list = result.MapperList<TblChild_ForooshKala, SaleInvoiceDetaile>();
            return list;

        }



        #endregion

        #region Print

        /// <summary>
        /// دریافت اطلاعات یک فاکتور برای چاپ
        /// </summary>
        /// <param name="_SaleInvoiceID"></param>
        /// <returns></returns>
        public SaleInvoicePrint PrintSaleInvoice(long _SaleInvoiceID)
        {
            SaleInvoicePrint print = new SaleInvoicePrint();
            print.SaleInvoice = this.GetSaleInvoice(_SaleInvoiceID);
            if (print.SaleInvoice != null)
            {
                var result = localizationDBContext.CustomersRepo.GetCustomer_ByTafsil(print.SaleInvoice.Tafsil_ID.ToLong());
                if (result != null)
                    print.SaleInvoice.CustomerCode = result.Contacts_ID.ToString();
            }
            print.SaleInvoiceDetaile = this.GetSaleInvoiceDetaile(_SaleInvoiceID);
            print.Company = localizationDBContext.SettingRepo.GetCompany();
            return print;

        }

        public List<Vw_PrintFroosh> GetSaleInvoicePrint(long SaleInvoiceID)
        {
            return this.vwSaleInvoicePrint.FindAll(c => c.ForooshKalaParent_ID == SaleInvoiceID).ToList();
        }

        #endregion

    }
}
