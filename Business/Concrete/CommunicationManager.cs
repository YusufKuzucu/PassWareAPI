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
    public class CommunicationManager : ICommunicationService
    {
        ICommunicationDal _communicationDal;
        public CommunicationManager(ICommunicationDal communicationDal)
        {
            _communicationDal = communicationDal;
        }
        public async Task<IResult> AddCommunication(Communication communication, string createdBy)
        {
            await _communicationDal.AddAsync(communication, createdBy);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteCommunication(int id)
        {
            await _communicationDal.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Communication>>> GetAllCommunication()
        {
            return new SuccessDataResult<List<Communication>>(await _communicationDal.GetAllAsync());
          
        }

        public async Task<IDataResult<List<Communication>>> GetByCommunication(int id)
        {
            return new SuccessDataResult<List<Communication>>(await _communicationDal.GetAllAsync(x=>x.ProjectId==id)) ;
        }

        public async Task<IDataResult<Communication>> GetCommunication(int id)
        {
            return new SuccessDataResult<Communication>(await _communicationDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateCommunication(Communication communication, string updatedBy)
        {
            await _communicationDal.UpdateAsync(communication, updatedBy);
            return new SuccessResult();
        }
    }
}
