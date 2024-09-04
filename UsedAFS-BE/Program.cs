using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using UsedAFS_BE.Interfaces;
using UsedAFS_BE.Middleware;
using UsedAFS_BE.Services;

var builder = WebApplication.CreateBuilder(args);

// Setup database connection
builder.Services.Configure<MyDatabaseSettings>(builder.Configuration.GetSection("UsedAFSDatabase"));
builder.Services.AddSingleton<MyDatabaseSettings>(sp  => sp.GetRequiredService<IOptions<MyDatabaseSettings>>().Value);

// Add services to the container.
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddControllers().AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase);

// Define MongoDB camelCase to C Sharp PascalCase conversion
var conventionPack = new ConventionPack
{
    new CamelCaseElementNameConvention()
};

ConventionRegistry.Register(
    name: "CustomConventionPack",
    conventions: conventionPack,
    filter: t => true
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
