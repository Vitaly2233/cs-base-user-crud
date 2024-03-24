namespace cs_test.Models;

public class User
{
  public User(Guid id, string username, string firstName, string lastName)
  {
    Id = id;
    Username = username;
    FirstName = firstName;
    LastName = lastName;
  }

  public Guid Id { get; set; }
  public string Username { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}