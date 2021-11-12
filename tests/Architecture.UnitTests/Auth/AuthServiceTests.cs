using Architecture.Application;
using Architecture.Database;
using Architecture.Model;
using DotNetCore.Security;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Architecture.UnitTests.Auth
{
    public class AuthServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IAuthFactory> mockAuthFactory;
        private Mock<IAuthRepository> mockAuthRepository;
        private Mock<IHashService> mockHashService;
        private Mock<IJsonWebTokenService> mockJsonWebTokenService;

        public AuthServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAuthFactory = this.mockRepository.Create<IAuthFactory>();
            this.mockAuthRepository = this.mockRepository.Create<IAuthRepository>();
            this.mockHashService = this.mockRepository.Create<IHashService>();
            this.mockJsonWebTokenService = this.mockRepository.Create<IJsonWebTokenService>();
        }

        private AuthService CreateService()
        {
            return new AuthService(
                this.mockAuthFactory.Object,
                this.mockAuthRepository.Object,
                this.mockHashService.Object,
                this.mockJsonWebTokenService.Object);
        }

        [Fact]
        public async Task AddAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            var authModel = new AuthModel("mocklogin@login.com", "mockpassword", (int)Domain.Roles.User);
            var auth = new Domain.Auth(authModel.Login, authModel.Password, Domain.Roles.User);

            this.mockAuthRepository
                .Setup(s => s.AnyByLoginAsync(authModel.Login))
                .ReturnsAsync(true);

            this.mockAuthFactory
                .Setup(s => s.Create(authModel))
                .Returns(auth);

            this.mockHashService
                .Setup(s => s.Create(auth.Password,auth.Salt))
                .Returns("");

            this.mockAuthRepository
                .Setup(s => s.AddAsync(auth));

            // Act
            var result = await service.AddAsync(
                authModel);

            // Assert
            this.mockAuthRepository
                .Verify(v => v.AnyByLoginAsync(authModel.Login),Times.Once());
        }

        //[Fact]
        //public async Task DeleteAsync_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var service = this.CreateService();
        //    long id = 0;

        //    // Act
        //    await service.DeleteAsync(
        //        id);

        //    // Assert
        //    Assert.True(false);
        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task SignInAsync_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var service = this.CreateService();
        //    SignInModel model = null;

        //    // Act
        //    var result = await service.SignInAsync(
        //        model);

        //    // Assert
        //    Assert.True(false);
        //    this.mockRepository.VerifyAll();
        //}
    }
}
