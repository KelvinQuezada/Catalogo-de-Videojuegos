using CatalogoVideojuegos.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

// Los precios se muestran y se capturan con punto decimal (formato estable),
// de modo que el valor de los formularios HTML type="number" coincida con el
// que devuelve la vista al editar un registro.
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-EC");

var builder = WebApplication.CreateBuilder(args);

// Servicios MVC (controladores + vistas Razor).
builder.Services.AddControllersWithViews();

// Registro del ApplicationDbContext con el proveedor de PostgreSQL (Npgsql).
// La cadena de conexión se obtiene de appsettings.json.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CatalogoVideojuegosDb")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
