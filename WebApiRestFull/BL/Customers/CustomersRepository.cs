using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using UtilitiesMethod;

namespace BL
{
    public class CustomersRepository
    {

        internal GenericRepository<tblAdress> addressRepo { get; set; }
        internal GenericRepository<tblMobile> mobileRepo { get; set; }
        internal GenericRepository<tblTell> tellRepo { get; set; }
        internal GenericRepository<Vw_TellMobileContact> vwTellRepo { get; set; }
        internal GenericRepository<tblContact> customersRepo { get; set; }

        public CustomersRepository()
        {
            addressRepo = new GenericRepository<tblAdress>(DBAccess.GetNewContext());
            mobileRepo = new GenericRepository<tblMobile>(DBAccess.GetNewContext());
            tellRepo = new GenericRepository<tblTell>(DBAccess.GetNewContext());
            vwTellRepo = new GenericRepository<Vw_TellMobileContact>(DBAccess.GetNewContext());
            customersRepo = new GenericRepository<tblContact>(DBAccess.GetNewContext());

        }


        #region Customer
        public List<tblContact> AllCustomers()
        {
            return customersRepo.All().ToList();
        }
        public int InsertCustomer(tblContact customer)
        {
            return customersRepo.Insert(customer);
        }
        public int UpdateCustomer(tblContact customer)
        {
            customersRepo.Find(customer.Contacts_ID);
            return customersRepo.Update(customer.Contacts_ID, customer);
        }
        public tblContact GetCustomer_ByTafsil(long tafsilID)
        {
            return customersRepo.FindBySingle(c => c.Tafzili_ID == tafsilID);
        }
        public tblContact GetCustomer_ByID(int id)
        {
            return customersRepo.FindBySingle(c => c.Contacts_ID == id);
        }

        public List<tblContact> GetAllCustomer_AT()
        {
            return customersRepo.AllInclude(c => c.tblAdresses, t => t.tblTells, m => m.tblMobiles).ToList();
        }

        #endregion

        #region address
        public int InsertAddress(tblAdress address)
        {
            return addressRepo.Insert(address);
        }
        public int InsertAddress(string address, int customerID)
        {
            if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
            {
                tblAdress _address = new tblAdress() { Adress = address, Contact_ID = customerID.ToInt() };
                return addressRepo.Insert(_address);

            }
            else return 0;
        }

        public List<tblAdress> GetAddress(int customerID)
        {
            return addressRepo.FindAll(a => a.Contact_ID == customerID).ToList();
        }

        #endregion

        #region tell
        public List<Vw_TellMobileContact> GetTellMobile(int customerID)
        {
            return vwTellRepo.FindAll(t => t.Contacts_ID == customerID).ToList();
        }
        public int InsertTell(tblTell tell)
        {
            return tellRepo.Insert(tell);
        }
        public int InsertTell(string tell, int customerID)
        {
            if (!string.IsNullOrEmpty(tell) && !string.IsNullOrWhiteSpace(tell))
            {
                tblTell _tell = new tblTell() { Contacts_ID = customerID.ToInt(), Tell_Contact = tell };
                return tellRepo.Insert(_tell);

            }
            else return 0;
        }


        #endregion

    }
}
