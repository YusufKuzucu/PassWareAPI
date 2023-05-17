using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICompanyDal
    {
        Task<List<Company>> GetAllAsync(Expression<Func<Company, bool>> filter = null);
        Task<Company> GetAsync(Expression<Func<Company, bool>> filter);
        Task AddAsync(Company entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(Company entity);
    }
}
