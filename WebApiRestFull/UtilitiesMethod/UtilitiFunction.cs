using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using System.Reflection;
using DevExpress.DataAccess.Excel;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Data;
using AutoMapper;
using System.Configuration;
using System.Security.Cryptography;


namespace UtilitiesMethod
{
    public static class UtilitiFunction
    {
        /// <summary>
        /// انتقال اطلاعات از کلاس والد به کلاس فرزند
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static T CopyCalss<T>(this object parent)
        {
            var serialized = JsonConvert.SerializeObject(parent);
            return JsonConvert.DeserializeObject<T>(serialized);

        }

        #region Convert Data  ExcelDataSource Control to List of class
        /// <summary>
        /// تبدیل یک دیتاتیبل به لیستی از کلاس
        /// </summary>
        /// <typeparam name="T">کلاس مورد نظر جهت تبدیل</typeparam>
        /// <param name="dt">دیتاتیبل مورد نظر جهت تبدیل</param>
        /// <returns></returns>
        public static List<T> DataTableToClass<T>(this DataTable dt)
        {
            List<T> data = new List<T>(); /// لیستی از کلاس برای بازگرداندن اطلاعات
            foreach (DataRow row in dt.Rows)
            {
                T item = DataRowToClass<T>(row); /// تبدیل دیتای یک سطر به یک نمونه از کلاس 
                data.Add(item); ///     اضافه کردن کلاس مقداردهی شده به لیست بازگشتی
            }
            return data;
        }
        /// <summary>
        /// تبدیل سطر اول دیتاتیبل به کلاس
        /// </summary>
        /// <typeparam name="T">کلاس مقصد</typeparam>
        /// <param name="dt">دیتاتیبل </param>
        /// <returns></returns>
        public static T First_DataTableToClass<T>(this DataTable dt)
        {
            T obj = Activator.CreateInstance<T>();  /// لیست اجزائ کلاس یا ابجکت
            if (dt == null) return obj;
            else
                return dt.Rows[0].DataRowToClass<T>();
        }

