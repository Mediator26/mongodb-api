using Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Authentication;

namespace mongodb_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    [HttpGet(Name = "GetUser")]
    public IEnumerable<User> FetchAll()
    {
        return new List<User>
        {
            new User { Id = "1", Login = "L1", Password = "P1" },
            new User { Id = "2", Login = "L2", Password = "P2" }
        };
    }
}
