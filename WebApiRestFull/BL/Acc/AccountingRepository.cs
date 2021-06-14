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

        public bool InserGLDetaile(long glID,int? acc_ID_Debtor,int? tafsil_ID,int? moin_ID_Creditor,string description,long ActionID,int ActionTypeID,long DebtorPrice,long CreditorPrice)
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
            var gldetaile = this.GetGlDetaile(_glID);
            return GLDetaile.Delete(gldetaile).ToBool();
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
            var gl = this.GetGl(_glID);
            return GL.Delete(gl).ToBool();
        }
        /// <summary>
        /// شماره سند جدید
        /// </summary>
        /// <returns></returns>
        public long GetNewGLID()
        {
            //string sql = "SELECT isnull(MAX([Serial_Sanad]),0) + 1  FROM [tblParentSanad]";
            //var dt = this.GL.SqlQueryGetData(sql);
            //var res = dt.Rows[0][0];

            var gl = this.GL.FindByLasted(g => g.Serial_Sanad >= 0, x => x.Date_Sanad.Value, 20).ToList().OrderByDescending(c => c.Serial_Sanad).FirstOrDefault();
            if (gl == null)
                return 1;
            else
                return gl.Serial_Sanad + 1;
        }
        /// <summary>
        /// شماره عدد سند جدید
        /// </summary>
        /// <returns></returns>
        public long GetNewGLNumber()
        {
            //string sql = "SELECT isnull(MAX([Serial_Sanad]),0) + 1  FROM [tblParentSanad]";
            //var dt = this.GL.SqlQueryGetData(sql);
            //var res = dt.Rows[0][0];

            var gl = this.GL.FindByLasted(g => g.Number_Sanad >= 0, x => x.Date_Sanad.Value, 20).ToList().OrderByDescending(c => c.Number_Sanad).FirstOrDefault();
            if (gl == null)
                return 1;
            else
                return gl.Number_Sanad.Value + 1;
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
