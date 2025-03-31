using Microsoft.AspNetCore.ResponseCompression;
using session31_signalR.Client.Pages;
using session31_signalR.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSignalR();
// cau hinh nen du lieu tu client
//octet-stream nen data tangn hieu suat
builder.Services.AddResponseCompression(otp =>
{
    otp.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat([
        "application/octet-stream"
    ]);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(session31_signalR.Client._Imports).Assembly);
//router signalR
app.MapHub<ChatHub>("/chathub");

app.Run();
