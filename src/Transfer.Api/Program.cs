using Transfer.Api.Application;
using Transfer.Api.Endpoints;
using Transfer.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection(KafkaOptions.SectionName));
builder.Services.AddSingleton<ITransferEventPublisher, KafkaTransferEventPublisher>();
builder.Services.AddScoped<CreateTransferHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapTransferEndpoints();

app.Run();
