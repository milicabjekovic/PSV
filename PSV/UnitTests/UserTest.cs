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
        public async void UserRegistration()
        {
            UserController controller = new UserController();

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

            var result = await controller.RegisterUser(user);


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UserLogImAsync()
        {
            TokenController controller = new TokenController();

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

            var result = await controller.Post(user);


            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async void UserGetDoctors()
        {
            UserController controller = new UserController();

            var result = await controller.GetAllDoctors();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void UserAddChoosenDoctor()
        {
            UserController controller = new UserController();

            User doc = new User();
            doc.UserType = UserType.Doctor;
            doc.Id = 1;

            var result = await controller.AddChoosenDoctor(doc.Id);

            Assert.IsNotNull(result);
        }

    }
}
