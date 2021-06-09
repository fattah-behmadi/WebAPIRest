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

        internal GenericRepository<tblTafzili> tafsilRepo { get; set; }
        internal GenericRepository<tblChildeSanad> GLDetaile { get; set; }
        internal GenericRepository<tblParentSanad> GL { get; set; }


        public AccountingRepository()
        {
            tafsilRepo = new GenericRepository<tblTafzili>(DBAccess.GetNewContext());
            GLDetaile = new GenericRepository<tblChildeSanad>(DBAccess.GetNewContext());
            GL = new GenericRepository<tblParentSanad>(DBAccess.GetNewContext());
        }

        #region GL
        public tblChildeSanad GetGlDetaile(long _glID)
        {
            return GLDetaile.FindByCondition(c => c.Serial_Sanad == _glID);
        }

        public bool DeleteGlDetaile(long _glID)
        {
            var gldetaile = this.GetGlDetaile(_glID);
            return GLDetaile.Delete(gldetaile).ToBool();
        }

        public tblParentSanad GetGl(long _glID)
        {
            return GL.FindByCondition(c => c.Serial_Sanad == _glID);
        }

        public bool DeleteGl(long _glID)
        {
            var gl = this.GetGl(_glID);
            return GL.Delete(gl).ToBool();
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
