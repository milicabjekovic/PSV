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
            return PsvContext.Users.Include(x => x.ChoosenDoctor).Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            //proveri moze li tako
            return PsvContext.Users.Include(x => x.UserType == UserType.Patient).Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return PsvContext.Users.Include(x => x.ChoosenDoctor).Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public List<User> GetAllDoctors() 
        {
            return PsvContext.Users.Include(x => x.ChoosenDoctor).Where(x => x.UserType == UserType.Doctor).ToList();
        }

        public List<User> GetAllPatients()
        {
            return PsvContext.Users.Include(x => x.ChoosenDoctor).Where(x => x.UserType == UserType.Patient).ToList();
        }

    }
}
