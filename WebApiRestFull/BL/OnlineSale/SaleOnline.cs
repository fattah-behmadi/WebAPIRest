using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Data.SqlClient;

namespace BL.OnlineSale
{
    public class SaleOnline
    {
        //GenericRepository<SaleFoodOnline> _SaleFoodOnlineRepo;
        //GenericRepository<SaleFoodOnlineDetaile> _SaleFoodOnlineDetaileRepo;
        //GenericRepository<SettingServerOnline> _SettingServerRepo;
        //OnlineRestaurantEntities db;

        string connectiononline = "";

        SqlConnection con;
        SqlCommand cmd;
        public SaleOnline(string Connection)
        {
            this.connectiononline = Connection;
            con = new SqlConnection(Connection);
            cmd = new SqlCommand();
            //db = OnlineRestaurantEntities.Create(Connection);
            //_SaleFoodOnlineDetaileRepo = new GenericRepository<SaleFoodOnlineDetaile>(db);
            //_SaleFoodOnlineRepo = new GenericRepository<SaleFoodOnline>(db);
            //_SettingServerRepo = new GenericRepository<SettingServerOnline>(db);
        }
        bool ExecuteCommand(string sql)
        {
            try
            {
                cmd.CommandText = sql;
                cmd.Connection = con;
                if (con.State == System.Data.ConnectionState.Closed) con.Open();
                cmd.ExecuteNonQuery();
                if (con.State == System.Data.ConnectionState.Open) con.Close();
                return true;

            }
            catch (Exception ex)
            {
                writetext(ex,"ExecuteCommand",sql );
                return false;

            }
        }

        #region SaleFoodOnline

        /// <summary>
        /// ثبت فاکتور
        /// </summary>
        /// <param name="salefood">اطلاعات فاکتور</param>
        /// <returns>نتیجه ثبت</returns>
        public bool AddSaleFood(SaleFoodOnline salefood)
        {
            string sql = "";

            try
            {
                /*
                 0 - ثبت جدید
                 1 - ویرایش شده
                 2 - لغو             
                 */
                bool result = false;
                #region Sql string

                salefood.PrintState = false;
                salefood.StateDelivery = 0; // ثبت جدید 
                //return Convert.ToBoolean(_SaleFoodOnlineRepo.Insert(salefood));

                 sql = string.Format(@"INSERT [dbo].[SaleFoodOnline]
                                        VALUES
                                        (  {0},          -- SaleFoodIDFact - bigint
                                            N'{1}',        -- NumFish - nvarchar(50)
                                            '{2}',  -- SaleDate - date
                                            '{3}', -- SaleTime - time(7)
                                            {4},          -- SumPriceBase - bigint
                                           {5},          -- SumNet - bigint
                                            {6},          -- SumDiscount - bigint
                                            {7},          -- SumNetPrice - bigint
                                            {8},          -- SumPrice - bigint
                                            N'{9}',        -- TypeFactor - nvarchar(50)
                                            N'{10}',        -- CustomerName - nvarchar(50)
                                            N'{11}',        -- CustomerTell - nvarchar(50)
                                            N'{12}',        -- CustomerAddress - nvarchar(max)
                                            {13},       -- PrintState - bit
                                            {14},          -- StateDelivery - int
                                            N'{15}'         -- Description - nvarchar(max)
                                            )", salefood.SaleFoodIDFact, salefood.NumFish, salefood.SaleDate.Value.ToString("yyyy-MM-dd"), salefood.SaleTime, salefood.SumPriceBase
                                            , salefood.SumNet, salefood.SumDiscount, salefood.SumNetPrice, salefood.SumPrice, salefood.TypeFactor, salefood.CustomerName
                                            , salefood.CustomerTell, salefood.CustomerAddress, Convert.ToInt16(salefood.PrintState), salefood.StateDelivery, salefood.Description
                                            );
                #endregion

                if (ExecuteCommand(sql))
                {
                    result = AddSaleFoodDetaile(salefood.SaleFoodOnlineDetailes.ToList());
                }

                return result;
            }
            catch (Exception ex)
            {
                writetext(ex,"add",sql);
                return false;
            }

        }

