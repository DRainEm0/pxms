using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Wrapper;
using Moq;
using NUnit.Framework;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService userService;
        private readonly Mock<IUserRepository> userRepositoryMock;

        public UserServiceTest()
        {
            var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            userRepositoryMock = new Mock<IUserRepository>();

            repositoryWrapperMock.Setup(x => x.User).Returns(userRepositoryMock.Object);
            userService = new UserService(repositoryWrapperMock.Object);
        }

        [Fact]
        public async Task CreateAsyncNullUserShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => userService.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Account>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsyncExistingUserShouldNotCreateNewUser()
        {
            var newUser = new Account()
            {
                UserId = 1,
                Login = "test",
                Password = "test",
                Email = "test",
                Phone = 1323324,
                Name = "test",
                Surname = "test",
                Photo = "https://sun9-72.userapi.com/impg/riltBTFHuo5xXDa-ldKiijgMof2p9a5uCS_azw/76iZFGBWcDU.jpg?size=1026x800&quality=95&sign=fae7dfb33394bfa84a59c9cdd7fb7146&type=album"
            };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => userService.Create(newUser));
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Account>()), Times.Never);
            Assert.IsType<ArgumentNullException>(ex);
        }

    }
}