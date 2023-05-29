using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly PASSWareDbContext _context;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenIsCreated);
        }

        public IDataResult<User> ForgotMyPassword(string email)
        {
            var user = _userService.GetUserByMail(email);
            if (user == null)
            {
                return new ErrorDataResult<User>("kullanıcı bulunamadı");
            }
            user.VerificationNumber = RandomNumber().ToString();
            _userService.Update(user);

            EmailService emailService = new EmailService();
            emailService.EmailGdr(user.VerificationNumber,email);
            _userService.Update(user);

            return new SuccessDataResult<User>(user.VerificationNumber);

        }

        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserIsNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.LoginIsSuccessful);
        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserIsRegitered);
        }

        public IDataResult<User> ResetPassword(ResetPassword resetPassword)
        {
            var user = _userService.GetUserByMail(resetPassword.Email);
            if (user == null)
            {
                return new ErrorDataResult<User>("Invalid Number");
            }
            HashingHelper.CreatePasswordHash(resetPassword.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.VerificationNumber = null;
            _userService.Update(user);
            return new SuccessDataResult<User>(user);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetUserByMail(email) != null)
            {
                return new ErrorResult(Messages.UserIsAlreadyExists);
            }
            return new SuccessResult();
        }
        private string RandomNumber()
        {
            Random random = new Random();
            random.Next(10000, 100000);
            return random.Next().ToString();
        }
    }


}
