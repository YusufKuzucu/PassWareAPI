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
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public async Task<IResult> AddCompany(Company company)
        {
            await _companyDal.AddAsync(company);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteCompany(int id)
        {
            await _companyDal.DeleteAsync(id);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<Company>>> GetAllCompany()
        {
           return new SuccessDataResult<List<Company>>(await _companyDal.GetAllAsync());
        }

        public async Task<IDataResult<Company>> GetCompany(int id)
        {
            return new SuccessDataResult<Company>( await _companyDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateCompany(Company company)
        {
            await _companyDal.UpdateAsync(company);
            return new SuccessResult();
        }
    }
}
