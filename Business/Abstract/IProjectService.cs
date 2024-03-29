﻿using Core.Utilities.Results;
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
        Task<IResult> AddProject(Project project,string createdBy);
        Task<IResult> DeleteProject(int id);
        Task<IResult> ProjectAllDataDelete(int id);
        Task<IResult> UpdateProject(Project project,string updatedBy);
        Task<IDataResult<List<Project>>> GetAllProject(); 
        Task<IDataResult<Project>> GetProject(int id);
        Task<IDataResult<List<Project>>> GetByProject(int id);
        Task<IDataResult<List<Project>>> GetByProjectName(string name);
    }
}
