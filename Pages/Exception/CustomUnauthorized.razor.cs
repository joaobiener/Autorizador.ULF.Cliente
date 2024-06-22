using Microsoft.AspNetCore.Components;
using MudBlazor;
using Autorizador.ULF.Cliente.Extensions;

namespace Autorizador.ULF.Cliente.Pages.Exception
{
    public partial class CustomUnauthorized
    {
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        string _url;

		protected async override Task OnInitializedAsync()
        {
            _url = NavManager.ExtractQueryStringByKey<string>("url");
            Snackbar.Add("Acesso não autorizado!", Severity.Warning);

            NavManager.NavigateTo("/logout");
        }
    }
}
