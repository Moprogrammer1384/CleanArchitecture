using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Catalog.API.Application.Contract;
using Catalog.API.Application.Dtos.Users;
using Catalog.API.Infrastructure.Security.Options;
using Catalog.API.Models;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.API.Infrastructure.Security;

public class UserService : IUserService
{    
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly UserServiceOptions _userServiceOptions;

    public UserService(
        IUserRepository userRepository,
        IPasswordService passwordService,
        IOptions<UserServiceOptions> options)
    {
        this._userRepository = userRepository;
        this._passwordService = passwordService;
        this._userServiceOptions = options.Value;
    }

    public async Task<Result<UserTokenDto>> LoginUserAsync(UserLoginDto userLoginDto)
    {
        var users = await _userRepository.FilterAsync(u => u.UserName == userLoginDto.UserName);
        if(!users.Any())
        {
            return Result.Failure<UserTokenDto>("UserName or Password is uncorrect");
        }
        var user = users.FirstOrDefault();

        if(!_passwordService.PasswordVerfication(userLoginDto.Password, user.Password))
        {
            return Result.Failure<UserTokenDto>("UserName or Password is uncorrect");
        }

        var claims = new List<Claim>
        {
            new Claim("sub", user.Id.ToString()),
            new Claim("fullName", user.FullName),
            new Claim("email", user.Email)            
        };
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.Default.GetBytes(_userServiceOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256
        );

        var securityToken = new JwtSecurityToken(
            issuer: "https://localhost:5001/",
            audience: "http://localhost:4200/",
            expires: DateTime.Now.AddMinutes(30),
            claims: claims,
            signingCredentials: signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var idToken = tokenHandler.WriteToken(securityToken);

        return new UserTokenDto(idToken, "");
    }

    public async Task<Result> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
    {
        try
        {
            var userNameIsUnique = await CheckUniqueUserNameAsync(userRegistrationDto.UserName);

            if (!userNameIsUnique)
            {
                // throw new UserNameAlreadyResgisteredException(userRegistrationDto.UserName);

                return Result.Failure($"UserName {userRegistrationDto.UserName} already exists");
            }

            var newUser = new User
            {
                FullName = userRegistrationDto.FullName,
                UserName = userRegistrationDto.UserName,
                Email = userRegistrationDto.Email,
                Password = _passwordService.HashedPassword(userRegistrationDto.Password)
            };

            await _userRepository.AddAsync(newUser);

            return Result.Success();
        }
        catch 
        {
            return Result.Failure("User registration failed!!");
        }
    }

    private async Task<bool> CheckUniqueUserNameAsync(string userName)
    {
        var result = await _userRepository.FilterAsync(u => u.UserName == userName);

        return (!result.Any());
    }
}
