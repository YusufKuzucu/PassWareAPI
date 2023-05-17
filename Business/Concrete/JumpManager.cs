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
    public class JumpManager : IJumpService
    {
        IJumpDal _jumpDal;
        public JumpManager(IJumpDal jumpDal)
        {
            _jumpDal = jumpDal;
        }
        public async Task<IResult> AddJump(Jump jump, string createdBy)
        {
            await _jumpDal.AddAsync(jump, createdBy);
            return new SuccessResult();

        }

        public async Task<IResult> DeleteJump(int id)
        {
            await _jumpDal.DeleteAsync(id);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<Jump>>> GetAllJump()
        {
            return new SuccessDataResult<List<Jump>>( await _jumpDal.GetAllAsync());
        }

        public async Task<IDataResult<Jump>> GetJump(int id)
        {
            return new SuccessDataResult<Jump>(await _jumpDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateJump(Jump jump, string updatedBy)
        {
            await _jumpDal.UpdateAsync(jump, updatedBy);
            return new SuccessResult();
        }
    }
}
