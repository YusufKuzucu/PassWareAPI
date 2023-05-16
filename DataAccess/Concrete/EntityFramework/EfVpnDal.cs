using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVpnDal : IVpnDal
    {
        public async Task AddAsync(Vpn entity)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                context.Vpns.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var vpn = await context.Vpns.FindAsync(id);
                if (vpn != null)
                {
                    context.Vpns.Remove(vpn);
                    await context.SaveChangesAsync();
                }
            }
           
        }
        public async Task<List<Vpn>> GetAllAsync(Expression<Func<Vpn, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return filter == null
                    ? await context.Set<Vpn>().ToListAsync()
                    :await context.Set<Vpn>().Where(filter).ToListAsync();
            }
        }

        public async Task<Vpn> GetAsync(Expression<Func<Vpn, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Vpn>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Vpn entity)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var vpn = await context.Vpns.FindAsync(entity.Id);
                if (vpn!=null)
                {
                    vpn.VpnProgramName = entity.VpnProgramName;
                    vpn.VpnPassword=entity.VpnPassword;
                    vpn.VpnConnectionAddress = entity.VpnConnectionAddress;
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
