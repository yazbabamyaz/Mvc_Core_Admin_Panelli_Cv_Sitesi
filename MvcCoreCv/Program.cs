using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MvcCoreCv.DTOs;
using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;
using MvcCoreCv.Repositories.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//Ya da : aþaðýdaki kod.
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));


builder.Services.AddControllersWithViews().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<EducationDto>());

builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IAwardRepository,AwardRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IHobbyRepository, HobbyRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISocialRepository, SocialRepository>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IRepository<TblAdmin>,GenericRepository<TblAdmin>>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IRepository<TblAbout>, GenericRepository<TblAbout>>();
builder.Services.AddSession();


//proje seviyesinde Authorize iþlemi için kullandýðým bölüm
builder.Services.AddMvcCore(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	   .RequireAuthenticatedUser()
	   .Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

//Sisteme otantike olunmadýðýnda gönderilecek sayfa.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.Cookie.Name = "CoreMvc.Auth";
	options.LoginPath = "/Login/Index";
	options.AccessDeniedPath = "/Login/Index";
});

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


app.UseSession();



app.UseRouting();

app.UseAuthentication();//kullanýcýyý kontrol eder
app.UseAuthorization();//yetkilerini kontrol eder

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
