using Autorizador.ULF.Cliente.Features;
using Entities.Models;
using Autorizador.ULF.Services.Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Autorizador.ULF.Services.Shared.RequestFeatures;
using Entities.Models.Infomed;


namespace Autorizador.ULF.Cliente.HttpRepository
{
	public interface IProcedimentoHttpRepository
	{
		Task<PagingResponse<Procedimento>> GetAllProcedimentosAsync(
           PrestadorParameters parameters);
		//Task<IEnumerable<InfServicoDto>> GetAllServicosBySearchTerm(string searchTerm);
	}
}
