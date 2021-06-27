using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using UtilitiesMethod;

namespace BL
{
    public class AccountingRepository
    {

        tblCompany_Info _companyCashing;
        List<tblSettingAcc> _settingAccCashing;
        tblSettingAcc DtSanad, DtDaryaft, DtKhadamat, DtArzeshAfzode, DtTakhfifForosh;


        internal GenericRepository<tblSettingAcc> SettingAccRepo { get; set; }
        internal GenericRepository<tblTafzili> tafsilRepo { get; set; }

        internal GenericRepository<tblChildeSanad> GLDetaile { get; set; }
        internal GenericRepository<tblParentSanad> GL { get; set; }


        public AccountingRepository()
        {
            tafsilRepo = new GenericRepository<tblTafzili>(DBAccess.GetNewContext());
            GLDetaile = new GenericRepository<tblChildeSanad>(DBAccess.GetNewContext());
            GL = new GenericRepository<tblParentSanad>(DBAccess.GetNewContext());
            SettingAccRepo = new GenericRepository<tblSettingAcc>(DBAccess.GetNewContext());
        }

        #region GL


        public List<tblSettingAcc> GetSettingAccAll()
        {
            if (_settingAccCashing == null)
                _settingAccCashing = SettingAccRepo.All().ToList();
            return _settingAccCashing;
        }

        /// <summary>
        /// دریافت جزئیات سند
        /// </summary>
        /// <param name="_glID"></param>
        /// <returns></returns>
        public List<tblChildeSanad> GetGlDetaile(long _glID)
        {
            return GLDetaile.FindAll(c => c.Serial_Sanad == _glID).ToList();
        }

        public bool InserGLDetaile(long glID, int? acc_ID_Debtor, int? tafsil_ID, int? moin_ID_Creditor, string description, long ActionID, int ActionTypeID, long DebtorPrice, long CreditorPrice)
        {
            tblChildeSanad gld = new tblChildeSanad();
            gld.Serial_Sanad = glID;
            gld.AccountsID = acc_ID_Debtor;
            gld.Tafzili_ID = tafsil_ID;
            gld.Moein_ID = moin_ID_Creditor;
            gld.Sharh_Child_Sanad = description;
            gld.ID_Amaliyat = ActionID;
            gld.ID_TypeAmaliyat = ActionTypeID;
            gld.Bedehkar = DebtorPrice;
            gld.Bestankar = CreditorPrice;
            return this.GLDetaile.Insert(gld).ToBool();
        }

        /// <summary>
        /// حذف جزئیات سند
        /// </summary>
        /// <param name="_glID"></param>
        /// <returns></returns>
        public bool DeleteGlDetaile(long _glID)
        {
            return GLDetaile.SqlQuery(string.Format($"delete  FROM tblChildeSanad  where Serial_Sanad={_glID}")).ToBool();
        }

        /// <summary>
        /// دریافت سند
        /// </summary>
        /// <param name="_glID"></param>
        /// <returns></returns>
        public tblParentSanad GetGl(long _glID)
        {
            return GL.FindByCondition(c => c.Serial_Sanad == _glID);
        }
        public bool InsertGL(tblParentSanad gl)
        {
            return GL.Insert(gl).ToBool();
        }
        public bool Update_GL(tblParentSanad gl)
        {
            return GL.Update(gl.Serial_Sanad, gl).ToBool();
        }


        /// <summary>
        /// حذف سند
        /// </summary>
        /// <param name="_glID"></param>
        /// <returns></returns>
        public bool DeleteGl(long _glID)
        {
            return GL.SqlQuery(string.Format($"delete  FROM tblParentSanad  where Serial_Sanad={_glID}")).ToBool();
        }
        /// <summary>
        /// شماره سند جدید
        /// </summary>
        /// <returns></returns>
        public long GetNewGLID()
        {
            string sql = "SELECT isnull(MAX([Serial_Sanad]),0) + 1  FROM [tblParentSanad]";
            var dt = this.GL.SqlQueryGetData(sql);
            var res = dt.Rows[0][0];
            return res.ToLong();

        }
        /// <summary>
        /// شماره عدد سند جدید
        /// </summary>
        /// <returns></returns>
        public long GetNewGLNumber()
        {
            string sql = "SELECT isnull(MAX([Serial_Sanad]),0) + 1  FROM [tblParentSanad]";
            var dt = this.GL.SqlQueryGetData(sql);
            var res = dt.Rows[0][0];
            return res.ToLong();
        }

        /// <summary>
        /// حذف کلیه اسناد حسابداری با شماره سند
        /// </summary>
        /// <param name="_glID">شماره سند</param>
        /// <returns></returns>
        public bool DeleteGL_ByID(long _glID)
        {
            if (this.DeleteGlDetaile(_glID))
            {
                return this.DeleteGl(_glID);
            }
            else return false;
        }

