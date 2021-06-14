using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbset;

        DbContext _contextCash;
        public GenericRepository(DbContext context)
        {
            _contextCash = context;
            _context = context;
            _dbset = context.Set<TEntity>();

            string con = _context.Database.Connection.ConnectionString;
            sqlcon = new SqlConnection(con);

        }


        #region Get and Find Entity

        public IEnumerable<TEntity> All()
        {
            return _dbset.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicat)
        {
            IEnumerable<TEntity> result = _dbset.AsNoTracking()
                                         .Where(predicat).ToList();
            return result;
        }
        public IEnumerable<TEntity> FindByLasted(Expression<Func<TEntity, bool>> predicat, Expression<Func<TEntity, DateTime>> exorder, int count)
        {
            IEnumerable<TEntity> result = _dbset.AsNoTracking()
                                         .Where(predicat).OrderByDescending(exorder).Take(count).ToList();
            return result;
        }
        public TEntity FindByCondition(Expression<Func<TEntity, bool>> predicat)
        {
            return _dbset.AsNoTracking().Where(predicat).FirstOrDefault();
        }
        public TEntity FindBySingle(Expression<Func<TEntity, bool>> predicat)
        {
            return _dbset.AsNoTracking().SingleOrDefault(predicat);
        }
        public TEntity Find(long id)
        {
            return _dbset.Find(id);
        }

        //public TEntity FindByKey(int id)
        //{
        //    Expression<Func<TEntity, bool>> lambda = Utilities.BuildforLambdaFindbyKey<TEntity>(id);
        //    return _dbset.AsNoTracking().SingleOrDefault(lambda);
        //}

        //public TEntity FindKey(int id)
        //{
        //    Expression<Func<TEntity, bool>> lambda = Utilities.BuildforLambdaFindbyKey<TEntity>(id);
        //    return _dbset.Where(lambda).First();
        //}

        #endregion

        #region Get by Including

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }
        public TEntity FindInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            TEntity results = query.Where(predicate).FirstOrDefault();
            return results;
        }
        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }
        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbset.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        #endregion

        public void UndoAll(DbContext context)
        {
            //detect all changes (probably not required if AutoDetectChanges is set to true)
            context.ChangeTracker.DetectChanges();
            //get all entries that are changed
            var entries = context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();

            //somehow try to discard changes on every entry
            foreach (var dbEntityEntry in entries)
            {
                var entity = dbEntityEntry.Entity;
                if (entity == null) continue;
                if (dbEntityEntry.State == EntityState.Added)
                {
                    //if entity is in Added state, remove it. (there will be problems with Set methods if entity is of proxy type, in that case you need entity base type
                    var set = context.Set(entity.GetType());
                    set.Remove(entity);
                }
                else if (dbEntityEntry.State == EntityState.Modified)
                {
                    //entity is modified... you can set it to Unchanged or Reload it form Db??
                    dbEntityEntry.Reload();
                }
                else if (dbEntityEntry.State == EntityState.Deleted)
                    //entity is deleted... not sure what would be the right thing to do with it... set it to Modifed or Unchanged
                    dbEntityEntry.State = EntityState.Modified;
            }
        }

        #region CRUD (insert - delete - update )

        public int Insert(TEntity entity)
        {
            try
            {
                _dbset.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int InsertAll(List<TEntity> entitys)
        {
            try
            {
                _dbset.AddRange(entitys);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }


        }


        public int Update(long id, TEntity entity)
        {
            /*
             * https://code-maze.com/net-core-web-development-part4/#repository
             * https://gunnarpeipman.com/ef-core-repository-unit-of-work/
             در این حالت با استفاده از متد find
             که شی مورد نظر را براساس کلید اصلی جست و یافت میکند آن با شی جدید که تغییر یافته جایگزین میکنیم
             و زمانی که شی یافت میشود در کش می ماند و ان را درهمان کش تغییر میدهیم و نیازی نیست که دوباره
             شی مورد نظر به کش کانتکس اضافه یا Attach
             شود.اگر خطا داشتیم به خاطر این است که تایع ویراش در حالت 
             GeneticRepository کار نمیکند
             و تابع ذخیره تغییرات باید در یک کلاس دیگر نمونه سازی شود
             
             */
            var existingEntity = Find(id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            try
            {
                if (entity == null) return 0;
                _dbset.Remove(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// برای حذف لیستی از متد GetItems استفاده شود که دیتاها را کش کرده باشد از قبل
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(List<TEntity> entity)
        {
            try
            {
                if (entity == null) return 0;
                //_dbset.Attach(entity);
                _dbset.RemoveRange(entity);
                //_context.Entry(entity).State = EntityState.Deleted;
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                UndoAll(_context);
                return 0;
            }

        }


        #endregion

        #region Excute Query

        SqlCommand sqlcom;
        SqlConnection sqlcon;
        public bool SqlQuery(string sqlstr)
        {
            try
            {

                sqlcom = new SqlCommand(sqlstr, sqlcon);
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                    sqlcon.Open();

                sqlcom.ExecuteNonQuery();

                if (sqlcon.State == System.Data.ConnectionState.Open)
                    sqlcon.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public DataTable SqlQueryGetData(string sqlstr)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string RunProcedure(string sp_Name, string param_Name)
        {
            string value = string.Empty;
            try
            {
                sqlcom = new SqlCommand(sp_Name, sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add("@" + param_Name, SqlDbType.BigInt);
                sqlcom.Parameters["@" + param_Name].Direction = ParameterDirection.Output;

                if (sqlcon.State == System.Data.ConnectionState.Closed)
                    sqlcon.Open();

                sqlcom.ExecuteNonQuery();
                value = Convert.ToString(sqlcom.Parameters["@" + param_Name].Value);
                if (sqlcon.State == System.Data.ConnectionState.Open)
                    sqlcon.Close();
                return value;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        #endregion

        #region QuerySql By Context

        public TEntity GetSqlQueryTracking(string sql)
        {
            TEntity result = _dbset.SqlQuery(sql).AsNoTracking().FirstOrDefault<TEntity>();
            return result;
        }
        public TEntity GetSqlQuery(string sql)
        {
            TEntity result = _dbset.SqlQuery(sql).FirstOrDefault<TEntity>();
            return result;
        }
        public IEnumerable<TEntity> ExecuteCommand(string sql)
        {
            return _context.Database.SqlQuery<TEntity>(sql).ToList<TEntity>();
        }
        public IEnumerable<T> ExecuteCommand<T>(string sql)
        {
            return _context.Database.SqlQuery<T>(sql).ToList<T>();
        }
        public IEnumerable<TEntity> ExecuteCommand(string sql, params object[] parameters)
        {
            return _context.Database.SqlQuery<TEntity>(sql, parameters).ToList<TEntity>();
        }

        #endregion

    }
}
