using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.BusinessLayer.Concrete;
using HotelManagement.DataAccessLayer.Abstract;
using HotelManagement.DataAccessLayer.Concrete;
using HotelManagement.DataAccessLayer.EntityFramework;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServicesService, ServiceManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<ISendMessageDal, EfSendMessageDal>();
builder.Services.AddScoped<ISendMessageService, SendMessageManager>();
builder.Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();
builder.Services.AddScoped<IEmailService, SmtpEmailManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issure"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("HotelApiCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
