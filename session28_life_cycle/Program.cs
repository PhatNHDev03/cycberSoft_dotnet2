using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using session28_life_cycle;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ket noi link api 
// co the ket noi voi nhieu bên thứ 3

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://apistore.cybersoft.edu.vn/api/") });
builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();
