using Ledger.Service.Application;
using Ledger.Service.Infrastructure;
using Ledger.Service.Infrastructure.Options;
using Ledger.Service.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection(KafkaOptions.SectionName));

builder.Services.AddDbContext<LedgerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Ledger")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IProcessedEventRepository, ProcessedEventRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ProcessApprovedTransferHandler>();
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddSingleton<ILedgerEventPublisher, KafkaLedgerEventPublisher>();
builder.Services.AddHostedService<TransferApprovedConsumer>();

var host = builder.Build();

if (isDevelopment)
{
    using var scope = host.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<DbSeeder>().SeedAsync();
}

host.Run();
