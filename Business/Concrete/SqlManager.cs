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
    public class SqlManager : ISqlService
    {
        ISqlDal _sqlDal;
        public SqlManager(ISqlDal sqlDal)
        {
            _sqlDal = sqlDal;
        }
        public async Task<IResult> AddSql(Sql sql,string createdBy)
        {
            await _sqlDal.AddAsync(sql, createdBy);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteSql(int id)
        {
            await _sqlDal.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Sql>>> GetAllSql()
        {
            return new SuccessDataResult<List<Sql>>( await _sqlDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Sql>>> GetBySql(int id)
        {
            return new SuccessDataResult<List<Sql>>(await _sqlDal.GetAllAsync(x=>x.ProjectId==id)); 
        }

        public async Task<IDataResult<Sql>> GetSql(int id)
        {
            return new SuccessDataResult<Sql>(await _sqlDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateSql(Sql sql, string updatedBy)
        {
            await _sqlDal.UpdateAsync(sql, updatedBy);
            return new SuccessResult();
        }
    }
}
