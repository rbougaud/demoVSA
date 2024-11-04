using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudioVSA.Common.Behaviors;
using StudioVSA.Data.Context;
using StudioVSA.Data.Repositories;
using StudioVSA.Domain.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressInferBindingSourcesForParameters = true;
                });
builder.Services.AddHttpClient().AddDistributedMemoryCache();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddDbContext<WriterContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionString"]!));
builder.Services.AddDbContext<ReaderContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionString"]!));
builder.Services.AddScoped<IMovieRepositoryReader, MovieRepositoryReader>();
builder.Services.AddScoped<IMovieRepositoryWriter, MovieRepositoryWriter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
