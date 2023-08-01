#nullable disable
namespace ResumeAPI.Models;

public class User : UserViewModel
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

public class UserViewModel : UserInfo
{
    public UserViewModel(UserInfo info)
    {
        Username = info.Username;
        FirstName = info.FirstName;
        LastName = info.LastName;
        Email = info.Email;
    }

    public UserViewModel()
    {
        
    }
    
    protected Guid _id;

    public Guid IdGuid()
    {
        return _id;
    }

    public string Id
    {
        get => _id.ToString();
        set => _id = Guid.Parse(value);
    }
}

public class UserInfo
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string Email { get; set; }
}