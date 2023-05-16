using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISqlService
    {
        Task AddSql(Sql sql);
        Task DeleteSql(int id);
        Task UpdateSql(Sql sql);
        Task<List<Sql>> GetAllSql();
        Task<Sql> GetSql(int id);
    }
}
