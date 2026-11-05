using NUnit.Framework;

namespace TimeTracking.Business.Tests
{
    [TestFixture]
    public class ChargeAccountServiceTests : TestBase
    {
        private ChargeAccountService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new ChargeAccountService();
        }

        [Test]
        public void GetActiveAccounts_ReturnsSeededAccounts()
        {
            var accounts = _service.GetActiveAccounts();

            Assert.IsNotNull(accounts);
            Assert.IsTrue(accounts.Count >= 8);
        }

        [Test]
        public void GetById_ExistingAccount_ReturnsAccount()
        {
            var account = _service.GetById(1);

            Assert.IsNotNull(account);
            Assert.AreEqual("PROJ-001", account.Code);
        }

        [Test]
        public void GetById_NonExistentAccount_ReturnsNull()
        {
            var account = _service.GetById(999);
            Assert.IsNull(account);
        }

        [Test]
        public void AddChargeAccount_ValidData_ReturnsSuccess()
        {
            var result = _service.AddChargeAccount("TEST-001", "Test account");

            Assert.IsTrue(result.Success);
            Assert.AreEqual("Charge account created successfully.", result.Message);
        }

        [Test]
        public void AddChargeAccount_EmptyCode_ReturnsError()
        {
            var result = _service.AddChargeAccount("", "Description");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Code is required.", result.Message);
        }

        [Test]
        public void AddChargeAccount_NullCode_ReturnsError()
        {
            var result = _service.AddChargeAccount(null, "Description");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Code is required.", result.Message);
        }

        [Test]
        public void AddChargeAccount_EmptyDescription_ReturnsError()
        {
            var result = _service.AddChargeAccount("TEST-002", "");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Description is required.", result.Message);
        }

        [Test]
        public void AddChargeAccount_NullDescription_ReturnsError()
        {
            var result = _service.AddChargeAccount("TEST-003", null);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Description is required.", result.Message);
        }

        [Test]
        public void AddChargeAccount_CodeTooLong_ReturnsError()
        {
            var result = _service.AddChargeAccount("CODE-THAT-IS-WAY-TOO-LONG", "Description");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Code cannot exceed 20 characters.", result.Message);
        }

        [Test]
        public void AddChargeAccount_DuplicateCode_ReturnsError()
        {
            var result = _service.AddChargeAccount("PROJ-001", "Another description");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("A charge account with that code already exists.", result.Message);
        }

        [Test]
        public void AddChargeAccount_NewAccount_AppearsInList()
        {
            _service.AddChargeAccount("NEW-001", "New account");

            var accounts = _service.GetActiveAccounts();
            Assert.IsTrue(accounts.Exists(a => a.Code == "NEW-001"));
        }

        [Test]
        public void AddChargeAccount_CodeIsConvertedToUppercase()
        {
            _service.AddChargeAccount("test-lower", "Lowercase test");

            var accounts = _service.GetActiveAccounts();
            Assert.IsTrue(accounts.Exists(a => a.Code == "TEST-LOWER"));
        }
    }
}
