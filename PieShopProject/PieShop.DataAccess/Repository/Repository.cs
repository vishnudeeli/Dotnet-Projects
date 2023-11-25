using Microsoft.EntityFrameworkCore;
using PieShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.DataAccess.Repository
{
    
   public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PieShopDbContext _db;
        internal DbSet<T> dbset;
        public Repository(PieShopDbContext db)
        { 
            _db = db; 
            this.dbset = _db.Set<T>();
        }

        public void Add(T entity) 
        {
            _db.Add(entity);
        }

        virtual public IEnumerable<T> GetAll() 
        {
            IQueryable<T> query = dbset;
            return query.ToList(); 
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter) 
        {
            IQueryable<T> query = dbset; query = query.Where(filter); 
            return query.FirstOrDefault();
        }
    }


}
