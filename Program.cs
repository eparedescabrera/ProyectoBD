using Microsoft.EntityFrameworkCore;
using WebApplication1.Models; // 👈 ajusta si tu namespace del proyecto es distinto

var builder = WebApplication.CreateBuilder(args);

// ================================
// 🔹 CONFIGURACIÓN DE SERVICIOS
// ================================

// ✅ Agregar el contexto de base de datos y la conexión
builder.Services.AddDbContext<LiberiaDriveContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LiberiaDriveDB")));

// ✅ Habilitar controladores y vistas MVC
builder.Services.AddControllersWithViews();

// ================================
// 🔹 CONSTRUCCIÓN DEL APLICATIVO
// ================================
var app = builder.Build();

// ================================
// 🔹 CONFIGURACIÓN DEL PIPELINE HTTP
// ================================

// Manejo de errores y seguridad
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirección a HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ================================
// 🔹 CONFIGURACIÓN DE RUTAS MVC
// ================================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Iniciar la aplicación
app.Run();
