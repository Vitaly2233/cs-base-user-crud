namespace cs_test.Contracts.User;

public class CreateUserRequest
{
  public required string Username { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
}