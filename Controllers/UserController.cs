using cs_test.Contracts.User;
using cs_test.Models;
using cs_test.ServiceErrors;
using cs_test.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace cs_test.Controllers;

[ApiController]
[Route("users")]
public class UserController : ApiController
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpPost]
  public IActionResult Post(CreateUserRequest request)
  {
    var user = new User(Guid.NewGuid(), request.Username, request.FirstName, request.LastName);
    var createUserResult = _userService.CreateUser(user);

    return createUserResult.Match(_user => CreatedAtGetUser(user), Problem);
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetUser(Guid id)
  {
    ErrorOr<User> getUserResult = _userService.GetUser(id);

    return getUserResult.Match(Ok, Problem);
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    var users = _userService.GetAll();
    return Ok(users);
  }

  [HttpPut("{id:guid}")]
  public IActionResult Update(Guid id, UpdateUserRequest request)
  {
    var newUser = new User(id, request.Username, request.FirstName, request.LastName);
    ErrorOr<UpdateUserResponse> response = _userService.UpdateUser(newUser);
    return response.Match(updated => updated.IsNewlyCreated ? CreatedAtGetUser(newUser) : NoContent(), Problem);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult Delete(Guid id)
  {
    var result = _userService.DeleteUser(id);

    return result.Match(
      deleted => NoContent(),
      Problem);
  }

  private CreatedAtActionResult CreatedAtGetUser(User user)
  {
    return CreatedAtAction(
        actionName: nameof(GetUser),
        routeValues: new { id = user.Id },
        value: user);
  }
}