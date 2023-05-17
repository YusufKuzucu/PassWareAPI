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
    public class EfJumpDal : IJumpDal
    {
        public async Task AddAsync(Jump entity, string createdBy)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                entity.CreatedBy = createdBy;
                entity.CreatedDate = DateTime.Now;
                context.Jumps.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                var jump=await context.Jumps.FindAsync(id);
                if (jump != null)
                {
                    context.Jumps.Remove(jump);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Jump>> GetAllAsync(Expression<Func<Jump, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return filter==null
                    ? await context.Set<Jump>().ToListAsync()
                    : await context.Set<Jump>().Where(filter).ToListAsync();
            }
        }

        public async Task<Jump> GetAsync(Expression<Func<Jump, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Jump>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Jump entity, string updatedBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var jump = await context.Jumps.FindAsync(entity.Id);
                if (jump!=null)
                {

                    jump.JumpServerIP = entity.JumpServerIP;
                    jump.JumpServerUserName= entity.JumpServerUserName;
                    jump.JumpServerPassword= entity.JumpServerPassword;
                    jump.UpdatedBy = updatedBy;
                    jump.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
