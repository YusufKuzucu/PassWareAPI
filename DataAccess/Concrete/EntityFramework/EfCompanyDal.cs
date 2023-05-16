using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : ICompanyDal
    {
        public async Task AddAsync(Company entity)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                context.Companys.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                var company = await context.Companys.FindAsync(id);

                if (company != null)
                {
                    context.Companys.Remove(company);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Company>> GetAllAsync(Expression<Func<Company, bool>> filter = null)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                //return await context.Companys.ToListAsync();
                return filter == null
                   ? await context.Set<Company>().ToListAsync()
                   : await context.Set<Company>().Where(filter).ToListAsync();

            }
        }
        public async Task<Company> GetAsync(Expression<Func<Company, bool>> filter)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                //return await context.Companys.FirstOrDefaultAsync(Id);
                return await context.Set<Company>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Company entity)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                var existingCompany = await context.Companys.FindAsync(entity.Id);
                if (existingCompany != null)
                {
                    existingCompany.CompanyName = entity.CompanyName;
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
