using System.Security.Claims;
using HikingInforamtionSystemCore.Helpers.Auth;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest registerRequest)
    {
        return Ok(await _authService.Register(registerRequest));
    }
    
    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest loginRequest)
    {
        return Ok(await _authService.Login(loginRequest));
    }
    
    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenRequest refreshRequest)
    {
        return Ok(await _authService.RefreshToken(refreshRequest));
    }
    
    [Authorize(Policy = PolicyNames.AdminRole)]
    [HttpPost]
    [Route("change-role")]
    public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRole request)
    {
        await _authService.ChangeUserRole(request, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return Ok(new { Message = "User role updated successfully" });
    }
    
    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet("current-user")]
    public async Task<IActionResult> GetUserById()
    {
        var user = await _authService.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Ok(user);
    }

    [Authorize(Policy = PolicyNames.AdminRole)]
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _authService.GetUsers();
        return Ok(users);
    }
}