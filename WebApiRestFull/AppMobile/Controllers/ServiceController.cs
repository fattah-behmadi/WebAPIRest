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
using AppMobile.Rpt.small;
using AppMobile.Rpt;
using DevExpress.XtraReports.UI;
using JntNum2Text;

namespace AppMobile.Controllers
{
    public class ServiceController : ApiController
    {
        public tblLogin UserLogin { get; set; }
        public tblSettingIDFactor Setting { get; set; }
        public tblPrinterUserSetting _SettingUser { get; set; }

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
        public void GetUserLogin(int userID)
        {
            this.UserLogin = localizationDBContext.SettingRepo.GetUser(userID);
            _SettingUser = localizationDBContext.SettingRepo.GetSettigPrinterUser(userID);
        }

        /// <summary>
        /// لاگین کاربر
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/OrderFood/LoginUser")]
        public string LoginUser([FromBody] User user)
        {
            this.UserLogin = localizationDBContext.SettingRepo.GetUser(user.UserName, user.Password);
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
            var groupList = localizationDBContext.ProductRepo.GetGroupsByNotType("فقط خریدنی");
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            var result = serializer.Serialize(groupList);
            return result;
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
        [Route("api/OrderFood/CancelSaleInvoice/{_saleInvoice_ID}/{_gl_ID}/{_userID}")]
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

        /// <summary>
        /// تابع غذاهای یک فاکتور
        /// </summary>
        /// <param name="saleInvoiceID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/OrderFood/GetSaleInvoiceShowDetaile/{saleInvoiceID}")]
        public string GetSaleInvoiceShowDetaile(long saleInvoiceID)
        {
            var sales = localizationDBContext.SaleInvoiceRepo.GetSaleInvoicePrint(saleInvoiceID);
            return new JavaScriptSerializer().Serialize(sales);
        }

        [HttpPost]
        [Route("api/OrderFood/SaveSaleInvoice")]
        public string SaveSaleInvoice([FromBody] OrderSaleInvoice _saleInvoiceData)
        {
            string NumberOrder = string.Empty;
            try
            {
                if (_saleInvoiceData == null)
                {
                    var obj = new { NumberOrder = string.Empty, Message = "لطفا سفارشی را ثبت نمایید" };
                    return new JavaScriptSerializer().Serialize(obj);
                }

                var saleInvoice = this.InsertSaleInvoice(_saleInvoiceData);
                NumberOrder = saleInvoice.NumberOrder.ToString();
                var obj_result = new { NumberOrder = NumberOrder, Message = "اطلاعات با موفقیت ثبت گردید" };
                return new JavaScriptSerializer().Serialize(obj_result);
            }
            catch (Exception ex)
            {
                var errorData = new { NumberSaleInvoice = NumberOrder, Exception = ex.Message };

                if (ex.InnerException != null)
                {
                    UtilitiFunction.WriteLogFile("SaveSaleInvoice : " + ex.Message + "\n \t\t\t ----> InnerException: " + ex.InnerException + "\n");
                }
                else
                    UtilitiFunction.WriteLogFile("SaveSaleInvoice : " + ex.Message);

                return new JavaScriptSerializer().Serialize(errorData);
            }
        }

        [HttpPut]
        [Route("api/OrderFood/UpdateSaleInvoice/{_saleInvoice_ID}")]
        public string UpdateSaleInvoice(string _saleInvoice_ID, [FromBody] OrderSaleInvoice _saleInvoiceData)
        {
            string NumberOrder = string.Empty;
            try
            {
                if (_saleInvoiceData == null)
                {
                    var obj = new { NumberOrder = string.Empty, Message = "لطفا سفارشی را ثبت نمایید" };
                    return new JavaScriptSerializer().Serialize(obj);
                }

                var saleInvoice = this.InsertSaleInvoice(_saleInvoiceData, _saleInvoice_ID.ToLong());
                NumberOrder = saleInvoice.NumberOrder.ToString();
                var obj_result = new { NumberOrder = NumberOrder, Message = "اطلاعات با موفقیت ثبت گردید" };
                return new JavaScriptSerializer().Serialize(obj_result);
            }
            catch (Exception ex)
            {
                var errorData = new { NumberSaleInvoice = NumberOrder, Exception = ex };

                if (ex.InnerException != null)
                {
                    UtilitiFunction.WriteLogFile("SaveSaleInvoice : " + ex.Message + "\n \t\t\t ----> InnerException: " + ex.InnerException + "\n");
                }
                else
                    UtilitiFunction.WriteLogFile("SaveSaleInvoice : " + ex.Message);

                return new JavaScriptSerializer().Serialize(errorData);
            }
        }

        SaleInvoice InsertSaleInvoice(OrderSaleInvoice _saleInvoiceData, long _saleinvoiceID = 0)
        {

            if (this.Setting == null)
                this.GetSetting();
            this.GetUserLogin(_saleInvoiceData.UserID.ToInt());

            SaleInvoice saleInvoice;
            if (_saleinvoiceID > 0)
                saleInvoice = localizationDBContext.SaleInvoiceRepo.GetSaleInvoice(_saleinvoiceID);
            else
                saleInvoice = new SaleInvoice();

            if (_saleInvoiceData.Tafsil_ID.ToLong() == 0)
                saleInvoice.Tafsil_ID = this.Setting.DefultContact.ToLong();
            else
                saleInvoice.Tafsil_ID = _saleInvoiceData.Tafsil_ID;

            saleInvoice.Description = _saleInvoiceData.Description;
            saleInvoice.SumPrice = _saleInvoiceData.Products.Select(c => c.Qty * c.Price).ToList().Sum(c => c);
            saleInvoice.UserID = _saleInvoiceData.UserID;
            saleInvoice.NumDesk = _saleInvoiceData.NumDesk;
            saleInvoice.CustomerFullName = _saleInvoiceData.CustomerFullName;
            saleInvoice.SaleInvoice_Type = _saleInvoiceData.SaleInvoice_Type;
            saleInvoice.DiscountPrice = _saleInvoiceData.DiscountPrice;
            saleInvoice.VatPrice = _saleInvoiceData.VatPrice;

            bool result;
            if (saleInvoice.SaleInvoice_ID > 0)
                result = localizationDBContext.SaleInvoiceRepo.UpdateSaleInvoice(saleInvoice, _saleInvoiceData);
            else
                result = localizationDBContext.SaleInvoiceRepo.InsertSaleInvoice(saleInvoice, _saleInvoiceData);
            if (result)
                PrintReport(saleInvoice);
            return saleInvoice;

        }

        #region Print
        /// <summary>
        /// چاپ فیش لغو فاکتور
        /// </summary>
        /// <param name="_saleInvoice_ID"></param>
        public void Print_CancelSaleInvoice(long _saleInvoice_ID)
        {

        }
        void PrintReport(SaleInvoice saleinvoice, bool Edited = false)
        {
            try
            {

                var data = localizationDBContext.SaleInvoiceRepo.PrintSaleInvoice(saleinvoice.SaleInvoice_ID);
                if (_SettingUser.BironbarMoshtari.ToBool() || _SettingUser.DakhelSalonMoshtari.ToBool() || _SettingUser.PeykMoshtari.ToBool())
                    RptCustomer(data, saleinvoice.SumPrice, Edited);

                if (_SettingUser.BironbarAshpazkhane.ToBool() || _SettingUser.DakhelSalonAshpazkhane.ToBool() || _SettingUser.PeykAshpazkhane.ToBool())
                    RptKitchen(data, saleinvoice.SumPrice, Edited);

                if (_SettingUser.BironbarSandogh.ToBool() || _SettingUser.DakhelSalonSandogh.ToBool() || _SettingUser.PeykSandogh.ToBool())
                    RptCashier(data, saleinvoice.SumPrice, Edited);

            }
            catch (Exception ex)
            {

                UtilitiFunction.WriteLogFile("PrintReport : " + ex.Message);
            }
        }
        XtraReport DesignReport(SaleInvoicePrint datasource, XtraReport report, string printerName, long sumPrice, bool edited, string stateorderprint = "")
        {
            long price = 0;
            string stateOrder;

            if (sumPrice > 0)
            {
                if (Setting.Setting_CurrencySymbol.Contains("ریال"))
                    price = sumPrice.ToString().Substring(0, sumPrice.ToString().Length - 1).ToLong();
                else
                    price = sumPrice;
            }
            if (string.IsNullOrEmpty(stateorderprint))
            {
                if (edited)
                    stateOrder = "فیش اصلاحی";
                else
                    stateOrder = "فیش جدید";
            }
            else
                stateOrder = stateorderprint;
            string textprice = (Num2Text.ToFarsi(price) + " تومان ").ToString();
            SaleInvoicePrint.Setting _setting = new SaleInvoicePrint.Setting();
            _setting.DateTimeToday = DateTime.Now.JulianToPersianDate();
            _setting.PriceText = textprice;
            _setting.StateSale = stateOrder;
            datasource.SettingPrint = _setting;
            //report = reportDesign.CreatReport(Of Model.SaleInvoicePrint)(datasource, report)
            report.PrinterName = printerName;
            List<SaleInvoicePrint> dts = new List<SaleInvoicePrint>();
            dts.Add(datasource);
            report.DataSource = dts;
            return report;
        }
        void RptCustomer(SaleInvoicePrint data, long sumPrice, bool edited)
        {
            XtraReport report;
            if (_SettingUser.Costumer5Cm.ToBool())
                report = new RptCustomerSmall();
            else
                report = new RptCustomer();

            report = DesignReport(data, report, _SettingUser.PrinterCustomer, sumPrice, edited);
            report.RequestParameters = false;
            report.ShowPrintStatusDialog = false;
            report.PrintingSystem.ShowMarginsWarning = false;
            report.CreateDocument(false);
            DevExpress.XtraPrinting.PrintToolBase printTool = new DevExpress.XtraPrinting.PrintToolBase(report.PrintingSystem);
            printTool.PrinterSettings.Copies = 1;
            printTool.Print(_SettingUser.PrinterCustomer);
        }
        void RptKitchen(SaleInvoicePrint data, long sumPrice, bool edited)
        {
            XtraReport report;
            if (_SettingUser.Costumer5Cm.ToBool())
                report = new RptKitchenSmall();
            else
                report = new RptKitchen();

            report = DesignReport(data, report, _SettingUser.PrinterAshpazkhane, sumPrice, edited);
            report.RequestParameters = false;
            report.ShowPrintStatusDialog = false;
            report.PrintingSystem.ShowMarginsWarning = false;
            report.CreateDocument(false);
            DevExpress.XtraPrinting.PrintToolBase printTool = new DevExpress.XtraPrinting.PrintToolBase(report.PrintingSystem);
            printTool.PrinterSettings.Copies = 1;
            printTool.Print(_SettingUser.PrinterAshpazkhane);
        }
        void RptCashier(SaleInvoicePrint data, long sumPrice, bool edited)
        {
            XtraReport report;
            if (_SettingUser.Costumer5Cm.ToBool())
                report = new RptCashierSmall();
            else
                report = new RptCashier();

            report = DesignReport(data, report, _SettingUser.PrinterSandogh, sumPrice, edited);
            report.RequestParameters = false;
            report.ShowPrintStatusDialog = false;
            report.PrintingSystem.ShowMarginsWarning = false;
            report.CreateDocument(false);
            DevExpress.XtraPrinting.PrintToolBase printTool = new DevExpress.XtraPrinting.PrintToolBase(report.PrintingSystem);
            printTool.PrinterSettings.Copies = 1;
            printTool.Print(_SettingUser.PrinterSandogh);
        }
        #endregion

    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}


/*
 
     
        {	
        "Tafsil_ID":"",
"Description":"بدون خامه",
"UserID":"2059",
"NumDesk":"2",
"SaleInvoice_Type":"بیرون بر",
"CustomerFullName":"فتاح بهمدی",
"DiscountPrice":"50000",
"VatPrice":"0",
"Products":[
                    {
                    "Product_ID":"104",
                    "ProductName":"شیر موز",
                    "Qty":"2",
                    "Product_Description":"",
                    "Price":"120000"
                    },
                    {
                    "Product_ID":"100",
                    "ProductName":"شیر انبه",
                    "Qty":"2",
                    "Product_Description":"",
                    "Price":"150000"
                    }
            ]
}
     
     */
