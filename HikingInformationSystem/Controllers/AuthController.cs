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
    
    [Authorize(Policy = PolicyNames.HikerRole)]
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
        await _authService.ChangeUserRole(request);
        return Ok(new { Message = "User role updated successfully" });
    }
}