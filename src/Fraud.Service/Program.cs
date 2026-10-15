using Fraud.Service.Application;
using Fraud.Service.Application.Options;
using Fraud.Service.Domain;
using Fraud.Service.Infrastructure;
using Fraud.Service.Infrastructure.Options;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.Configure<FraudOptions>(builder.Configuration.GetSection(FraudOptions.SectionName));
builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection(KafkaOptions.SectionName));

builder.Services.AddSingleton(sp => new FraudPolicy(sp.GetRequiredService<IOptions<FraudOptions>>().Value.MaxAmount));
builder.Services.AddSingleton<IFraudEventPublisher, KafkaFraudEventPublisher>();
builder.Services.AddScoped<EvaluateTransferHandler>();
builder.Services.AddHostedService<TransferRequestedConsumer>();

var host = builder.Build();
host.Run();
