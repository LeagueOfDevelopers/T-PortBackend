using System;
using System.Collections.Generic;
using Moq;
using TPort.Common;
using TPort.Domain.UserManagement;
using TPort.Infrastructure.DataAccess;
using TPort.Services;
using Xunit;

namespace TPortTests
{
    public class AccountManagerTests
    {
        [Fact]
        public void LoadAccountTests()
        {
            // Arrange
            var account = new Account(Guid.NewGuid(),
                new Credentials("empty", "+79999999999"),
                DateTimeOffset.Now,
                new List<Guid>(),
                new List<BankCard>(),
                new List<PassportData>());
            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock
                .Setup(repository => repository.LoadAccount("PhoneNumber"))
                .Returns(account);
            var accountManager = new AccountManager(repositoryMock.Object);
            
            // Act
            var result = accountManager.LoadAccount("PhoneNumber");
            
            // Assert
            Assert.Equal(result, account);
        }
    }
}