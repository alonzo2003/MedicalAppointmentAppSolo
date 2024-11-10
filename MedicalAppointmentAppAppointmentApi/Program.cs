using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using MedicalappointmentApp.Persistance.Repositories.Appointment;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MedicalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDb")));

//Registro de dependencias repositorios de appo
builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
builder.Services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
