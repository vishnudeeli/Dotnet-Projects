using Microsoft.EntityFrameworkCore;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PieShop.DataAccess
{
    public class PieShopDbContext:DbContext
    {
        public PieShopDbContext(DbContextOptions<PieShopDbContext> options):base(options)
        {

        }
        public DbSet<Pie> Pies { get; set; }
    }
}
