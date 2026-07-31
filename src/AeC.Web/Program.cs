using AeC.Application.Interfaces; using AeC.Application.Services; using AeC.Domain.Interfaces; using AeC.Infrastructure.Context; using AeC.Infrastructure.Repositories; using AeC.Infrastructure.Services; using AeC.Web.Filters; using Microsoft.AspNetCore.Authentication.Cookies; using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(o=>o.Filters.Add<GlobalExceptionFilter>());
builder.Services.AddDbContext<ApplicationDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthService,AuthService>(); builder.Services.AddScoped<IEnderecoService,EnderecoService>(); builder.Services.AddScoped<ICsvExportService,CsvExportService>(); builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>(); builder.Services.AddScoped<IEnderecoRepository,EnderecoRepository>(); builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddHttpClient<IViaCepService,ViaCepService>(c=>c.BaseAddress=new Uri(builder.Configuration["ViaCep:BaseUrl"]!));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o=>{ o.LoginPath="/Account/Login"; o.LogoutPath="/Account/Logout"; o.AccessDeniedPath="/Account/Login"; o.Cookie.Name=builder.Configuration["Authentication:CookieName"]??"AeC.Auth"; o.Cookie.HttpOnly=true; o.Cookie.SameSite=SameSiteMode.Lax; o.SlidingExpiration=true; o.ExpireTimeSpan=TimeSpan.FromMinutes(builder.Configuration.GetValue("Authentication:ExpireMinutes",60)); });
builder.Services.AddAuthorization();
var app=builder.Build();
if(!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles(); app.UseRouting(); app.UseAuthentication(); app.UseAuthorization();
using(var scope=app.Services.CreateScope()){ var db=scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); if(db.Database.IsRelational()) await db.Database.MigrateAsync(); await DatabaseSeeder.SeedAsync(db); }
app.MapControllerRoute("default","{controller=Enderecos}/{action=Index}/{id?}"); app.Run();
