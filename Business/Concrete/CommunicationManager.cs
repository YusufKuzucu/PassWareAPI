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
    public class CommunicationManager : ICommunicationService
    {
        ICommunicationDal _communicationDal;
        public CommunicationManager(ICommunicationDal communicationDal)
        {
            _communicationDal = communicationDal;
        }
        public async Task AddCommunication(Communication communication)
        {
            await _communicationDal.AddAsync(communication);
        }

        public async Task DeleteCommunication(int id)
        {
            await _communicationDal.DeleteAsync(id);
        }

        public async Task<List<Communication>> GetAllCommunication()
        {
            return await _communicationDal.GetAllAsync();
        }

        public async Task<Communication> GetCommunication(int id)
        {
            return await _communicationDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateCommunication(Communication communication)
        {
            await _communicationDal.UpdateAsync(communication);
        }
    }
}
