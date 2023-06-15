using Fluxo.Caixa.Business.Services;
using Fluxo.Caixa.Infra.Context;
using Fluxo.Caixa.Infra.Context.Repository;
using Fluxo.Caixa.Infra.Mapper;
using Fluxo.Caixa.Infra.Repository;
using Fluxo.Caixa.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ResourceToModelProfile));
builder.Services.AddScoped<ILancamentosService, LancamentosServices>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ApiLancamentoSqlDbContext>();

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
