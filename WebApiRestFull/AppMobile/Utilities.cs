using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AppMobile
{
    public static class Utilities
    {
        public static string GetServerConnection()
        {
            var str = System.Web.HttpRuntime.AppDomainAppPath + "ServerName.txt";
            //str str=System.Web.Hosting.HostingEnvironment.MapPath("~");
            //string srt = HttpContext.Current.Server.MapPath("~");
            if (File.Exists(str))
            {
                string[] text = File.ReadAllLines(str);
                return text[0];
            }
            else
            {
                using (StreamWriter sw = File.CreateText(str))
                {
                    sw.Write(".\\sqlexpress");
                }
                return ".\\sqlexpress";
            }

        }
    }
}