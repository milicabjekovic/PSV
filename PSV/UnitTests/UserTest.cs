using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Controllers;
using PSV.Model;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserRegistration()
        {
            PSV.Configuration.ProjectConfiguration config = new PSV.Configuration.ProjectConfiguration();
            config.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psv;Trusted_Connection=True";
            UserController controller = new UserController(config);

            User user = new User();
            user.Address = "bb";
            user.ChoosenDoctor = null;
            user.City = "Novi Sad";
            user.Country = "srb";
            user.Deleted = false;
            user.Email = "test@gmail.com";
            user.FirstName = "m";
            user.IsBlocked = false;
            user.IsFirstTime = false;
            user.LastName = "m";
            user.Password = "123";
            user.PhoneNumber = "99";
            user.Specialization = "kardiolog";
            user.UserType = UserType.Doctor;

            var result = controller.RegisterUser(user);


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserLogImAsync()
        {
            PSV.Configuration.ProjectConfiguration config = new PSV.Configuration.ProjectConfiguration();
            config.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psv;Trusted_Connection=True";
            TokenController controller = new TokenController(config);

            User user = new User();
            user.Address = "bb";
            user.ChoosenDoctor = null;
            user.City = "Novi Sad";
            user.Country = "srb";
            user.Deleted = false;
            user.Email = "test@gmail.com";
            user.FirstName = "m";
            user.IsBlocked = false;
            user.IsFirstTime = false;
            user.LastName = "m";
            user.Password = "123";
            user.PhoneNumber = "99";
            user.Specialization = "kardiolog";
            user.UserType = UserType.Doctor;

            var result = controller.Post(user);


            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void UserGetDoctors()
        {
            PSV.Configuration.ProjectConfiguration config = new PSV.Configuration.ProjectConfiguration();
            config.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psv;Trusted_Connection=True";
            UserController controller = new UserController(config);

            var result = controller.GetAllDoctors();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserAddChoosenDoctor()
        {
            PSV.Configuration.ProjectConfiguration config = new PSV.Configuration.ProjectConfiguration();
            config.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psv;Trusted_Connection=True";
            UserController controller = new UserController(config);

            User doc = new User();
            doc.UserType = UserType.Doctor;
            doc.Id = 1;

            var result = controller.AddChoosenDoctor(doc.Id);

            Assert.IsNotNull(result);
        }

    }
}
