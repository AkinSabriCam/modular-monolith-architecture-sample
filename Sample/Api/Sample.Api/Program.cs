using Autofac.Extensions.DependencyInjection;
using Sample.Modules.Folio.Infrastructure.Configuration;
using Sample.Modules.Folio.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample.Modules.Folio.Application.Contract.Internal;
using Sample.Modules.Profile.Application.Contract.Internal;
using Sample.Modules.Profile.Infrastructure.Configuration;
using Sample.Modules.Profile.Infrastructure.EntityFrameworkCore;
using Sample.Modules.Reservation.Application.Contract.Internal;
using Sample.Modules.Reservation.Infrastructure.Configuration;
using Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutofac();

var connString = builder.Configuration.GetConnectionString("Default");
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

ProfileStartup.Initialize(connString);
ReservationStartup.Initialize(connString);
FolioStartup.Initialize(connString);

builder.Services.AddDbContext<ReservationDbContext>(x => x.UseNpgsql(connString));
builder.Services.AddDbContext<ProfileDbContext>(x => x.UseNpgsql(connString));
builder.Services.AddDbContext<FolioDbContext>(x => x.UseNpgsql(connString));

builder.Services.AddScoped<IReservationExecutor, ReservationExecutor>();
builder.Services.AddScoped<IProfileExecutor, ProfileExecutor>();
builder.Services.AddScoped<IFolioExecutor, FolioExecutor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();