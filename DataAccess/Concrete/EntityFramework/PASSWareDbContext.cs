using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PASSWareDbContext:DbContext
    {
        public DbSet<Company> Companys { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Jump> Jumps { get; set; }
        public DbSet<Sql> Sqls { get; set; }
        public DbSet<Vpn> Vpns { get; set; }
        public DbSet<UI> UIs { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Link> Links { get; set; }




        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=YUSUF_KUZUCU\\SQLEXPRESS;Initial Catalog=PassWare;User Id=yusuf;Password=123456;TrustServerCertificate=true");
            //optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
