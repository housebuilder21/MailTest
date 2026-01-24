using SendMailBlazor.Components;
using EmailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Grab API Key & send it to the mailer service.
builder.Configuration.AddUserSecrets<Program>();
string apiKey = builder.Configuration["Resend:ApiKey"];
if (apiKey == null)
{
    throw new ArgumentNullException("An API Key must be set!");
}
builder.Services.AddSingleton(new ResendMailer(apiKey));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
