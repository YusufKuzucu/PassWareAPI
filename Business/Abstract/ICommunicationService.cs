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
        Task AddCommunication(Communication communication);
        Task DeleteCommunication(int id);
        Task UpdateCommunication(Communication communication);
        Task<List<Communication>> GetAllCommunication();
        Task<Communication> GetCommunication(int id);
    }
}
