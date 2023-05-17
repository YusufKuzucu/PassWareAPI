using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectService
    {
        Task<IResult> AddProject(Project project);
        Task<IResult> DeleteProject(int id); 
        Task<IResult> UpdateProject(Project project);
        Task<IDataResult<List<Project>>> GetAllProject(); 
        Task<IDataResult<Project>> GetProject(int id);
    }
}
