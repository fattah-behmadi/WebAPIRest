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
        public ServiceController()
        {
            string constr = String.Format($@"Data Source=.\sqlexpress;Initial Catalog=Gishniz;User ID=gish;Password=gishniz$2020@!;MultipleActiveResultSets=true;");
            DBAccess.SetConnection(constr);
        }
        [HttpPost]
        [Route("api/OrderFood/LoginUser")]
        public void LoginUser([FromBody] List<User> userInfo)
        {
            User user = userInfo.FirstOrDefault();
            var UserLogin = localizationDBContext.SettingRepo.GetUser(user.UserName, user.Password);
            var setting = localizationDBContext.SettingRepo.GetSetting();

            var userData = new { UserName = UserLogin.Login_UserName, Password = UserLogin.Login_Password, FullNameUser = UserLogin.Login_Name, Image = UserLogin.Login_Pic };

            string json = new JavaScriptSerializer().Serialize(userData);

            string js = JsonConvert.SerializeObject(userData);
       

        }


    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
