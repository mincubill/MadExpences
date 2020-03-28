using NUnit.Framework;
using MadExpences.Data;

namespace MadExpences.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostDocument()
        {
            var user = new UserDao();
            user.CreateUser();
            Assert.Pass();
        }

        [Test]
        public void GetDocument()
        {
            var user = new UserDao();
            user.GetUser();
            Assert.Pass();
        }
    }
}