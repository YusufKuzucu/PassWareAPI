using Core.Utilities.Results;
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
        Task<IResult> AddSql(Sql sql,string createdBy);
        Task<IResult> DeleteSql(int id); 
        Task<IResult> UpdateSql(Sql sql, string updatedBy);
        Task<IDataResult<List<Sql>>> GetAllSql(); 
        Task<IDataResult<Sql>> GetSql(int id);
        Task<IDataResult<List<Sql>>> GetBySql(int id);

    }
}