        /// <summary>
        /// تبدیل یک سطر دیتاتیبل به یک نمونه از کلاس مورد نظر
        /// </summary>
        /// <typeparam name="T">کلاس مورد نظر</typeparam>
        /// <param name="dr">دیتای مورد نظر</param>
        /// <returns>نمونه ای از کلاس که مقدار دهی شده ست</returns>
        private static T DataRowToClass<T>(this DataRow dr)
        {
            Type temp = typeof(T);  ///  مشخص نمودن نوع کلاس و جزئیات آن
            T obj = Activator.CreateInstance<T>();  /// لیست اجزائ کلاس یا ابجکت

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())  /// حرکت بین پراپرتی ها یا اجزا کلاس
                {
                    //in case you have a enum/GUID datatype in your model
                    //We will check field's dataType, and convert the value in it.
                    if (pro.Name == column.ColumnName)
                    {
                        try
                        {
                            var convertedValue = GetValueByDataType(pro.PropertyType, dr[column.ColumnName]);   // دریافت مقدار از دیتارو و تبدیل این مقدار به نوع داده ای مورد نظر لیست
                            pro.SetValue(obj, convertedValue, null);/// مقدار دهی پراپرتی مورد نظر
                        }
                        catch (Exception e)
                        {
                            //ex handle code                   
                            throw;
                        }
                        //pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        /// <summary>
        /// تبدیل نوع یک مقدار به نوع داده ای معرفی شده
        /// </summary>
        /// <param name="propertyType">نوع داده ای مورد نظر جهت تبدیل</param>
        /// <param name="o">مقدار مورد نظر برای تبدیل</param>
        /// <returns></returns>
        private static object GetValueByDataType(Type propertyType, object o)
        {
            if (o == null)
            {
                return null;
            }
            if (propertyType == (typeof(Guid)) || propertyType == typeof(Guid?))
            {
                return Guid.Parse(o.ToString());
            }
            else if (propertyType == typeof(int) || propertyType == typeof(int?))
            {
                return Convert.ToInt32(o);
            }
            else if (propertyType == typeof(int) || propertyType.IsEnum)
            {
                return Convert.ToInt32(o);
            }
            else if (propertyType == typeof(decimal) || propertyType == typeof(decimal?))
            {
                return Convert.ToDecimal(o);
            }
            else if (propertyType == typeof(double) || propertyType == typeof(double?))
            {
                return Convert.ToDouble(o);
            }
            else if (propertyType == typeof(long) || propertyType == typeof(long?))
            {
                return Convert.ToInt64(o);
            }
            else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
            {
                return Convert.ToBoolean(o);
            }
            else if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
            {
                return Convert.ToDateTime(o);
            }
            else if (propertyType == typeof(string))
            {
                return Convert.ToString(o);
            }
            return o.ToString();
        }

        /// <summary>
        /// تبدیل اطلاعات این کابجکت به دیتاتیبل
        /// </summary>
        /// <param name="excelDataSource">لیست داده اکسل </param>
        /// <returns>داده ها در قالب دیتاتیبل </returns>
        public static DataTable ToDataTable(this ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();/// لیست پراپرتی ستون ها
            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i]; /// دریافت یک خصوصیت خاص
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list) ///  حرکت بین  ردیف های لیست داده ها
            {
                for (int i = 0; i < values.Length; i++)/// حرکت بین ستون ها
                {
                    values[i] = props[i].GetValue(item);    ///     دریافت مقدار سلول یک پراپرتی خاص
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// تبدیل خروجی این لیست اکسل به کلاس مورد نظر معرفی شده
        /// </summary>
        /// <typeparam name="T">کلاس خروجی</typeparam>
        /// <param name="excelDataSource">تبدیل محتوای این ابجکت به کلاس مورد نظر</param>
        /// <returns>لیستی از نوع کلاس مورد نظر که مقدار دهی شده اسن</returns>
        public static List<T> GetData<T>(this ExcelDataSource excelDataSource)
        {
            try
            {

                List<T> data = new List<T>(); /// لیستی از کلاس برای بازگرداندن اطلاعات

                IList list = ((IListSource)excelDataSource).GetList();
                DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
                List<PropertyDescriptor> propsExcel = dataView.Columns.ToList<PropertyDescriptor>();/// لیست پراپرتی ستون ها

                Type temp = typeof(T);  ///  مشخص نمودن نوع کلاس و جزئیات آن

                //DataTable table = new DataTable();
                //PropertyDescriptor prop = propsExcel[1]; /// دریافت یک خصوصیت خاص
                //table.Columns.Add(prop.Name, prop.PropertyType);

                foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list) ///  حرکت بین  ردیف های لیست داده ها
                {
                    T obj = Activator.CreateInstance<T>();  /// لیست اجزائ کلاس یا ابجکت

                    try
                    {
                        for (int i = 0; i < propsExcel.Count; i++)/// حرکت بین ستون ها
                        {
                            PropertyDescriptor propitem = propsExcel[i]; /// دریافت یک خصوصیت خاص
                            var cellvalue = propitem.GetValue(item);    ///     دریافت مقدار سلول یک پراپرتی خاص
                            string propnameExcel = "";
                            if (propitem.Name.Contains("("))
                                propnameExcel = propitem.Name.Split('(', ')')[1];    ////    دریافت نام لاتین ستون اکسل که بین دوپرانتز قرار دارد

                            foreach (PropertyInfo pro in temp.GetProperties())  /// حرکت بین پراپرتی ها یا اجزا کلاس
                            {

                                if (pro.Name.ToLower() == propnameExcel.ToLower())
                                {
                                    try
                                    {
                                        if (pro.CanWrite)
                                        {
                                            if (Nullable.GetUnderlyingType(pro.PropertyType) != null)   /// پراپری مورد نظر IsNullable می باشد
                                            {
                                                var typprop = pro.GetType();
                                            }
                                            var convertedValue = GetValueByDataType(pro.PropertyType, cellvalue);   // دریافت مقدار از دیتارو و تبدیل این مقدار به نوع داده ای مورد نظر لیست
                                            pro.SetValue(obj, convertedValue, null);/// مقدار دهی پراپرتی مورد نظر
                                        }
                                    }
                                    catch (Exception e)
                                    {

                                    }
                                    //pro.SetValue(obj, dr[column.ColumnName], null);
                                }
                                else
                                    continue;
                            }
                        }
                    }
                    catch (Exception exx)
                    {

                        continue;
                    }

                    data.Add(obj);
                }

                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<T> GetExcelDataSource<T>()
        {
            List<T> data = new List<T>();

            OpenFileDialog opDialog = new OpenFileDialog();

            opDialog.InitialDirectory = "c:\\";
            opDialog.Filter = "Excel files (*.Xls)|*.Xls|Excel files (*.Xlsx)|*.Xlsx";
            opDialog.FilterIndex = 1;
            opDialog.RestoreDirectory = true;

            try
            {
                DialogResult result = opDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    ExcelDataSource excelDataSource = new ExcelDataSource();
                    excelDataSource.FileName = opDialog.FileName;
                    IExcelSchemaProvider schemaProvider = excelDataSource.GetService(typeof(IExcelSchemaProvider)) as IExcelSchemaProvider;
                    ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings("Sheet");
                    excelDataSource.SourceOptions = new ExcelSourceOptions(worksheetSettings);
                    DevExpress.DataAccess.Excel.FieldInfo[] availableFields = schemaProvider.GetSchema(excelDataSource.FileName, null, ExcelDocumentFormat.Xlsx, excelDataSource.SourceOptions, System.Threading.CancellationToken.None);
                    //For Each field As FieldInfo In availableFields

                    //    Dim columnName As String = field.Name.Split("("c, ")"c)(1)
                    //    Dim typ = field.Type.Name

                    //    If columnName.ToLower() = "Kbarcod".ToLower Then
                    //        field.Type = GetType(String)
                    //        excelDataSource.Schema.Add(field)
                    //    Else
                    //        excelDataSource.Schema.Add(field)
                    //    End If
                    //Next field
                    excelDataSource.Fill();

                    //Dim source As New ExcelDataSource()
                    //source.FileName = opDialog.FileName
                    //Dim worksheetSettings As New ExcelWorksheetSettings("Sheet")
                    //source.SourceOptions = New ExcelSourceOptions(worksheetSettings)
                    //source.Fill()
                    data = excelDataSource.GetData<T>();
                }
                return data;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("عملیات ناموفق");
                return null;
            }

        }
        #endregion

        #region DateTime


        public static string JulianToPersianDate(this DateTime date)
        {

            try
            {
                PersianCalendar pc = new PersianCalendar();
                var year = pc.GetYear(date).ToString();
                var month = pc.GetMonth(date).ToString().PadLeft(2, '0');
                var day = pc.GetDayOfMonth(date).ToString().PadLeft(2, '0');
                return string.Format($"{year}-{month}-{day}");
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static string JulianToPersianDateTime(this DateTime date)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var year = pc.GetYear(date).ToString();
                var month = pc.GetMonth(date).ToString().PadLeft(2, '0');
                var day = pc.GetDayOfMonth(date).ToString().PadLeft(2, '0');
                return string.Format($"{year}-{month}-{day}  {date.ToString("HH:mm")}");
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public static DateTime SetTime(DateTime date, string time)
        {
            try
            {
                time = FixTime(time);
                if (string.IsNullOrEmpty(time))
                    return date;
                string[] hm = time.Split(':');
                if (hm == null || hm.Length != 2)
                    return date;
                int hour = ToInt(hm[0], 0);
                int minute = ToInt(hm[1], 0);
                return new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            }
            catch (Exception ex)
            {
            }
            return date;
        }
        public static string GetNameOfDayDate(this DateTime ti)
        {
            DayOfWeek nameday = ti.DayOfWeek;
            string Text = "";
            switch (nameday)
            {
                case DayOfWeek.Saturday:
                    Text = "شنبه";
                    break;
                case DayOfWeek.Sunday:

                    Text = "یک شنبه";
                    break;
                case DayOfWeek.Monday:
                    Text = "دوشنبه";

                    break;
                case DayOfWeek.Tuesday:
                    Text = "سه شنبه";
                    break;

                case DayOfWeek.Wednesday:
                    Text = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    Text = "پنج شنبه";
                    break;

                case DayOfWeek.Friday:
                    Text = "جمعه";
                    break;

            }

            return Text;
        }
        public static string FixTime(string time)
        {
            try
            {
                if (time.IndexOf(':') < 0)
                {
                    int t = ToInt(time, -1);
                    if (t == -1)
                        return "";
                    if (0 <= t && t <= 23)
                        return string.Format("{0}:00", t.ToString().PadLeft(2, '0'));
                    if (0 <= t && t <= 59)
                        return string.Format("00:{0}", t.ToString().PadLeft(2, '0'));
                    return "";
                }
                else
                {
                    string[] hm = time.Split(':');
                    if (hm.Length != 2)
                        return "";
                    int h = ToInt(hm[0], -1);
                    if (h == -1)
                        return "";
                    int m = ToInt(hm[1], -1);
                    if (m == -1)
                        return "";
                    if (0 <= h && h <= 23)
                        if (0 <= m && m <= 59)
                            return string.Format("{0}:{1}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'));
                }
            }
            catch
            {
            }
            return "";
        }
        #endregion

        #region Convert DataTable To Class

        /// <summary>
        /// ارسال مقادیر از یک شی به شی دیگر
        /// </summary>
        /// <typeparam name="TSource">شی اصلی برای ارسال مقادیر</typeparam>
        /// <typeparam name="TDestination">شی مقصد برای دریافت اطلاعات</typeparam>
        /// <param name="emp">اطلاعات شی اصلی</param>
        /// <returns></returns>
        public static TDestination Mapper<TSource, TDestination>(this object emp)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TSource, TDestination>()
                );
            //Using automapper
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<TDestination>(emp);
            //OR
            //var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            return empDTO;
        }
        public static object Mapper<TSource, TDestination>(this object Source, object Destination)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TSource, TDestination>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map(Source, Destination);
            return data;
        }

        public static List<TDestination> MapperList<TSource, TDestination>(this object emp)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AllowNullCollections = true;
                //cfg.AllowNullDestinationValues = true;
                cfg.CreateMap<TSource, TDestination>();
            });
            //Using automapper
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<List<TDestination>>(emp);
            //OR
            //var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            return empDTO.ToList();
        }

