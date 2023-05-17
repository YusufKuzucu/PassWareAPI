using Core.Utilities.Results;
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
        Task<IResult> AddCompany(Company company);
        Task<IResult> DeleteCompany(int id);
        Task<IResult> UpdateCompany(Company company);
        Task<IDataResult<List<Company>>> GetAllCompany();
        Task<IDataResult<Company>> GetCompany(int id);
    }
}
