using PSV.Configuration;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Services
{
    public class UserService
    {
        private ProjectConfiguration configuration;

        public UserService(ProjectConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public UserService()
        {
            
        }

        public User Get(int id) {
            try {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext())) {
                    return unitOfWork.Users.Get(id);
                }
            }
            catch (Exception e) {
                return null;
            }

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            try {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Users.GetAll();
                }
            }
            catch (Exception e) {
                return null;
            }
        }


        public IEnumerable<User> GetAllDoctors()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Users.GetAllDoctors();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<User> GetAllDoctorsOpstePrakse()
        {

            IEnumerable<User> doctors = GetAll();
            List<User> lista = new List<User>();

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {

                    foreach (User u in doctors) 
                    {
                        if (u.Specialization.Equals("opsta praksa")) 
                        {
                            //return unitOfWork.Users.GetAllDoctors();
                            lista.Add(u);
                            
                        }
                    
                    }
                    
                    
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return lista;
        }

        public IEnumerable<User> GetAllPatients()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Users.GetAllPatients();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Users.GetUserByEmailAndPassword(email, password);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public User GetUserWithEmail(string email)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Users.GetUserByEmail(email);
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public bool Add(User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    User newUser = new User();

                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;
                    newUser.Email = user.Email;
                    newUser.IsBlocked = false;

                    unitOfWork.Users.Add(newUser);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Boolean RegisterUser(User user)
        {
            

            using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
            {
                User user1 = unitOfWork.Users.GetUserByEmail(user.Email);

                if (user1 != null)
                {
                    return false;
                }

                User newUser = new User();

                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Email = user.Email;
                newUser.Address = user.Address;
                newUser.City = user.City;
                newUser.Country = user.Country;
                newUser.PhoneNumber = user.PhoneNumber;
                newUser.Password = user.Password;
                newUser.UserType = UserType.Patient;
                newUser.Specialization = "";

                unitOfWork.Users.Add(newUser);
                unitOfWork.Complete();
                
                return true;
            }



            
        }

        public bool Edit(int id, User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    User userDB = Get(id);

                    unitOfWork.Users.Update(userDB);

                    
                    userDB.FirstName = user.FirstName;
                    userDB.LastName = user.LastName;
                    userDB.Email = user.Email;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    User users = Get(id);

                    unitOfWork.Users.Remove(users);

                    
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool AddChoosenDoctor(int id, User user )
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    
                        User doctor = unitOfWork.Users.Get(id);

                        unitOfWork.Users.Update(user);
                        user.ChoosenDoctor = doctor;
                        unitOfWork.Complete();
                    
                    
                    
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
