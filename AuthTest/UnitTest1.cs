using ConferenceManager;
using ConferenceManager.Controllers;
using ConferenceManager.Data;
using ConferenceManager.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Net;
using System.Security.Claims;

namespace AuthTest;

[TestFixture]
public class Tests
{
    private AttendeeController _attendeeController;
    private AttendeeService _attendeeService;
    private AttendeeRepository _attendeeRepository;
    private EventsService _eventsService;
    private EventsRepository _eventsRepository;
    private UserService _userService;
    protected TestServer _testServer;

    [SetUp]
    public void Setup()
    {
        _userService = new UserService();
        _eventsRepository = new EventsRepository();
        _eventsService = new EventsService(_eventsRepository);
        _attendeeRepository = new AttendeeRepository();
        _attendeeService = new AttendeeService(_attendeeRepository);
        _attendeeController = new AttendeeController(_attendeeService, _eventsService, _userService);
    }

    public void MockHttpContext(string userId, string role = "")
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };

        if(role != null) claims.Add(new Claim(ClaimTypes.Role, role)); 

        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPricipal = new ClaimsPrincipal(identity);

        var httpContextMock = new Mock<HttpContext>();
        httpContextMock.Setup(x => x.User).Returns(claimsPricipal);

        _attendeeController.ControllerContext = new ControllerContext
        {
            HttpContext = httpContextMock.Object,
        };
    }

    [Test]
    public async Task GetAttendeesNoAdminRole()
    {
        //Arrange
        _testServer = new TestServer(new WebHostBuilder().UseStartup<ConferenceManager.Program>());
        var client = _testServer.CreateClient();
        var url = "api/attendee";
        var expected = HttpStatusCode.Unauthorized;

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.AreEqual(expected, response.StatusCode);
    }
}