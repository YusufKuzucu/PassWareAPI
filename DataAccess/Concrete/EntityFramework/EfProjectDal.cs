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