        //public static List<T> ConvertDataTable<T>(DataTable dt)
        //{
        //    List<T> data = new List<T>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        T item = DataRowToClass<T>(row);
        //        data.Add(item);
        //    }
        //    return data;
        //}
        //public static T DataRowToClass<T>(DataRow dr)
        //{
        //    Type temp = typeof(T);
        //    T obj = Activator.CreateInstance<T>();

        //    foreach (DataColumn column in dr.Table.Columns)
        //    {
        //        foreach (PropertyInfo pro in temp.GetProperties())
        //        {
        //            if (pro.Name == column.ColumnName)
        //                pro.SetValue(obj, dr[column.ColumnName], null);
        //            else
        //                continue;
        //        }
        //    }
        //    return obj;
        //}

        /// <summary>
        /// تبدیل دیتاتیبل به یک ابجک یا کلاس
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        //public static List<T> ConvertDataTable<T>(this DataTable dt)
        //{
        //    List<T> data = new List<T>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        T item = DataRowToClass<T>(row);
        //        data.Add(item);
        //    }
        //    return data;
        //}
        //private static T DataRowToClass<T>(DataRow dr)
        //{
        //    Type temp = typeof(T);
        //    T obj = Activator.CreateInstance<T>();

        //    foreach (DataColumn column in dr.Table.Columns)
        //    {
        //        foreach (PropertyInfo pro in temp.GetProperties())
        //        {
        //            //in case you have a enum/GUID datatype in your model
        //            //We will check field's dataType, and convert the value in it.
        //            if (pro.Name == column.ColumnName)
        //            {
        //                try
        //                {
        //                    var convertedValue = GetValueByDataType(pro.PropertyType, dr[column.ColumnName]);
        //                    pro.SetValue(obj, convertedValue, null);
        //                }
        //                catch (Exception e)
        //                {
        //                    //ex handle code                   
        //                    string err = e.Message;
        //                }
        //                //pro.SetValue(obj, dr[column.ColumnName], null);
        //            }
        //            else
        //                continue;
        //        }
        //    }
        //    return obj;
        //}
        //private static object GetValueByDataType(Type propertyType, object o)
        //{
        //    if (propertyType == (typeof(Guid)) || propertyType == typeof(Guid?))
        //    {
        //        return Guid.Parse(o.ToString());
        //    }
        //    else if (o == null)
        //    {
        //        return null;
        //    }
        //    else if (propertyType == typeof(int) || propertyType.IsEnum)
        //    {
        //        return Convert.ToInt32(o);
        //    }
        //    else if (propertyType == typeof(decimal))
        //    {
        //        if (o == null) return 0;
        //        if (string.IsNullOrEmpty(o.ToString())) return 0;
        //        else
        //            return Convert.ToDecimal(o);
        //    }
        //    else if (propertyType == typeof(long))
        //    {
        //        return Convert.ToInt64(o);
        //    }
        //    else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
        //    {
        //        return Convert.ToBoolean(o);
        //    }
        //    else if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
        //    {
        //        return Convert.ToDateTime(o);
        //    }

