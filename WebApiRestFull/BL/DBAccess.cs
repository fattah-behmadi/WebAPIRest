using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UtilitiesMethod;
using Model;

namespace BL
{
    public static class DBAccess
    {

        public static SanResturantEntities DBRestaurant { get; set; }
        public static string _ConnectionDatabase { get; set; }

        static DBAccess()
        {
            DBRestaurant = SanResturantEntities.Create(_ConnectionDatabase);
            DBRestaurant.Database.Connection.ConnectionString = _ConnectionDatabase;
        }
        public static void SetConnection(string connection = "")
        {
            UtilitiFunction.UnprotectConnectionString();
            if (!string.IsNullOrEmpty(connection))
            {
                _ConnectionDatabase = connection;
            }
            DBRestaurant = SanResturantEntities.Create(_ConnectionDatabase);
            DBRestaurant.Database.Connection.ConnectionString = _ConnectionDatabase;
            UtilitiFunction.ProtectConnectionString();

        }
        public static SanResturantEntities GetNewContext()
        {
            var context = SanResturantEntities.Create(_ConnectionDatabase);
            context.Database.Connection.ConnectionString = _ConnectionDatabase;
            return context;
        }
    }
}
