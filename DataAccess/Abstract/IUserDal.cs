using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User Get(Expression<Func<User, bool>> filter);
        void Add(User entity);
        void Delete(int id);
        void Update(User entity);
        List<OperationClaim> GetClaims(User user);
        List<UserDto> GetUsersDtos(Expression<Func<UserDto, bool>> filter = null);
    }
}
