using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Model;
using BL;
using UtilitiesMethod;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace AppMobile.Controllers
{
    public class ServiceController : ApiController
    {
        public tblLogin UserLogin { get; set; }
        public tblSettingIDFactor Setting { get; set; }


        public ServiceController()
        {
            string constr = String.Format($@"Data Source=.\sqlexpress;Initial Catalog=Gishniz;User ID=gish;Password=gishniz$2020@!;MultipleActiveResultSets=true;");
            DBAccess.SetConnection(constr);
        }

        public void GetSetting()
        {
            var setting = localizationDBContext.SettingRepo.GetSetting();
            this.Setting = setting;
        }

        /// <summary>
        /// لاگین کاربر
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/OrderFood/LoginUser")]
        public string LoginUser([FromBody] List<User> userInfo)
        {
            User user = userInfo.FirstOrDefault();
            var UserLogin = localizationDBContext.SettingRepo.GetUser(user.UserName, user.Password);
            this.UserLogin = UserLogin;
            this.GetSetting();

            var userData = new { UserName = UserLogin.Login_UserName, Password = UserLogin.Login_Password, FullNameUser = UserLogin.Login_Name, Image = UserLogin.Login_Pic };

            string json = new JavaScriptSerializer().Serialize(userData);
            string js = JsonConvert.SerializeObject(userData);
            return json;
        }

        /// <summary>
        /// لیست گروه های غذایی
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/OrderFood/GetGroupsProduct")]
        public string GetGroupsProduct()
        {
            var groupList = localizationDBContext.ProductRepo.GetAllGroups();
            return new JavaScriptSerializer().Serialize(groupList);
        }

        /// <summary>
        /// دریافت توضیحات منو
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/OrderFood/GetDescriptionFood")]
        public string GetDescriptionFood()
        {
            var des = localizationDBContext.ProductRepo.GetDescriptionfoods();
            return new JavaScriptSerializer().Serialize(des);
        }

        /// <summary>
        /// کالاهای یک گروه غذایی خاص
        /// </summary>
        /// <param name="GroupID">کد گروه</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/OrderFood/GetProducsGroup/{GroupID}")]
        public string GetProducsGroup(long GroupID)
        {
            var products = localizationDBContext.ProductRepo.GetProductsByGroupID(GroupID);
            return new JavaScriptSerializer().Serialize(products);
        }


        /// <summary>
        /// لیست غذاهای پرفروش
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/OrderFood/GetProductsFavorit")]
        public string GetProductsFavorit()
        {
            var products = localizationDBContext.ProductRepo.GetProductsFavorit();
            return new JavaScriptSerializer().Serialize(products);
        }

        /// <summary>
        /// دریافت لیست اخرین فاکتورهای فروش
        /// </summary>
        /// <param name="count">تعداد فاکتورهای فروش</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/OrderFood/GetLastSaleInvoice/{count}")]
        public string GetLastSaleInvoice(int count)
        {
            var sales = localizationDBContext.SaleInvoiceRepo.GetLastSaleInvoice(count);
            return new JavaScriptSerializer().Serialize(sales);
        }
        
        /// <summary>
        /// لغو فاکتور
        /// </summary>
        /// <param name="_saleInvoice_ID">شماره فاکتور</param>
        /// <param name="_gl_ID">سریال سند</param>
        /// <param name="_userID">کد کاربر</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/home/CancleFactor/{IDFactor}/{SerialSanad}/{UserCode}")]
        public bool CancelSaleInvoice(string _saleInvoice_ID, string _gl_ID, string _userID)
        {
            try
            {
                var saleInvoice = localizationDBContext.SaleInvoiceRepo.CancelSaleInvoice(_saleInvoice_ID.ToLong(), _gl_ID.ToLong(), _userID.ToInt());
                if (saleInvoice != null)
                {
                    this.Print_CancelSaleInvoice(saleInvoice.SaleInvoice_ID);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                UtilitiFunction.WriteLogFile("Cancel SaleInvoice : " + ex.Message);
                return false;
            }
        }


        [HttpGet]
        [Route("api/OrderFood/GetSaleInvoiceShowDetaile/{saleInvoiceID}")]
        public string GetSaleInvoiceShowDetaile(long saleInvoiceID)
        {
            var sales = localizationDBContext.SaleInvoiceRepo.GetSaleInvoicePrint(saleInvoiceID);
            return new JavaScriptSerializer().Serialize(sales);
        }

        #region Print
        /// <summary>
        /// چاپ فیش لغو فاکتور
        /// </summary>
        /// <param name="_saleInvoice_ID"></param>
        public void Print_CancelSaleInvoice(long _saleInvoice_ID)
        {

        }
        #endregion

    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
