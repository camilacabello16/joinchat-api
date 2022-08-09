using Service;
using Service.Entities;
using Service.Mongo;
using Service.Mongo.Repository;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
        //.AllowCredentials();
    });
});

AppSettings.Init(builder.Services, builder.Configuration);

builder.Services.AddScoped<IMongoBaseContext, MongoContext>();

//add repo
builder.Services.AddScoped<IMongoRepository<Test>, MongoRepository<Test>>();

//add service
builder.Services.AddScoped<TestService>();

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
