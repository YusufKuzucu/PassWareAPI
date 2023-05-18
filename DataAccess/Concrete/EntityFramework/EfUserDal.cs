using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public void Add(User entity)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public  List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (PASSWareDbContext context=new PASSWareDbContext())
            {
                return filter==null
                    ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public void Update(User entity)
        {
            using (PASSWareDbContext context = new PASSWareDbContext())
            {
                var user=context.Users.Find(entity.Id);
                if (user!=null)
                {
                    user.FirstName = entity.FirstName;
                    user.LastName = entity.LastName;
                    user.PasswordHash = entity.PasswordHash;
                    user.Email = entity.Email;  
                    user.PasswordSalt = entity.PasswordSalt;
                    user.Status = entity.Status;
                    context.SaveChanges();

                }
            }
        }
    }
}
