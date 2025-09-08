using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Productivity.Presentation.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    //[Route("register")]
    //public IActionResult Register(RegisterRequest request)
    //{

    //}

    //[Route("login")]
    //public IActionResult Login(LoginRequest request)
    //{

    //}
}
