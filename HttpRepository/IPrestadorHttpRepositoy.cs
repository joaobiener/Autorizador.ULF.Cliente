using Autorizador.ULF.Cliente.Features;
using Autorizador.ULF.Services.Shared.DataTransferObjects;
using Autorizador.ULF.Services.Shared.RequestFeatures;


namespace Autorizador.ULF.Cliente.HttpRepository
{
    public interface IPrestadorHttpRepositoy
	{
		 Task<PagingResponse<PrestadorDto>> GetPrestadores(PrestadorParameters parameters);

	}
}
