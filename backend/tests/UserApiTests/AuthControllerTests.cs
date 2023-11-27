using Xunit;
using Moq;
using UserApi.Services;
using UserApi.Controllers;
using UserApi.Models;
using Microsoft.AspNetCore.Mvc;

public class AuthControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _controller = new AuthController(_mockUserService.Object);
    }

    [Fact]
    public async Task Authenticate_ValidUser_ReturnsOkResultWithToken()
    {
        // Arrange
        var request = new AuthenticateRequest { Username = "testuser", Password = "testpassword" };
        var response = new AuthenticateResponse { Username = "testuser", Token = "testtoken" };
        _mockUserService.Setup(service => service.Authenticate(request)).ReturnsAsync(response);

        // Act
        var result = await _controller.Login(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<AuthenticateResponse>(okResult.Value);
        Assert.Equal("testuser", returnValue.Username);
        Assert.Equal("testtoken", returnValue.Token);
    }
}
