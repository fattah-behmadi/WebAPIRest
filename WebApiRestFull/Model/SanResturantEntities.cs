using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace Model
{
    public partial class SanResturantEntities
    {

        static string Connectionnew;
        public SanResturantEntities(string nameOrConnectionString)
             : base("name=SanResturantEntities")
        {

            this.Database.Connection.ConnectionString = Connectionnew;
            this.Configuration.LazyLoadingEnabled = false;

        }

        public static SanResturantEntities Create(string providerConnectionString)
        {
            Connectionnew = providerConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.ProviderConnectionString = providerConnectionString;
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.Metadata = @"res://*/DB.csdl|res://*/DB.ssdl|res://*/DB.msl";
            SetConnectionString(entityBuilder.ConnectionString);
            return new SanResturantEntities(entityBuilder.ConnectionString);

        }

        private static void SetConnectionString(string buil)
        {
            System.Configuration.Configuration config = null;
            if (System.Web.HttpContext.Current != null)
            {
                config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            }
            else
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }

            if (config.ConnectionStrings.ConnectionStrings["SanResturantEntities"] != null)
            {
                config.ConnectionStrings.ConnectionStrings["SanResturantEntities"].ConnectionString = buil;
                config.ConnectionStrings.ConnectionStrings["SanResturantEntities"].ProviderName = "System.Data.EntityClient";
                config.Save(ConfigurationSaveMode.Modified);
            }

        }


    }



}


