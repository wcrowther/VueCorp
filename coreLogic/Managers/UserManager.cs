using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using coreApi.Data;
using coreApi.Data.Interfaces;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using System.Security.Principal;
using WildHare.Extensions;

namespace coreApi.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepo _userRepo;

    public UserManager(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepo.GetAllUsers();
    }

	public User GetUserByUsername(string username)
	{
		return _userRepo.GetUserByUserName(username);
	}

	public User GetUserById(int id)
    {
		return _userRepo.GetUserById(id);
	}

	public User CreateNewUser(AuthSignup model, string passwordHash)
	{
		return _userRepo.CreateNewUser(model, passwordHash);
	}

	public PagedList<User> GetPagedUsers(Pager pager)
	{
		pager ??= new Pager();

		return _userRepo.GetPagedUsers(pager);
	}

	public User SaveUser(User user)
	{
		_userRepo.SaveUser(user);

		return user;
	}
}

// Generate token until Expiration
// private string  OldGenerateJwtToken(AuthenticateResponse authResponse)
//     {
//         var tokenHandler = new JwtSecurityTokenHandler();
//         var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
// 
//         var tokenDescriptor = new SecurityTokenDescriptor
//         {
//             Subject             = new ClaimsIdentity(new[] { new Claim("id", authResponse.Id.ToString()) }),
//             Expires             = authResponse.Expiration,
//             SigningCredentials  = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//         };
// 
//         var token = tokenHandler.CreateToken(tokenDescriptor);
// 
//         return tokenHandler.WriteToken(token);
//     }
// 
// }