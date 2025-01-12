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

var builder = WebApplication.CreateBuilder(args);

//var key = Encoding.UTF8.GetBytes("your_secret_key_here"); 

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.RequireHttpsMetadata = false;  // HTTPS kullanmýyorsanýz
//        options.SaveToken = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false,  // Ýstediðiniz doðrulama yöntemlerine göre bu ayarý deðiþtirebilirsiniz
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            IssuerSigningKey = new SymmetricSecurityKey(key),
//            ClockSkew = TimeSpan.Zero  // Token'ýn son geçerlilik süresi esnemesin
//        };
//    });

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

// SMTP client configuration
var smtpClient = new SmtpClient("smtp.gmail.com")
{
    Port = 587,
    Credentials = new NetworkCredential(""),
    EnableSsl = true,
};

builder.Services.AddSingleton(smtpClient);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IMailService, MailService>();

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
