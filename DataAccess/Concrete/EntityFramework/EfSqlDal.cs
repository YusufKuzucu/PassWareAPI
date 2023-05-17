using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSqlDal : ISqlDal
    {
        public async Task AddAsync(Sql entity, string createdBy)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                entity.CreatedBy = createdBy;
                entity.CreatedDate = DateTime.Now;
                context.Sqls.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var sql = await context.Sqls.FindAsync(id);
                if (sql != null)
                {
                    context.Sqls.Remove(sql);
                    await context.SaveChangesAsync();   
                }
            }
        }

        public async Task<List<Sql>> GetAllAsync(Expression<Func<Sql, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return filter==null
                    ? await context.Set<Sql>().ToListAsync()
                    :await context.Set<Sql>().Where(filter).ToListAsync();  
            }
        }

        public async Task<Sql> GetAsync(Expression<Func<Sql, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Sql>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Sql entity, string updatedBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var sql = await context.Sqls.FindAsync(entity.Id);
                if (sql!=null)
                {
                    sql.SqlServerIP = entity.SqlServerIP;
                    sql.SqlServerUserName = entity.SqlServerUserName;
                    sql.SqlServerPassword = entity.SqlServerPassword;
                    sql.UpdatedBy = updatedBy;
                    sql.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
