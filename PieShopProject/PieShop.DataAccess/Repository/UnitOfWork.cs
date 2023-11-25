using PieShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private PieShopDbContext _db;
        public UnitOfWork(PieShopDbContext db)
        {
            _db = db;
            Pie = new PieRepository(_db);
            
        }
        public IPieRepository Pie { get; private set; }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
