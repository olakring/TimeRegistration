using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TimeRegistration.Core.Managers.Implementations;
using TimeRegistration.Core.Repositories.Abstructions;

namespace TimeRegistration.Tests.Managers
{
    [TestFixture]
    public class UserManagerTest
    {
        private UserManager _userManager;
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void Given()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userManager = new UserManager(_userRepositoryMock.Object);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        //[TestCase("1")]
        [ExpectedException(typeof(ArgumentException))]
        public void create_user_throw_exception_when_username_is_not_spec(string userName)
        {
            _userManager.CreateUser(userName);
        }

        [Test]
        public void create_user_should_return_userId()
        {
            _userRepositoryMock.Setup(r => r.Insert(It.IsAny<string>())).Returns(100);

            var result =_userManager.CreateUser("random");
            result.Should().Be(100);
        }
    }
}
