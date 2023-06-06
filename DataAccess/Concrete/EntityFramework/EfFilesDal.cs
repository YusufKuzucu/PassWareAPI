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
    public class EfFilesDal : IFilesDal
    {
        public async Task AddAsync(Files entity, string createdBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                entity.CreatedBy = createdBy;
                entity.CreatedDate = DateTime.Now;
                context.Links.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var link = await context.Links.FindAsync(id);
                if (link != null)
                {
                    context.Links.Remove(link);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Files>> GetAllAsync(Expression<Func<Files, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {

                return filter == null
                    ? await context.Set<Files>().ToListAsync()
                    : await context.Set<Files>().Where(filter).ToListAsync();
            }
        }

        public async Task<Files> GetAsync(Expression<Func<Files, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Files>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Files entity, string updatedBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var file = await context.Links.FindAsync(entity.Id);
                if (file != null)
                {
                    file.ConnectExplanation = entity.ConnectExplanation;
                    file.ConnectionInfo = entity.ConnectionInfo;
                    file.UpdatedBy = updatedBy;
                    file.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
