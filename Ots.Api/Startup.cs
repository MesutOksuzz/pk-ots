using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ots.Api.DbContext;
using Ots.Api.Impl.Cqrs;
using Ots.Api.Impl.Validation;
using FluentValidation.AspNetCore;
using Ots.Api.Mapper;

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
        string connectionStringMsSql = Configuration.GetConnectionString("MsSqlConnection");
        string connectionStringPostgresql = Configuration.GetConnectionString("PostgreSqlConnection");
        
        services.AddDbContext<OtsMsSqlDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<OtsPostgreSqlDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection")));
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).GetTypeInfo().Assembly));
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerUI();
            app.UseSwagger();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}