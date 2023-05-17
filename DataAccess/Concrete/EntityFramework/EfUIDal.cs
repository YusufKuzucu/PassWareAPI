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
    public class EfUIDal : IUIDal
    {
        public async Task AddAsync(UI entity, string createdBy)
        {
            using (PASSWareDbContext contex=new PASSWareDbContext())
            {
                entity.CreatedBy = createdBy;
                entity.CreatedDate = DateTime.Now;
                contex.UIs.Add(entity);
                await contex.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                var uı = await context.UIs.FindAsync(id);
                if (uı!=null)
                {
                    context.UIs.Remove(uı);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<UI>> GetAllAsync(Expression<Func<UI, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return filter==null
                    ? await context.Set<UI>().ToListAsync()
                    : await context.Set<UI>().Where(filter).ToListAsync();  
            }
        }

        public async Task<UI> GetAsync(Expression<Func<UI, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<UI>().SingleOrDefaultAsync();
            }
        }

        public async Task UpdateAsync(UI entity, string updatedBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var uı = await context.UIs.FindAsync(entity.Id);
                if (uı!=null)
                {
                    uı.UIServerIP = entity.UIServerIP;
                    uı.UIServerUserName=entity.UIServerUserName;
                    uı.UIServerPassword=entity.UIServerPassword;
                    uı.UpdatedBy = updatedBy;
                    uı.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
