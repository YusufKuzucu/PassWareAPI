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
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public async Task AddCompany(Company company)
        {
            await _companyDal.AddAsync(company);
        }

        public async Task DeleteCompany(int id)
        {
            await _companyDal.DeleteAsync(id);
        }

        public async Task<List<Company>> GetAllCompany()
        {
           return await _companyDal.GetAllAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await _companyDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateCompany(Company company)
        {
            await _companyDal.UpdateAsync(company);
        }
    }
}
