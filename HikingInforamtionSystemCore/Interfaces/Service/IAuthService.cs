using HikingInforamtionSystemCore.Requests.Auth;
using HikingInforamtionSystemCore.Responses.Auth;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IAuthService
{
    public Task<SuccessfulLoginResponse> Login(LoginRequest loginRequest);
    public Task<SuccessfulLoginResponse> Register(RegisterRequest registerRequest);
    public Task<SuccessfulLoginResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest);
}