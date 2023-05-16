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
    public class EfCommunicationDal : ICommunicationDal
    {
        public async Task AddAsync(Communication entity)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                context.Communications.Add(entity);
                await context.SaveChangesAsync();   
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var communication = await context.Communications.FindAsync(id);
                if (communication!=null)
                {
                    context.Communications.Remove(communication);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Communication>> GetAllAsync(Expression<Func<Communication, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return filter==null
                    ? await context.Set<Communication>().ToListAsync()
                    : await context.Set<Communication>().Where(filter).ToListAsync();
            }
        }

        public async Task<Communication> GetAsync(Expression<Func<Communication, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Communication>().SingleOrDefaultAsync(filter);  
            }
        }

        public async Task UpdateAsync(Communication entity)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var communication = await context.Communications.FindAsync(entity.Id);
                if (communication!=null)
                {
                    communication.InternalNumber = entity.InternalNumber;
                    communication.InternalEmail = entity.InternalEmail;
                    communication.ExternalNumber = entity.ExternalNumber;
                    communication.ExternalEmail = entity.ExternalEmail;
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
