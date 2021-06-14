using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesMethod;

namespace Model
{
    public class Product : TblKala
    {
        public long ProductID { get { return this.ID_Kala; } set { this.ID_Kala = value; } }
        public string ProductName { get { return this.Name_Kala; } set { this.Name_Kala = value; } }
        public long GroupID { get { return this.Fk_GroupKala.Value; } set { this.Fk_GroupKala = value; } }
        public long UnitID { get { return this.Fk_VahedKalaAsli.Value; } set { this.Fk_VahedKalaAsli = value; } }
        public long Price { get { return this.GheymatForoshAsli.Value; } set { this.GheymatForoshAsli = value; } }
        public int DiscountPercent { get { return this.DarsadTakhfif.Value; } set { this.DarsadTakhfif = value; } }
        public long DiscountPrice
        {
            get
            {
                return (this.Price / 100) * this.DiscountPercent;
            }
        }
        public int VatPercent { get { return this.DarsadMaliyat.Value; } set { this.DarsadMaliyat = value; } }
        public long VatPrice
        {
            get
            {
                return (this.Price / 100) * this.VatPercent;
            }
        }
        public bool IsVat { get { return this.MoafMaliyat.Value; } set { this.MoafMaliyat = value; } }
    }
    public class ProductGroup : TblGroupKala
    {
        public long GroupID { get { return this.ID_Group; } set { this.ID_Group = value; } }
        public string GroupName { get { return this.NameGroup; } set { this.NameGroup = value; } }
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
