using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Autorizador.ULF.Cliente.HttpInterceptor;

namespace PrestadorEventual.ULF.Cliente.Pages;

public partial class Dashboard
{
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    [Inject]
    public ISnackbar Snackbar { get; set; }
    [Inject]
    public HttpInterceptorService? Interceptor { get; set; }
    //[Inject]
    //public IAutorizacaoPreAprovHttpRepository? AutorizacaoPreAprovHttp { get; set; }
    [Inject]
    NavigationManager NavManager { get; set; }
    bool success;
    public bool Aguardando = false;

    protected Dictionary<string, int> _statusContagem = new Dictionary<string, int>();

    public List<ChartSeries> Series = new List<ChartSeries>();

}
