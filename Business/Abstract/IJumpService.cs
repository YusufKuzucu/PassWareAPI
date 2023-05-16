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
        Task AddJump(Jump jump);
        Task DeleteJump(int id);
        Task UpdateJump(Jump jump);
        Task<List<Jump>> GetAllJump();
        Task<Jump> GetJump(int id);

    }
}
