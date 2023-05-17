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
    public class UIManager : IUIService
    {
        IUIDal _uıDal;
        public UIManager(IUIDal uIDal)
        {
            _uıDal = uIDal;
        }
        public async Task<IResult> AddUI(UI uI)
        {
            await _uıDal.AddAsync(uI);
            return new SuccessResult();

        }

        public async Task<IResult> DeleteUI(int id)
        {
            await _uıDal.DeleteAsync(id);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<UI>>> GetAllUI()
        {
            return new SuccessDataResult<List<UI>>( await _uıDal.GetAllAsync());
        }

        public async Task<IDataResult<UI>> GetUI(int id)
        {
            return new SuccessDataResult<UI>(await _uıDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateUI(UI uI)
        {
            await _uıDal.UpdateAsync(uI);
            return new SuccessResult();
        }
    }
}
