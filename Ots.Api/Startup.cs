using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ots.Api.DbContext;
using Ots.Api.Impl.Cqrs;
using Ots.Api.Impl.Validation;
using FluentValidation.AspNetCore;
using Ots.Api.Mapper;
using Ots.Api.Middleware;
using Ots.Base;
using Ots.Base.Services;


namespace Ots.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)=> Configuration = configuration;
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddFluentValidation(x =>
        {
            x.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
        });
        
        var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperConfig()));
        services.AddSingleton(mapperConfig.CreateMapper());
        
        services.AddSwaggerGen();
        
        
        
        services.AddDbContext<OtsDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

        
        
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).GetTypeInfo().Assembly));

        services.AddScoped<ScopedService>();
        services.AddTransient<TransientService>();
        services.AddSingleton<SingletonService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerUI();
            app.UseSwagger();
        }
        
        app.UseMiddleware<HeartBeatMiddleware>();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        app.Use((context, next) =>
        {
            if (!string.IsNullOrEmpty(context.Request.Path) && context.Request.Path.Value.Contains("favicon"))
            {
                return next();
            }
            var singletonService = context.RequestServices.GetRequiredService<SingletonService>();
            var scopedService = context.RequestServices.GetRequiredService<ScopedService>();
            var transientService = context.RequestServices.GetRequiredService<TransientService>();

            singletonService.Counter++;
            scopedService.Counter++;
            transientService.Counter++;

            return next();
        });
        app.Run(async context =>
        {
            var singletonService = context.RequestServices.GetRequiredService<SingletonService>();
            var scopedService = context.RequestServices.GetRequiredService<ScopedService>();
            var transientService = context.RequestServices.GetRequiredService<TransientService>();

            if (!string.IsNullOrEmpty(context.Request.Path) && !context.Request.Path.Value.Contains("favicon"))
            {
                singletonService.Counter++;
                scopedService.Counter++;
                transientService.Counter++;
            }

            await context.Response.WriteAsync($"SingletonService: {singletonService.Counter}\n");
            await context.Response.WriteAsync($"TransientService: {transientService.Counter}\n");
            await context.Response.WriteAsync($"ScopedService: {scopedService.Counter}\n");
        });
    }
}