using Autorizador.ULF.Cliente.AuthProviders;
using Autorizador.ULF.Cliente.Configuration;
using Autorizador.ULF.Cliente.Helper;
using Autorizador.ULF.Cliente.HttpInterceptor;
using Autorizador.ULF.Cliente.HttpRepository;
using Autorizador.ULF.Cliente;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using MudBlazor.Services;
using Blazored.LocalStorage;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));


builder.Services.AddHttpClient("SNIPPERAPI", (sp, cl) =>
{
	var apiConfiguration = sp.GetRequiredService<IOptions<ApiConfiguration>>();
	cl.BaseAddress = new Uri(apiConfiguration.Value.BaseAddress);
	// cl.Timeout =  new TimeSpan(0, 0, 10);
	cl.Timeout = new TimeSpan(0, apiConfiguration.Value.Timeout, 0);
	cl.EnableIntercept(sp);
});

builder.Services.AddHttpClient<AuthAPIClient>("AUTHAPI", (sp, cl) =>
{
	var apiConfigurationLogin = sp.GetRequiredService<IOptions<ApiConfigurationLogin>>();
	cl.BaseAddress = new Uri(apiConfigurationLogin.Value.BaseAddress);
	cl.Timeout = new TimeSpan(0, apiConfigurationLogin.Value.Timeout, 0);
	cl.EnableIntercept(sp);
});


//builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMudServices(config => {
	config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

	config.SnackbarConfiguration.PreventDuplicates = false;
	config.SnackbarConfiguration.NewestOnTop = false;
	config.SnackbarConfiguration.ShowCloseIcon = true;
	config.SnackbarConfiguration.VisibleStateDuration = 10000;
	config.SnackbarConfiguration.HideTransitionDuration = 500;
	config.SnackbarConfiguration.ShowTransitionDuration = 500;
	config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddHttpClientInterceptor();

builder.Services.AddScoped(sp =>
{
	var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();

	// Register interceptor for PRESTAPI
	var prestapiClient = httpClientFactory.CreateClient("SNIPPERAPI");
	prestapiClient.EnableIntercept(sp);

	// Register interceptor for AUTHAPI
	//var authapiClient = httpClientFactory.CreateClient("AUTHAPI");
	//authapiClient.EnableIntercept(sp);

	// You can customize the interception logic based on your requirements

	return prestapiClient; // Return one of the clients if needed
});




builder.Services.AddScoped<IUtil, Util>();

builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.Configure<ApiConfiguration>
		(builder.Configuration.GetSection("ApiConfiguration"));
builder.Services.Configure<ApiConfigurationLogin>
		(builder.Configuration.GetSection("ApiConfigurationLogin"));

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<RefreshTokenService, RefreshTokenService>();



await builder.Build().RunAsync();
