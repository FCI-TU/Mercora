using FindIt.Client.Services.CartService;
using Blazored.LocalStorage;
using Blazored.Toast;
using FindIt.Client;
using FindIt.Client.Services.Authentication;
using FindIt.Client.Services.ProductService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(typeof(IAuthenticationService), typeof(AuthenticationService));
builder.Services.AddScoped(typeof(ICartService), typeof(CartService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));

builder.Services.AddHttpClient("Auth", options =>
{
	options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
