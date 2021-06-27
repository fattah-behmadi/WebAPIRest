using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using UtilitiesMethod;

namespace BL
{
    public class SettingRepository
    {

        #region Repository
        internal GenericRepository<tblCompany_Info> CompanyRepo { get; set; }
        internal GenericRepository<tblSettingIDFactor> SettingRepo { get; set; }
        internal GenericRepository<tblPrinterUserSetting> SettingPrinterUserRepo { get; set; }
        internal GenericRepository<tblSettingAcc> SettingAccRepo { get; set; }
        internal GenericRepository<tblLogin> loginRepo { get; set; }



        #endregion

        tblCompany_Info _companyCashing;
        List<tblSettingAcc> _settingAccCashing;

        public SettingRepository()
        {
            CompanyRepo = new GenericRepository<tblCompany_Info>(DBAccess.GetNewContext());
            SettingRepo = new GenericRepository<tblSettingIDFactor>(DBAccess.GetNewContext());
            SettingPrinterUserRepo = new GenericRepository<tblPrinterUserSetting>(DBAccess.GetNewContext());
            SettingAccRepo = new GenericRepository<tblSettingAcc>(DBAccess.GetNewContext());
            loginRepo = new GenericRepository<tblLogin>(DBAccess.GetNewContext());

        }

        #region Company
        public tblCompany_Info GetCompany()
        {
            if (_companyCashing == null)
                _companyCashing = CompanyRepo.FindByCondition(c => c.Company_ID > 0);
            return _companyCashing;
        }

        #endregion

        /// <summary>
        /// دریافت تنظیمات مربوط به برنامه
        /// </summary>
        /// <returns></returns>
        public tblSettingIDFactor GetSetting()
        {
            return SettingRepo.FindByCondition(c => c.ID_SettingSefareshat > 0);

        }

        /// <summary>
        /// دریافت تنظیمات پرینتر کاربر
        /// </summary>
        /// <param name="IDUser"></param>
        /// <returns></returns>
        public tblPrinterUserSetting GetSettigPrinterUser(int IDUser)
        {
            return SettingPrinterUserRepo.FindByCondition(c => c.UserID == IDUser);
        }

        #region SettingAcc

        public List<tblSettingAcc> GetSettingAccAll()
        {
            if (_settingAccCashing == null)
                _settingAccCashing = SettingAccRepo.All().ToList();
            return _settingAccCashing;
        }

        public tblSettingAcc GetSettingAccByID(int ID_AccSetting)
        {
            return SettingAccRepo.FindByCondition(c => c.ID_ACCSetting == ID_AccSetting);
        }

        public tblSettingAcc GetSettingAccByName(string _nameAcc)
        {
            return SettingAccRepo.FindByCondition(c => c.NameAcc == _nameAcc);

        }
        #endregion

        #region UserLogin
        public tblLogin GetUser(string uName, string uPass)
        {
            string pass = uPass.PasswordEncrypt();
            return this.loginRepo.FindByCondition(u => u.Login_UserName == uName && u.Login_Password == pass);
        }

        public tblLogin GetUser(int _userID)
        {
            return this.loginRepo.FindByCondition(u => u.Login_ID == _userID);
        }


        #endregion


    }
}
