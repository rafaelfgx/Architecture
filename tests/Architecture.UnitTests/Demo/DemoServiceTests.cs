using Architecture.Application.Demo;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Architecture.UnitTests.Demo
{
    public class DemoServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<DemoService>> mockLogger;

        public DemoServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<DemoService>>();
        }

        private DemoService CreateService()
        {
            return new DemoService(
                this.mockLogger.Object);
        }

        [Fact]
        public void DemoMethod_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string param1 = null;

            // Act
            service.DemoMethod(
                param1);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
