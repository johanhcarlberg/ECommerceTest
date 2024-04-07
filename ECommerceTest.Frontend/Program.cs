using ECommerceTest.Frontend.Components;
using ECommerceTest.Frontend.Services;
using ECommerceTest.Shared;
using ECommerceTest.Shared.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("ecommerceTestApi",
    client =>
        client.BaseAddress = new Uri($"https://{builder.Configuration["API:Api.Host"]}:{builder.Configuration["API:Api.Port"]}")
    );
builder.Services.AddSingleton<IProductService<ProductDto>, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
