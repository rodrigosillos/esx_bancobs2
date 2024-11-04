using TransactionService.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));

builder.Services.AddHttpClient<AccountClient>(client =>
{
    client.BaseAddress = new Uri("http://accountservice:80"); 
});

builder.Services.AddSingleton<TransactionManagementService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
