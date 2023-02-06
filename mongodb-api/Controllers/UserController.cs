using Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Services;
using System.Security.Authentication;

namespace mongodb_api.Controllers;

[ApiController]
[Route("users")]
public class UserController:ControllerBase
{
    public readonly UsersServices _usersServices;

    public UserController(UsersServices usersServices)
    {
        _usersServices = usersServices;
    }

    [HttpGet]
    public async Task<List<User>> Get() =>
        await _usersServices.GetAsync();

}
