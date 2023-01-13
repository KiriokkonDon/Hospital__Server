using DB;
using DB.Repositories;
using Hospital.Repositories;
using Hospital.Servise;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql($"Host=localhost;Port=5432;Database=db;Username=postgres;Password=0023"));
builder.Services.AddDbContext<ApplicationContext>(options =>
options.EnableSensitiveDataLogging(true));

builder.Services.AddTransient<IUserRep, UserRepository>();
builder.Services.AddTransient<IScheduleRep, SheduleRepository>();
builder.Services.AddTransient<IVisitRep, VisitRepository>();
builder.Services.AddTransient<IDoctorRep, DoctorRepository>();
builder.Services.AddTransient<ISpecializationRep, SpecializationRepository>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<DoctorService>();
builder.Services.AddTransient<VisitService>();
builder.Services.AddTransient<SheduleService>();
builder.Services.AddTransient<SpecializationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
