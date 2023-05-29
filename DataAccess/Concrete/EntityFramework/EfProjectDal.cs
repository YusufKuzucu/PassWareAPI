using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal : IProjectDal
    {
        public async Task AddAsync(Project entity, string createdBy)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                entity.CreatedBy = createdBy;
                entity.CreatedDate = DateTime.Now;
                context.Projects.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var project = await context.Projects.FindAsync(id);
                if (project != null)
                {
                    context.Projects.Remove(project);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Project>> GetAllAsync(Expression<Func<Project, bool>> filter = null)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return filter==null
                    ? await context.Set<Project>().ToListAsync()
                    : await context.Set<Project>().Where(filter).ToListAsync();
            }
        }

        public async Task<Project> GetAsync(Expression<Func<Project, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return await context.Set<Project>().SingleOrDefaultAsync(filter);

            }
        }

        public async Task ProjectAllDelete(int id)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                var project = await context.Projects.Include(p => p.Jumps)
                    .Include(p => p.Sqls).Include(p => p.Vpns).Include(p => p.UIs).Include(p => p.Communications).Include(p => p.Links)
                    .SingleOrDefaultAsync(p=>p.Id==id);
                if (project==null)
                {
                    return;
                }
                context.Jumps.RemoveRange(project.Jumps);
                context.Sqls.RemoveRange(project.Sqls);
                context.UIs.RemoveRange(project.UIs);
                context.Links.RemoveRange(project.Links);
                context.Vpns.RemoveRange(project.Vpns);
                context.Communications.RemoveRange(project.Communications);
                context.Projects.Remove(project);
                context.SaveChanges();
                 
                    
            }
        }

        public async Task UpdateAsync(Project entity, string updatedBy)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var project = await context.Projects.FindAsync(entity.Id);
                if (project!=null)
                {
                    project.ProjectName = entity.ProjectName;
                    project.ProjectServerIP = entity.ProjectServerIP;
                    project.ProjectServerUserName = entity.ProjectServerUserName;
                    project.ProjectServerPassword = entity.ProjectServerPassword;
                    project.UpdatedBy = updatedBy;
                    project.UpdatedDate = DateTime.Now;

                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
