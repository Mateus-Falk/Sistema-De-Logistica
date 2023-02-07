using Microsoft.EntityFrameworkCore;
using SistemaLogistica.Application.Service.Services;
using SistemaLogistica.Domain.IRepositories;
using SistemaLogistica.Domain.IServices;
using SistemaLogistica.Infra.Data.Context;
using SistemaLogistica.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context SQL Server

builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer("Server=DESKTOP-UME51NM\\SQLMATEUS;Database=SistemaLogistica;User Id=sa;Password=zuky;TrustServerCertificate=True;Encrypt=False;"));

// ### Dependency Injection
// # Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IInOutRepository, InOutRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();

// # Services
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IInOutService, InOutService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
