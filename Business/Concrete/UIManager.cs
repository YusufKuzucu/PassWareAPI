﻿using Business.Abstract;
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
        public async Task<IResult> AddUI(UI uI,string createdBy)
        {
            await _uıDal.AddAsync(uI, createdBy);
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

        public async Task<IDataResult<List<UI>>> GetByUI(int id)
        {
            return new SuccessDataResult<List<UI>>(await _uıDal.GetAllAsync(x=>x.ProjectId==id)) ;
        }

        public async Task<IDataResult<UI>> GetUI(int id)
        {
            return new SuccessDataResult<UI>(await _uıDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateUI(UI uI, string updatedBy)
        {
            await _uıDal.UpdateAsync(uI, updatedBy);
            return new SuccessResult();
        }
    }
}
