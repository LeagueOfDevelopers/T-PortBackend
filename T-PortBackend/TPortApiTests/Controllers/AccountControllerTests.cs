using Microsoft.AspNetCore.Mvc;
using Moq;
using TPort.Services;
using TPortApi.Controllers;
using TPortApi.Models.AccountModels;
using TPortApi.Security;
using TPortApiTests.Infrastructure;
using Xunit;

namespace TPortApiTests.Controllers
{
	public class AccountControllerTests
	{
		[Fact]
		public void LoginTest_MessageSent()
		{
			// Arrange
			var accountManagerMock = new Mock<IAccountManager>();
			var jwtIssuerMock = new Mock<IJwtIssuer>();

			var smsManagerStub = new SmsManagerStub();
			var totpManagerMock = new Mock<ITotpManager>();
			var phoneNumber = "+79999999999";
			var totpToken = 1234;

			var loginRequest = new LoginRequest
			{
				Phone = phoneNumber
			};

			totpManagerMock
				.Setup(e => e.GenerateToken(phoneNumber))
				.Returns(1234);
			var accountController = new AccountController(accountManagerMock.Object, jwtIssuerMock.Object,
				smsManagerStub, totpManagerMock.Object);

			// Act
			var result = accountController.Login(loginRequest);

			// Assert
			Assert.NotNull(result as OkResult);
			Assert.True(smsManagerStub.SentMessages.TryGetValue(phoneNumber, out var message));
			Assert.Contains(message, totpToken.ToString());
		}
	}
}