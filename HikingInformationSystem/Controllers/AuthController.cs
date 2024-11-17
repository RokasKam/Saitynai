using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Auth;
using HikingInformationSystemDomain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest registerRequest)
    {
        return Ok(await _authService.Register(registerRequest));
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest loginRequest)
    {
        return Ok(await _authService.Login(loginRequest));
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenRequest refreshRequest)
    {
        return Ok(await _authService.RefreshToken(refreshRequest));
    }
}