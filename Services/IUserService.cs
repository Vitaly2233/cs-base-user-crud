using cs_test.Contracts.User;
using cs_test.Models;
using ErrorOr;

namespace cs_test.Services;

public interface IUserService
{
  ErrorOr<Created> CreateUser(User request);

  ErrorOr<User> GetUser(Guid id);

  User[] GetAll();

  ErrorOr<UpdateUserResponse> UpdateUser(User user);

  ErrorOr<Deleted> DeleteUser(Guid id);
}