using Business.Abstract;
using Core.Utilities.Results;
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
        public async Task<IResult> AddProject(Project project,string createdBy)
        {
           await _projectDal.AddAsync(project, createdBy);
            return new SuccessResult();

        }

        public async Task<IResult> DeleteProject(int id)
        {
            await _projectDal.DeleteAsync(id);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<Project>>> GetAllProject()
        {
            return new SuccessDataResult<List<Project>>( await _projectDal.GetAllAsync());
        }

        public async Task<IDataResult<Project>> GetProject(int id)
        {
            return new SuccessDataResult<Project>(await _projectDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateProject(Project project, string updatedBy)
        {
           await _projectDal.UpdateAsync(project, updatedBy);
            return new SuccessResult();
        }
    }
}
