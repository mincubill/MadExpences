using NUnit.Framework;
using MadExpences.Data;
using System;

namespace MadExpences.Test
{
    public class UserTest
    {
        UserDao user = new UserDao();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateUser()
        {
            user.CreateUser(Guid.NewGuid().ToString(), "Kurisu4", "Tina4", "kurisutina@madscientist.com4") ;
            Assert.Pass();
        }

        [Test]
        public void ReadUser()
        {
            //var user = new UserDao();
            user.ReadUser("5c6093ed-e079-4c1e-b539-dbef703cbb77");
            Assert.Pass();
        }

        [Test]
        public void UpdateUser()
        {
            //Update user
            //var userId = user.ConvertToObjId("5e7fd22bc5f8ca2c10697dd0");
            user.UpdateUser("5c6093ed-e079-4c1e-b539-dbef703cbb77", "Okabe", "Tina2", "kurisutina@madscientist.com2");
            Assert.Pass();
        }

        [Test]
        public void BlockUser()
        {
            //Block user
            user.BlockUser("5c6093ed-e079-4c1e-b539-dbef703cbb77");
            Assert.Pass();
        }

        [Test]
        public void DeleteUser()
        {
            //Delete user
            user.DeleteUser("5c6093ed-e079-4c1e-b539-dbef703cbb77");
            Assert.Pass();
        }
    }
}