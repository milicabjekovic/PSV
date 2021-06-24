using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
            
        }

        public User GetUserByEmail(string email)
        {
            return PsvContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return PsvContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }


    }
}
