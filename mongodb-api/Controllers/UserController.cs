using Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Services;
using Services.Dtos;
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

    [HttpPost]
    public async Task<ActionResult<User>> Get(DtoInputLogin dto)
    {
        var user = await _usersServices.GetAsync(dto);

        if (user is null)
        {
            return NotFound();
        }
        if(user.Password != dto.Password)
        {
            return Unauthorized();
        }

        return user;
    }

}
