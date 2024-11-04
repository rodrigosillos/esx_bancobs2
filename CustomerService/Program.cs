using CustomerService.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços para API e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar o MongoClient para injeção de dependência
var connectionString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));

// Registrar o CustomerManagementService para injeção de dependência
builder.Services.AddSingleton<CustomerManagementService>();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
