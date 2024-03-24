using cs_test.Contracts.User;
using cs_test.Models;
using cs_test.ServiceErrors;
using ErrorOr;

namespace cs_test.Services;

public class UserService : IUserService
{
  private static readonly Dictionary<Guid, User> _users = new();
  public ErrorOr<Created> CreateUser(User request)
  {
    _users.Add(request.Id, request);

    return Result.Created;
  }

  public ErrorOr<User> GetUser(Guid id)
  {
    if (_users.TryGetValue(id, out var user))
    {
      return user;
    }
    return Errors.User.NotFound;
  }

  public User[] GetAll()
  {
    return new List<User>(_users.Values).ToArray();
  }

  public ErrorOr<UpdateUserResponse> UpdateUser(User user)
  {
    var isNewlyCreated = !_users.ContainsKey(user.Id);
    _users[user.Id] = user;
    return new UpdateUserResponse(isNewlyCreated);
  }

  public ErrorOr<Deleted> DeleteUser(Guid id)
  {
    _users.Remove(id);
    return Result.Deleted;
  }
}