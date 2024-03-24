namespace cs_test.Contracts.User;

public class UpdateUserResponse
{
  public UpdateUserResponse(bool isNewlyCreated)
  {
    IsNewlyCreated = isNewlyCreated;
  }

  public bool IsNewlyCreated { get; set; }
}