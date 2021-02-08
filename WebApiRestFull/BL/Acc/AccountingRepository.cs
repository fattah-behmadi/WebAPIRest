using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using UtilitiesMethod;

namespace BL
{
  public  class AccountingRepository
    {

        internal GenericRepository<tblTafzili> tafsilRepo { get; set; }

        public AccountingRepository()
        {
            tafsilRepo = new GenericRepository<tblTafzili>(DBAccess.GetNewContext());
        }


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
