using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
       

        [TestMethod()]
        public void SaveTest()
        {
            //arange
            var userName = Guid.NewGuid().ToString();


            //act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //arange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            
            //act
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender);
        }
    }
}