        /// <summary>
        /// دریافت تنظیمات سند حسابداری
        /// </summary>
        void GetSettingAcc()
        {
            var _listSettinAcc = this.GetSettingAccAll();
            if (_listSettinAcc != null)
            {
                DtSanad = _listSettinAcc.Where(c => c.NameAcc == "فروش").SingleOrDefault();
                DtKhadamat = _listSettinAcc.Where(c => c.NameAcc == "خدمات حین فروش").SingleOrDefault();
                DtArzeshAfzode = _listSettinAcc.Where(c => c.NameAcc == "ارزش افزوده فروش").SingleOrDefault();
                DtTakhfifForosh = _listSettinAcc.Where(c => c.NameAcc == "تخفیف فروش").SingleOrDefault();
                DtDaryaft = _listSettinAcc.Where(c => c.NameAcc == "دریافت نقدی صندوق").SingleOrDefault();
            }
        }
        /// <summary>
        /// ثبت سند حسابداری فاکتور
        /// </summary>
        /// <param name="saleinvoice"></param>
        public void SaveGL_SaleInvoice(SaleInvoice saleinvoice)
        {
            this.GetSettingAcc();
            var glNumber = this.GetNewGLNumber();
            var glID = this.GetNewGLID();
            string description = String.Format("فاکتور فروش به شماره {0}  ", saleinvoice.SaleInvoice_ID);

            int? TafziliIDBedehkar = DtSanad.Tafzili_ID_Bedehkar;
            var TafziliIDBes = DtSanad.Tafzili_ID_Bestankar;
            var TafziliIDKhadamatBedehkar = DtKhadamat.Tafzili_ID_Bedehkar;
            var TafziliIDKhadamatBes = DtKhadamat.Tafzili_ID_Bestankar;

            #region GL
            var GL = this.GetGl(saleinvoice.GlID.ToLong());
            if (GL == null)
            {
                GL = new tblParentSanad();
                GL.Serial_Sanad = glID;
                GL.Number_Sanad = glNumber;
                GL.Time_Sanad = DateTime.Now.ToString("HH:mm");
                GL.Exption_Sanad = string.Format($"فاکتور فروش با تبلت به شماره فاکتور {saleinvoice.SaleInvoice_ID}");
                GL.Date_Sanad = DateTime.Now;
                GL.User_ID = saleinvoice.UserID.ToInt();
                GL.StatusSanadID = 3;
                GL.TypeSanad_ID = 4;
                GL.Taraz_Sanad = true;
                GL.Date_Modify = null;
                GL.Deleted_Sanad = null;
                GL.Error_Sanad = null;
                this.InsertGL(GL);
            }
            else
            {
                GL.Date_Modify = DateTime.Now;
                GL.Exption_Sanad = saleinvoice.Description;
                GL.User_ID = saleinvoice.UserID.ToInt();
                this.Update_GL(GL);
                this.DeleteGlDetaile(saleinvoice.GlID.ToLong());
            }

            #endregion

            if ((saleinvoice.NetPrice - saleinvoice.DiscountPrice) > 0)
                this.InserGLDetaile(glID, DtSanad.Accounts_ID_Bedehkar, saleinvoice.Tafsil_ID.ToInt(), DtSanad.Moein_ID_Bestankar, description, saleinvoice.SaleInvoice_ID, 5, (saleinvoice.NetPrice - saleinvoice.DiscountPrice), 0);

            if (saleinvoice.DiscountPrice > 0)
                this.InserGLDetaile(glID, DtTakhfifForosh.Accounts_ID_Bedehkar, null, DtTakhfifForosh.Moein_ID_Bedehkar, description, saleinvoice.SaleInvoice_ID, 5, saleinvoice.DiscountPrice, 0);

            if ((saleinvoice.NetPrice - saleinvoice.ServicePrice) > 0)
                this.InserGLDetaile(glID, DtSanad.Accounts_ID_Bestankar, TafziliIDBes, DtSanad.Moein_ID_Bestankar, description, saleinvoice.SaleInvoice_ID, 5, 0, (saleinvoice.NetPrice - saleinvoice.ServicePrice) - saleinvoice.VatPrice);

            if (saleinvoice.ServicePrice > 0)
                this.InserGLDetaile(glID, DtKhadamat.Accounts_ID_Bestankar, TafziliIDKhadamatBes, DtKhadamat.Moein_ID_Bestankar, description, saleinvoice.SaleInvoice_ID, 5, 0, saleinvoice.ServicePrice);

            if (saleinvoice.VatPrice > 0)
                this.InserGLDetaile(glID, DtArzeshAfzode.Accounts_ID_Bestankar, null, DtArzeshAfzode.Moein_ID_Bestankar, description, saleinvoice.SaleInvoice_ID, 5, 0, saleinvoice.VatPrice);

        }

        #endregion

        #region Tafsil
        public int AddTafsil(tblTafzili tafsil)
        {
            return tafsilRepo.Insert(tafsil);
        }

        public tblTafzili GetTafsilByID(long tafilID)
        {
            return tafsilRepo.Find(tafilID);
        }
        public int DeleteTafsilByID(long tafilID)
        {
            var tafsil = GetTafsilByID(tafilID);
            return tafsilRepo.Delete(tafsil);
        }

        #endregion

    }
}
