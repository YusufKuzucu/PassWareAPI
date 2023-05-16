using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Task AddCompany(Company company);
        Task DeleteCompany(int id);
        Task UpdateCompany(Company company);
        Task<List<Company>> GetAllCompany();
        Task<Company> GetCompany(int id);
    }
}