        //    else if (propertyType == typeof(string) || propertyType == typeof(string))
        //    {
        //        return Convert.ToString(o);
        //    }

        //    else if (DBNull.Value == o) return null;
        //    else if (o.ToString() == "null")
        //    {
        //        return null;
        //    }

        //    return o.ToString();
        //}
        #endregion

        #region Converting DateType

        public static string ToEmptyString(this object obj)
        {
            if (obj == null) return string.Empty;
            if (string.IsNullOrEmpty(obj.ToString())) return string.Empty;
            else
                return obj.ToString();
        }
        public static int ToInt(this object obj)
        {
            try
            {
                if (obj == null) return 0;
                else
                    return Convert.ToInt32(obj);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static int? ToIntNullable(this object obj)
        {
            try
            {
                if (obj == null) return null;
                else
                    return Convert.ToInt32(obj);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static long ToLong(this object obj)
        {
            try
            {
                if (obj == null) return 0;
                else
                    return Convert.ToInt64(obj);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static long? ToLongNullable(this object obj)
        {
            try
            {
                if (obj == null) return null;
                else
                    return Convert.ToInt64(obj);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static int ToInt(object value, int defaultValue)
        {
            if (value == null)
                return defaultValue;
            int res;
            if (int.TryParse(value.ToString(), out res))
                return res;
            try
            {
                return Convert.ToInt32(value);
            }
            catch { }
            return defaultValue;
        }
        public static long ToLong(object value, long defaultValue)
        {
            if (value == null)
                return defaultValue;
            long res;
            if (long.TryParse(value.ToString(), out res))
                return res;
            try
            {
                return Convert.ToInt64(value);
            }
            catch { }
            return defaultValue;
        }
        public static float ToFloat(object value, int defaultValue)
        {
            if (value == null)
                return defaultValue;
            float res;
            if (float.TryParse(value.ToString(), out res))
                return res;
            try
            {
                return Convert.ToSingle(value);
            }
            catch { }
            return defaultValue;
        }
        public static double ToDouble(object value, double defaultValue)
        {
            if (value == null)
                return defaultValue;
            double res;
            if (double.TryParse(value.ToString(), out res))
                return res;
            try
            {
                return Convert.ToDouble(value);
            }
            catch { }
            return defaultValue;
        }
        public static decimal ToDecimal(object value, decimal defaultValue)
        {
            if (value == null)
                return defaultValue;
            decimal res;
            if (decimal.TryParse(value.ToString(), out res))
                return res;
            try
            {
                return Convert.ToDecimal(value);
            }
            catch { }
            return defaultValue;
        }
        public static long? ToLongNullAbl(this object value)
        {
            try
            {
                if (value == null) return null;
                return Convert.ToInt64(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int? ToIntNullAbl(this object value)
        {
            try
            {
                if (value == null) return null;
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static decimal ToDecimal(this object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal? ToDecimalNullable(this object value)
        {
            try
            {
                if (value == null) return null;
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static double ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static double? ToDoubleNullable(this object value)
        {
            try
            {
                if (value == null) return null;
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ToBool(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool? ToBoolNullable(this object value)
        {
            try
            {
                if (value == null) return null;
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime ToDateTime(this object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
        public static DateTime? ToDateTimeNullable(this object value)
        {
            try
            {
                if (value == null) return null;
                return Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        /// <summary>
        /// کد گذاری امنیتی کدها
        /// </summary>
        public static void ProtectConnectionString()
        {
            ToggleConnectionStringProtection(AppDomain.CurrentDomain.BaseDirectory, true);
        }

        /// <summary>
        /// دی کد کردن اطلاعات
        /// </summary>
		public static void UnprotectConnectionString()
        {
            ToggleConnectionStringProtection(AppDomain.CurrentDomain.BaseDirectory, false);
        }

        /// <summary>
        /// کدگذاری فایل تنظیمات
        /// </summary>
        /// <param name="pathName">مسیر فایل اجرایی برنامه</param>
        /// <param name="protect">ایا فایل تنظیمات کدگذاری شود یا خیر</param>
		static void ToggleConnectionStringProtection(string pathName, bool protect)
        {
            // Define the Dpapi provider name.
            string strProvider = "DataProtectionConfigurationProvider";
            // string strProvider = "RSAProtectedConfigurationProvider";
            System.Configuration.Configuration oConfiguration = null;
            System.Configuration.ConnectionStringsSection oSection = null;

            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    oConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                }
                else
                {
                    oConfiguration = ConfigurationManager.OpenExeConfiguration(pathName);
                }

                if (oConfiguration != null)
                {
                    bool blnChanged = false;
                    oSection = oConfiguration.GetSection("connectionStrings") as System.Configuration.ConnectionStringsSection;
                    if (oSection != null)
                    {
                        if ((!(oSection.ElementInformation.IsLocked)) && (!(oSection.SectionInformation.IsLocked)))
                        {
                            if (protect)
                            {
                                if (!(oSection.SectionInformation.IsProtected))
                                {
                                    blnChanged = true;
                                    // Encrypt the section.
                                    oSection.SectionInformation.ProtectSection(strProvider);
                                }
                            }
                            else
                            {
                                if (oSection.SectionInformation.IsProtected)
                                {
                                    blnChanged = true;
                                    // Remove encryption.
                                    oSection.SectionInformation.UnprotectSection();
                                }
                            }
                        }

                        if (blnChanged)
                        {
                            // Indicates whether the associated configuration section will be saved even if it has not been modified.
                            oSection.SectionInformation.ForceSave = true;

                            // Save the current configuration.
                            oConfiguration.Save();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
        }
        public static string PasswordEncrypt(this string inText)
        {

            try
            {
                string key = "Heyzha@2228932_SanSystem";
                byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
                using (Aes aes__1 = Aes.Create())
                {
                    Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] {
                0x49,
                0x76,
                0x61,
                0x6e,
                0x20,
                0x4d,
                0x65,
                0x64,
                0x76,
                0x65,
                0x64,
                0x65,
                0x76
            });

                    aes__1.Key = crypto.GetBytes(32);
                    aes__1.IV = crypto.GetBytes(16);
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        using (CryptoStream cStream = new CryptoStream(mStream, aes__1.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cStream.Write(bytesBuff, 0, bytesBuff.Length);
                            cStream.Close();
                        }
                        inText = Convert.ToBase64String(mStream.ToArray());
                    }
                }
                return inText;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static void WriteLogFile(string text)
        {
            FileStream FileStream;
            string StrPath = System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog.txt");

            if (File.Exists(StrPath))
            {
                FileStream = new FileStream(StrPath, FileMode.Append, FileAccess.Write);
            }
            else
            {
                FileStream = new FileStream(StrPath, FileMode.Create, FileAccess.Write);
            }


            using (StreamWriter StreamWriter = new StreamWriter(FileStream))
            {
                StreamWriter.WriteLine(string.Format("Error:{0} --  DateTime:{1}", text, DateTime.Now.JulianToPersianDateTime()));
                StreamWriter.WriteLine("-----------------------------------------------");

                StreamWriter.Close();
                FileStream.Close();
            }

        }
    }
}











