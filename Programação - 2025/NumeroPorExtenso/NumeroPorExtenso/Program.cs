using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controladores MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o ambiente de desenvolvimento
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura as rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Numero}/{action=Index}/{id?}");

app.Run();