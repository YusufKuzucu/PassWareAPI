using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFilesService
    {
        Task<IResult> AddFiles(Files files, string createdBy);
        Task<IResult> DeleteFiles(int id);
        Task<IResult> UpdateFiles(Files files, string updatedBy);
        Task<IDataResult<List<Files>>> GetAllFiles();
        Task<IDataResult<Files>> GetFiles(int id);
        Task<IDataResult<List<Files>>> GetByFiles(int id);
    }
}
