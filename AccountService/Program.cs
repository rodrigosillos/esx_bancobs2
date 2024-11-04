using AccountService.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços para API e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar o MongoClient para injeção de dependência
var connectionString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));

// Registrar o AccountManagementService para injeção de dependência
builder.Services.AddSingleton<AccountManagementService>();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear controladores (necessário para rotas como /api/account)
app.MapControllers();

app.Run();
