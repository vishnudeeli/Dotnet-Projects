using PieShop.DataAccess.Repository.IRepository;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.DataAccess.Repository
{
    public class PieRepository : Repository<Pie>, IPieRepository
    {
        private readonly PieShopDbContext _db;
        public PieRepository(PieShopDbContext db) : base(db)
        {
            _db = db;

        }
    }
}
