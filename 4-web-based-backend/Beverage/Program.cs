using Beverage.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Custom services
// implements the database context
builder.Services.AddDbContext<BeverageContext>(opt => opt.UseSqlServer
    (builder.Configuration.GetConnectionString("BaverageConnection")));

// Auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Mock Data for Testing
// our interface IBeverageRepo will get mapped to MockBeverageRepo
//builder.Services.AddScoped<IBeverageRepo, MockBeverageRepo>();

// Database Data
builder.Services.AddScoped<IBeverageRepo, SqlBeverageRepo>();
// Json Looping
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


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
