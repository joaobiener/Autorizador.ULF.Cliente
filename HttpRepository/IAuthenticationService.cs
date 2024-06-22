using Autorizador.ULF.Services.Shared.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Autorizador.ULF.Cliente.HttpRepository;

    public interface IAuthenticationService
{
	Task<ResponseDto> RegisterUser(UserForRegistrationDto userForRegistrationDto);
	Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
	Task Logout();
	Task<string> RefreshToken();
}
