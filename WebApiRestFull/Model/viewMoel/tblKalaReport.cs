using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UtilitiesMethod;


namespace Model
{


    public class ProductReport : TblKala
    {
        //public long ID_Kala { get; set; }
        //public string Name_Kala { get; set; }
        //public long? Fk_GroupKala { get; set; }
        //public long? GheymatForoshAsli { get; set; }
        //public int DarsadTakhfif { get; set; }
        //public int DarsadMaliyat { get; set; }
        //public bool MoafMaliyat { get; set; }
        //public int HadaghalMovjodi { get; set; }
        //public bool ControlCount { get; set; }
        //public bool Status { get; set; }
        //public string Tozihat { get; set; }
        //public double MojodiAvalDore { get; set; }
        //public string MianginFiAvalDovre { get; set; }
        //public bool IsOnline { get; set; }

    }
    public partial class TblKardeksKala
    {
        public string Date_SH
        {
            get
            {
                if (this.Kardekskala_Date.HasValue)
                {
                    return this.Kardekskala_Date.Value.JulianToPersianDate();
                }
                return string.Empty;
            }
        }

    }

}
