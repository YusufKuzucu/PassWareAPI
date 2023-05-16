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
        Task AddProject(Project project);
        Task DeleteProject(int id);
        Task UpdateProject(Project project);
        Task<List<Project>> GetAllProject();
        Task<Project> GetProject(int id);
    }
}
