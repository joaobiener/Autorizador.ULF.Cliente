using Microsoft.AspNetCore.Components;

namespace Autorizador.ULF.Cliente.Pages.Exception
{
    public partial class ManutencaoError
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void NavigateToHome()
        {
            NavigationManager.NavigateTo("logout");
        }
    }
}