        /// <summary>
        /// ویرایش فاکتور
        /// </summary>
        /// <param name="salefood">اطلاعات فاکتور</param>
        /// <returns>نتیجه ویرایش</returns>
        public bool SaveSaleFood(SaleFoodOnline salefood)
        {
            /*
             0 - ثبت جدید
             1 - ویرایش شده
             2 - لغو             
             */
            try
            {

                #region ef
                //SaleFoodOnline factor = FindSaleFoodOnline(salefood.SaleFoodIDFact.Value);
                //if (factor != null)
                //{
                //    factor.SaleFoodIDFact = salefood.SaleFoodIDFact;
                //    factor.NumFish = salefood.NumFish;
                //    factor.SaleDate = salefood.SaleDate;
                //    factor.SaleDate = salefood.SaleDate;
                //    factor.SumPriceBase = salefood.SumPriceBase;
                //    factor.SumNet = salefood.SumNet;
                //    factor.SumDiscount = salefood.SumDiscount;
                //    factor.SumNetPrice = salefood.SumNetPrice;
                //    factor.SumPrice = salefood.SumPrice;
                //    factor.TypeFactor = salefood.TypeFactor;
                //    factor.CustomerName = salefood.CustomerName;
                //    factor.CustomerTell = salefood.CustomerTell;
                //    factor.CustomerAddress = salefood.CustomerAddress;
                //    factor.Description = salefood.Description;
                //    factor.PrintState = false;
                //    factor.StateDelivery = 1; //  فاکتور ویرایش شده است

                //}

                //var result = Convert.ToBoolean(_SaleFoodOnlineRepo.Update(factor)); 
                #endregion

                #region sqlSTR
                salefood.StateDelivery = 1;
                salefood.PrintState = false;
                string sql = string.Format(@"UPDATE [dbo].[SaleFoodOnline] SET
SaleFoodIDFact={0},NumFish=N'{1}',SaleDate='{2}',SaleTime='{3}',SumPriceBase={4},SumNet={5},
SumDiscount={6},SumNetPrice={7},SumPrice={8},TypeFactor=N'{9}',CustomerName=N'{10}',CustomerTell=N'{11}'
,CustomerAddress=N'{12}',PrintState={13},StateDelivery={14},Description=N'{15}' WHERE [SaleFoodIDFact]={0}"
, salefood.SaleFoodIDFact, salefood.NumFish, salefood.SaleDate.Value.ToString("yyyy-MM-dd"), salefood.SaleTime, salefood.SumPriceBase, salefood.SumNet,
salefood.SumDiscount, salefood.SumNetPrice, salefood.SumPrice, salefood.TypeFactor, salefood.CustomerName, salefood.CustomerTell,
salefood.CustomerAddress, Convert.ToInt16(salefood.PrintState), salefood.StateDelivery, salefood.Description);
                #endregion

                bool result = false;
                if (ExecuteCommand(sql))
                {
                    if (DeleteSaleFoodDetaileByIDSale(salefood.SaleFoodIDFact.Value))
                    {
                        result = AddSaleFoodDetaile(salefood.SaleFoodOnlineDetailes.ToList());
                    }

                }

                return result;
            }
            catch (Exception ex)
            {
                writetext(ex,"Update");
                return false;
            }

        }

        /// <summary>
        /// لغو فاکتور آنلاین
        /// </summary>
        /// <param name="SaleFoodID">شماره فاکتور</param>
        /// <returns></returns>
        public bool CancellationSaleFood(long SaleFoodID)
        {
            try
            {
                #region EF
                //SaleFoodOnline salefood = FindSaleFoodOnline(SaleFoodID);
                //salefood.PrintState = false;
                //salefood.StateDelivery = 2; // 
                //if (salefood != null)
                //    return Convert.ToBoolean(_SaleFoodOnlineRepo.Update(salefood));
                //else
                //    return false; 
                #endregion
                return ExecuteCommand("UPDATE [dbo].[SaleFoodOnline] SET PrintState=0,StateDelivery=2 WHERE [SaleFoodIDFact]=" + SaleFoodID);
            }
            catch (Exception ex)
            {
                writetext(ex,"cancel");
                return false;
            }


        }

