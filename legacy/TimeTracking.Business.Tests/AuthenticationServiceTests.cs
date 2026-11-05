using NUnit.Framework;

namespace TimeTracking.Business.Tests
{
    [TestFixture]
    public class AuthenticationServiceTests : TestBase
    {
        private AuthenticationService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new AuthenticationService();
        }

        [Test]
        public void Login_ValidCredentials_ReturnsUser()
        {
            var user = _service.Login("jgarcia", "Pass123!");

            Assert.IsNotNull(user);
            Assert.AreEqual("jgarcia", user.Username);
            Assert.AreEqual("Juan Garcia Lopez", user.FullName);
        }

        [Test]
        public void Login_WrongPassword_ReturnsNull()
        {
            var user = _service.Login("jgarcia", "wrong");
            Assert.IsNull(user);
        }

        [Test]
        public void Login_NonExistentUser_ReturnsNull()
        {
            var user = _service.Login("nobody", "Pass123!");
            Assert.IsNull(user);
        }

        [Test]
        public void Login_EmptyUsername_ReturnsNull()
        {
            var user = _service.Login("", "Pass123!");
            Assert.IsNull(user);
        }

        [Test]
        public void Login_NullUsername_ReturnsNull()
        {
            var user = _service.Login(null, "Pass123!");
            Assert.IsNull(user);
        }

        [Test]
        public void Login_EmptyPassword_ReturnsNull()
        {
            var user = _service.Login("jgarcia", "");
            Assert.IsNull(user);
        }

        [Test]
        public void Login_NullPassword_ReturnsNull()
        {
            var user = _service.Login("jgarcia", null);
            Assert.IsNull(user);
        }

        [Test]
        public void Login_SecondUser_ReturnsCorrectData()
        {
            var user = _service.Login("mrodriguez", "Pass123!");

            Assert.IsNotNull(user);
            Assert.AreEqual("mrodriguez", user.Username);
            Assert.AreEqual("Maria Rodriguez Fernandez", user.FullName);
            Assert.AreEqual("mrodriguez@company.com", user.Email);
        }

        [Test]
        public void Logout_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => _service.Logout());
        }
    }
}
