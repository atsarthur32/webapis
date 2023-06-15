using Fluxo.Caixa.Infra.Context.Repository;
using Fluxo.Caixa.Infra.Context;
using Fluxo.Caixa.Infra.Mapper;
using Fluxo.Caixa.Infra.Repository;
using Fluxo.Caixa.Infra.Services;
using Fluxo.Caixa.Business.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ResourceToModelProfile));
builder.Services.AddScoped<IRelatorioDiarioService, RelatorioDiarioService>();
builder.Services.AddScoped<IRelatorioDiarioRepository, RelatorioDiarioRepository>();
builder.Services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ApiLancamentoSqlDbContext>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