        //public SaleFoodOnline FindSaleFoodOnline(long SaleFoodOnlineID)
        //{
        //    //return _SaleFoodOnlineRepo.Search(c => c.SaleFoodIDFact == SaleFoodOnlineID);
        //}

        /// <summary>
        /// حذف فاکتور
        /// </summary>
        /// <param name="salefoodid">شماره فاکتور</param>
        /// <returns></returns>
        public bool DeleteSaleFood(long salefoodid)
        {
            try
            {
                //SaleFoodOnline fact = FindSaleFoodOnline(salefoodid);
                //if (fact != null)
                //    return Convert.ToBoolean(_SaleFoodOnlineRepo.Delete(fact));
                //else
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion

        #region Detailes

        public Boolean AddSaleFoodDetaile(List<SaleFoodOnlineDetaile> salefooddetaile)
        {
            try
            {
                //return Convert.ToBoolean(_SaleFoodOnlineDetaileRepo.Insert(salefooddetaile));
                string sql = "INSERT [dbo].[SaleFoodOnlineDetaile] VALUES ";
                foreach (SaleFoodOnlineDetaile item in salefooddetaile)
                {
                    sql += string.Format(@"
                                    
                                    ( {0},    -- SaleFoodID - bigint
                                        N'{1}',  -- FoodName - nvarchar(50)
                                        {2},  -- NumFood - float
                                        {3},    -- Price - bigint
                                        {4}, -- DiscountPrice - decimal(18, 3)
                                        {5}, -- DiscountPercent - decimal(18, 3)
                                        {6},    -- NetPrice - bigint
                                        {7}, -- TaxPercent - decimal(18, 3)
                                        {8}, -- TaxPrice - decimal(18, 3)
                                        {9},    -- SumPrice - bigint
                                        N'{10}'   -- DescFood - nvarchar(max)
                                        ),", item.SaleFoodID, item.FoodName, item.NumFood, item.Price, item.DiscountPrice, item.DiscountPercent, item.NetPrice
                                         , item.TaxPercent, item.TaxPrice, item.SumPrice, item.DescFood);
                }

                return ExecuteCommand(sql.TrimEnd(','));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// حذف اقلام فاکتور به کمک شماره فاکتور
        /// </summary>
        /// <param name="_SaleFoodIDFact">شماره فاکتور</param>
        /// <returns></returns>
        public Boolean DeleteSaleFoodDetaileByIDSale(long _SaleFoodIDFact)
        {
            try
            {
                var result = ExecuteCommand("DELETE dbo.SaleFoodOnlineDetaile WHERE SaleFoodID=" + _SaleFoodIDFact);
                return result;

                #region ef
                //var result = _SaleFoodOnlineDetaileRepo.ExecuteSqlCommand("DELETE dbo.SaleFoodOnlineDetaile WHERE SaleFoodID=" + _SaleFoodIDFact);
                //var liDetaileFood = _SaleFoodOnlineDetaileRepo.FindBy(c => c.SaleFoodID == _SaleFoodIDFact).ToList();
                //return Convert.ToBoolean(_SaleFoodOnlineDetaileRepo.Delete(liDetaileFood)); 
                #endregion
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        public static void writetext(Exception ex,string function,string sql="")
        {
            string inner = ex.InnerException == null ? "" : ex.InnerException.Message;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@".\Online.Log", true))
            {
                file.WriteLine(function+"=====================================");
                file.WriteLine(DateTime.Now);
                file.WriteLine(ex.Message);
                if (!string.IsNullOrEmpty(inner))
                    file.WriteLine(inner);
                file.WriteLine("*********************************");
                file.WriteLine(sql);
                file.WriteLine("=====================================");

            }
        }

    }
}
