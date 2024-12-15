using HikingInforamtionSystemCore.Requests.Auth;
using HikingInforamtionSystemCore.Responses.Auth;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IAuthService
{
    public Task<SuccessfulLoginResponse> Login(LoginRequest loginRequest);
    public Task<SuccessfulLoginResponse> Register(RegisterRequest registerRequest);
    public Task<SuccessfulLoginResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest);
    public Task ChangeUserRole(ChangeUserRole changeUserRole, string currentUserId);
    public Task<IEnumerable<UserResponse>> GetUsers();
    public Task<UserResponse> GetUserById(string id);
}