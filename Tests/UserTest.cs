using Hospital.Models;
using Hospital.Repositories;
using Hospital.Servise;
using Xunit;
using Moq;


namespace Tests
{
    public class UserTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRep> _userRepMock;

        public UserTest()
        {
            _userRepMock = new Mock<IUserRep>();
            _userService = new UserService(_userRepMock.Object);
        }

        [Fact]
        public void LoginIsEmptyOrNull_ShouldFail()
        {
            var res = _userService.GetUserByLogin(string.Empty);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid login", res.Error);
        }

        [Fact]
        public void UserIsExist_shouldFail()
        {
            _userRepMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                .Returns(() => null);

            var res = _userService.IsUserExists("nfbgdfnkjh");

            Assert.True(res.IsFailure);
            Assert.Equal("User does not exist", res.Error);
        }

    }
}
