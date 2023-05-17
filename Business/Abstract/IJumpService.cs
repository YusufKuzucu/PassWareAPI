using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJumpService
    {
        Task<IResult> AddJump(Jump jump);
        Task<IResult> DeleteJump(int id);
        Task<IResult> UpdateJump(Jump jump);
        Task<IDataResult<List<Jump>>> GetAllJump();
        Task<IDataResult<Jump>> GetJump(int id);

    }
}
