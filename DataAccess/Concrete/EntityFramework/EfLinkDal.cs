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
    public class EfLinkDal : ILinkDal
    {
        public async Task AddAsync(Link entity, string ceratedBy)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                entity.CreatedBy = ceratedBy;
                entity.CreatedDate = DateTime.Now;
                context.Links.Add(entity);
                await context.SaveChangesAsync();  
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var link=await context.Links.FindAsync(id);
                if (link != null)
                {
                    context.Links.Remove(link);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Link>> GetAllAsync(Expression<Func<Link, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {

                return filter == null
                    ? await context.Set<Link>().ToListAsync()
                    : await context.Set<Link>().Where(filter).ToListAsync();
            }
        }

        public async Task<Link> GetAsync(Expression<Func<Link, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Link>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Link entity, string updatedBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var link = await context.Links.FindAsync(entity.Id);
                if (link!=null)
                {
                    link.ConnectExplanation = entity.ConnectExplanation;
                    link.ConnectionInfo = entity.ConnectionInfo;
                    link.UpdatedBy = updatedBy;
                    link.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
