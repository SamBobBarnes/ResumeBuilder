using Moq;
using ResumeAPI.Database;
using ResumeAPI.Models;
using ResumeAPI.Services;

namespace UnitTests;

public class UserServiceTests
{
    private readonly IUserService _service;
    private readonly Mock<IMySqlContext> _db;

    public UserServiceTests()
    {
        _db = new Mock<IMySqlContext>();
        _service = new UserService(_db.Object);
    }

    [Fact]
    public async Task GetUsers_ReturnsListFromDb()
    {
        var expected = new List<UserViewModel>();
        _db.Setup(x => x.GetUsers()).ReturnsAsync(expected);

        var actual = await _service.GetUsers();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetUser_ReturnUserInfo()
    {
        var username = "test";
        var expected = new UserViewModel
        {
            Username = username
        };
        _db.Setup(x => x.GetUser(username)).ReturnsAsync(expected);

        var actual = await _service.GetUser(username);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task CreateUser_ReturnUserInfo()
    {
        var guid = Guid.NewGuid();
        var user = new UserViewModel()
        {
            Username = "test",
            FirstName = "testname",
            LastName = "testlast",
            Email = "test@test.com"
        };

        var expected = new User
        {
            Username = "test",
            FirstName = "testname",
            LastName = "testlast",
            Email = "test@test.com",
            Id = guid.ToString(),
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        };

        _db.Setup(x => x.CreateUser(It.IsAny<User>())).ReturnsAsync(expected);

        var actual = await _service.CreateUser(user);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task UpdateUser_ReturnUpdatedUserInfo()
    {
        var guid = Guid.NewGuid();
        var userInput = new UserViewModel
        {
            Id = guid.ToString(),
            Username = "test",
            FirstName = "testname",
            LastName = "testlast",
            Email = "test@test.com"
        };
        
        _db.Setup(x => x.UpdateUser(guid,userInput)).ReturnsAsync(userInput);

        var actual = await _service.UpdateUser(guid.ToString(),userInput);

        actual.Should().BeEquivalentTo(userInput);
    }

    [Fact]
    public async Task DeleteUser_ReturnSuccess()
    {
        var guid = Guid.NewGuid();
        _db.Setup(x => x.DeleteUser(guid)).ReturnsAsync(true);

        var actual = await _service.DeleteUser(guid.ToString());

        actual.Should().Be(true);
    }
}