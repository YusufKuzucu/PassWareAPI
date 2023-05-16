using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {

        IProjectDal _projectDal;
        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
        public async Task AddProject(Project project)
        {
           await _projectDal.AddAsync(project);
        }

        public async Task DeleteProject(int id)
        {
            await _projectDal.DeleteAsync(id);
        }

        public async Task<List<Project>> GetAllProject()
        {
            return await _projectDal.GetAllAsync();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _projectDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateProject(Project project)
        {
           await _projectDal.UpdateAsync(project);
        }
    }
}
