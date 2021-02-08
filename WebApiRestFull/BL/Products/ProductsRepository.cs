using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using UtilitiesMethod;


namespace BL
{
    public class ProductsRepository
    {
        internal GenericRepository<TblGroupKala> _groupsProduct { get; set; }
        internal GenericRepository<TblKala> _products { get; set; }
        internal GenericRepository<TblExpAshpazkhane> _descriptionFoods { get; set; }
        internal GenericRepository<tblAnbar> _stores { get; set; }
        internal GenericRepository<TblVahedKalaAsli> _Units { get; set; }
        internal GenericRepository<tblPriceChangeKala> _PriceChangeKala { get; set; }
        internal GenericRepository<TblKardeksKala> _cardeks { get; set; }



        public ProductsRepository()
        {
            _groupsProduct = new GenericRepository<TblGroupKala>(DBAccess.GetNewContext());
            _products = new GenericRepository<TblKala>(DBAccess.GetNewContext());
            _descriptionFoods = new GenericRepository<TblExpAshpazkhane>(DBAccess.GetNewContext());
            _stores = new GenericRepository<tblAnbar>(DBAccess.GetNewContext());
            _Units = new GenericRepository<TblVahedKalaAsli>(DBAccess.GetNewContext());
            _PriceChangeKala = new GenericRepository<tblPriceChangeKala>(DBAccess.GetNewContext());
            _cardeks = new GenericRepository<TblKardeksKala>(DBAccess.GetNewContext());

        }

        #region Groups
        public List<TblGroupKala> GetAllGroups()
        {
            return _groupsProduct.All().ToList();
        }

        public TblGroupKala GetGroupByID(int ID)
        {
            return _groupsProduct.FindByCondition(c => c.ID_Group == ID);
        }

        public List<TblGroupKala> GetGroupsByNotType(string typegroup)
        {
            return _groupsProduct.FindAll(g => !g.TypeGroup.Contains(typegroup)).ToList();
            //return _groupsProduct.ExecuteCommand("SELECT * FROM [dbo].[TblGroupKala] WHERE [TblGroupKala].[TypeGroup]<>N'" + typegroup + "'").ToList<TblGroupKala>();
        }

        #endregion

        #region Products

        public List<TblKala> GetAllProducts()
        {
            return _products.All().ToList();
        }
        public List<ProductReport> GetFildUsage()
        {
            //string sql = @"
            //        SELECT [ID_Kala],[Name_Kala],[Fk_GroupKala],[Fk_VahedKalaAsli]
            //        ,[GheymatForoshAsli],[DarsadTakhfif],[DarsadMaliyat],[MoafMaliyat]
            //        ,[HadaghalMovjodi],[ControlCount],[Status],[Tozihat]
            //        ,[MojodiAvalDore],[IsOnline],[Fk_Anbar]
            //        FROM [dbo].[TblKala] WHERE [Status]=1";
            //var li = db.Database.SqlQuery<sp_GetKalaSale>("sp_GetKalaSale").ToList();

            return _products.ExecuteCommand<ProductReport>("sp_GetKalaSale").ToList();
        }
        public List<ProductReport> GetByGroupID(int IDGroup)
        {
            string sql = @"
                    SELECT [ID_Kala],[Name_Kala],[Fk_GroupKala],[Fk_VahedKalaAsli]
                    ,[GheymatForoshAsli],[DarsadTakhfif],[DarsadMaliyat],[MoafMaliyat]
                    ,[HadaghalMovjodi],[ControlCount],[Status],[Tozihat]
                    ,[MojodiAvalDore],[IsOnline]
                    FROM [dbo].[TblKala] WHERE [Status]=1 and [Fk_GroupKala]=" + IDGroup;
            //return db.Database.SqlQuery<sp_GetKalaSale>(sql).ToList<sp_GetKalaSale>();
            return _products.ExecuteCommand<ProductReport>(sql).ToList<ProductReport>();
        }
        public TblKala GetProductByID(int ID)
        {
            return _products.FindByCondition(c => c.ID_Kala == ID);
        }
        public List<ProductReport> GetListFavoritFood(string listIDKala)
        {
            string sql = @"
                    SELECT [ID_Kala],[Name_Kala],[Fk_GroupKala],[Fk_VahedKalaAsli]
                    ,[GheymatForoshAsli],[DarsadTakhfif],[DarsadMaliyat],[MoafMaliyat]
                    ,[HadaghalMovjodi],[ControlCount],[Status],[Tozihat]
                    ,[MojodiAvalDore],[IsOnline],[Fk_Anbar]
                    FROM [dbo].[TblKala] WHERE [Status]=1 AND [ID_Kala] IN(" + listIDKala + ")";

            //return db.Database.SqlQuery<sp_GetKalaSale>(sql).ToList<sp_GetKalaSale>();
            return _products.ExecuteCommand<ProductReport>(sql).ToList<ProductReport>();

        }


        public int InsertProduct(TblKala product)
        {
            return _products.Insert(product);
        }
        public int UpdateProduct(TblKala product)
        {
            return _products.Update(product.ID_Kala, product);
        }

        #endregion

        #region DescriptonsFoods
        public List<TblExpAshpazkhane> GetDescriptionfoods()
        {
            return _descriptionFoods.All().ToList();
        }
        public TblExpAshpazkhane GetDescriptionfoodsByID(int id)
        {
            return _descriptionFoods.FindByCondition(c => c.ID == id);
        }
        public int UpdateDescrioptionFoods(TblExpAshpazkhane descrip)
        {
            return _descriptionFoods.Update(descrip.ID, descrip);
        }
        #endregion

        #region Store

        public List<tblAnbar> GetAllStore()
        {
            return _stores.All().ToList();
        }
        public int DeleteStore(int idStore)
        {
            return _stores.Delete(_stores.FindByCondition(c => c.ID_Anbar == idStore));
        }

        #endregion

        #region Units
        public List<TblVahedKalaAsli> GetAllUnits()
        {
            return _Units.All().ToList();
        }
        public int DeleteUnits(int idunit)
        {
            return _Units.Delete(_Units.FindByCondition(c => c.ID_Vahed == idunit));
        }

        #endregion

        #region PriceChangeKala
        public int InsertPriceChangeKala(tblPriceChangeKala changeprice)
        {
            return _PriceChangeKala.Insert(changeprice);
        }
        #endregion

        #region  cardeks

        public List<TblKardeksKala> GetCardeks()
        {
            return _cardeks.All().Where(c => c.Kardekskala_Mande > 0).ToList();
        }

        public List<TblKardeksKala> GetCardeks(DateTime fromdt, DateTime todt)
        {
            return _cardeks.All().Where(c => c.Kardekskala_Mande > 0 && c.Kardekskala_Date.Value.ToDateTimeNullable() >= fromdt && c.Kardekskala_Date.Value.ToDateTimeNullable() <= todt).ToList();
        }

        #endregion


    }
}
