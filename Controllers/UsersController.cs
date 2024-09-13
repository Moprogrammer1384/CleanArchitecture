
using Catalog.API.Abstractions;
using Catalog.API.Application.Contract;
using Catalog.API.Application.Dtos.Users;
using Catalog.API.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class UsersController : ApiController
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
            this._userService = userService;
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync(
        [FromBody] UserRegistrationDto registrationDto)
    {
        var result = await _userService.RegisterUserAsync(registrationDto);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserTokenDto>> LoginUserAsync(
        [FromBody] UserLoginDto loginDto)
    {
        var result = await _userService.LoginUserAsync(loginDto);

        if(result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}
