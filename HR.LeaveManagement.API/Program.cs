using HR.LeaveManagement.Application;
using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);


builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                .AllowAnyHeader()
                                                .AllowAnyMethod());
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();


