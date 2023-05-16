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
    public class JumpManager : IJumpService
    {
        IJumpDal _jumpDal;
        public JumpManager(IJumpDal jumpDal)
        {
            _jumpDal = jumpDal;
        }
        public async Task AddJump(Jump jump)
        {
            await _jumpDal.AddAsync(jump);
        }

        public async Task DeleteJump(int id)
        {
            await _jumpDal.DeleteAsync(id);
        }

        public async Task<List<Jump>> GetAllJump()
        {
            return await _jumpDal.GetAllAsync();
        }

        public async Task<Jump> GetJump(int id)
        {
            return await _jumpDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateJump(Jump jump)
        {
            await _jumpDal.UpdateAsync(jump);
        }
    }
}
