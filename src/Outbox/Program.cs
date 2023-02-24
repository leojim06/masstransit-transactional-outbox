using Components;
using Components.Consumers;
using Components.Interfaces;
using Components.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRegistrationService, RegistrationService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator(cfg =>
{
    cfg.AddConsumer<OrganizationHandler>();
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();


builder.Services.AddDbContext<OrganizationDbContext>(db =>
{
    var conexionString = builder.Configuration.GetConnectionString("SqlServer");
    db.UseSqlServer(conexionString);
    db.EnableSensitiveDataLogging();
});

builder.Services.AddMassTransit(x =>
{
    x.AddEntityFrameworkOutbox<OrganizationDbContext>(o =>
    {
        o.UseSqlServer();
        o.UseBusOutbox();
        o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
    });

    x.SetKebabCaseEndpointNameFormatter();

    x.AddConsumer<MessageSubmittedConsumer>();

    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.ConfigureEndpoints(ctx);
    });

});

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
