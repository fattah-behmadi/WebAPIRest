using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using UtilitiesMethod;
namespace BL
{
  public  class BuyInvoiceRepository
    {

        internal GenericRepository<TblChild_KharidKala> buydetaileRepo { get; set; }

        public BuyInvoiceRepository()
        {
            buydetaileRepo = new GenericRepository<TblChild_KharidKala>(DBAccess.GetNewContext());
        }

        #region buyDetailesInvoice
        public int InsertBuyDetailes(TblChild_KharidKala buydetaile)
        {
            return buydetaileRepo.Insert(buydetaile);
        }
        public int InsertBuyDetailes(List<TblChild_KharidKala> buydetaile)
        {
            return buydetaileRepo.InsertAll(buydetaile);
        }
        #endregion
    }
}
