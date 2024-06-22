using MudBlazor;
using Autorizador.ULF.Cliente.Model;
using Autorizador.ULF.Services.Shared.DataTransferObjects;



namespace Autorizador.ULF.Cliente.Helper
{
    public interface IUtil
    {
        Task<List<Aplicacao>> GetAplicacoes();
        string NullToString(object Value);
        string OrderBy(string nomeColuna, SortDirection ordem);
        bool IsNumeric(string  val);
       

	}
}
