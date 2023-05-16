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
    public class SqlManager : ISqlService
    {
        ISqlDal _sqlDal;
        public SqlManager(ISqlDal sqlDal)
        {
            _sqlDal = sqlDal;
        }
        public async Task AddSql(Sql sql)
        {
            await _sqlDal.AddAsync(sql);
        }

        public async Task DeleteSql(int id)
        {
            await _sqlDal.DeleteAsync(id);
        }

        public async Task<List<Sql>> GetAllSql()
        {
            return await _sqlDal.GetAllAsync();
        }

        public async Task<Sql> GetSql(int id)
        {
            return await _sqlDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateSql(Sql sql)
        {
            await _sqlDal.UpdateAsync(sql);
        }
    }
}
