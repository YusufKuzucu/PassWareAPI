using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserById(int userId);
        IResult Add(User user);
        IResult Delete(int userId);
        IResult Update(User user);
        List<OperationClaim> GetClaims(User user);
        User GetUserByMail(string email);

       IDataResult<User> GetUserByIdEmail(string email);



        IDataResult<UserDto> GetUserDtoById(int  id);
        IResult UpdateByDto(UserDto userDto);
        IDataResult<List<UserDto>> GetAllDto();
        IDataResult<UserDto> GetUserDtoByMail(string email);
    }
}
