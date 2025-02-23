using Application.IoC;
using Application.Services.AbstractServices;
using Application.Services.ConcreteServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Infrastructure.Repositorys.AbstractRepositories;
using Infrastructure.Repositorys.ConcreteRepositories;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(); 


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICertificationService, CertificationService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IMarketingChannelService, MarketingChannelService>();
builder.Services.AddScoped<IMarketplaceService, MarketplaceService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ITagService, TagService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// CORS policy settings
string MyAllowOrigins = "_myAllowOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowOrigins, builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
