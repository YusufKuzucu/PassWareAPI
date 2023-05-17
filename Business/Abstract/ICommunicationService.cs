using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommunicationService
    {
        Task<IResult> AddCommunication(Communication communication);
        Task<IResult> DeleteCommunication(int id);
        Task<IResult> UpdateCommunication(Communication communication);
        Task<IDataResult<List<Communication>>> GetAllCommunication();
        Task<IDataResult<Communication>> GetCommunication(int id);
    }
}
