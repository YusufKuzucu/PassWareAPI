using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Encryption;
using Core.Utilities.IoC;
using Core.DependencyResolvers;
using Core.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.ComponentModel.DataAnnotations;

public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        SetLogging(builder, config);


        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());
        });

        var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        builder.Services.AddTransient<IConfiguration>(_ => { return config; });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
            };
        });

        builder.Services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });


        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1",
                               new OpenApiInfo
                               {
                                   Title = "API Title",
                                   Version = "V1",
                                   Description = "API Description"
                               });

            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "Authorization header using the Bearer scheme. Example \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            swagger.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {   securitySchema,Array.Empty<string>()  }
            });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    [Obsolete]
    private static void SetLogging(WebApplicationBuilder builder, IConfigurationRoot config)
    {
        try
        {
            var columnOption = new ColumnOptions();
            columnOption.Store.Remove(StandardColumn.MessageTemplate);
            columnOption.Store.Remove(StandardColumn.LogEvent);
            columnOption.Store.Remove(StandardColumn.Properties);
            columnOption.AdditionalColumns = new Collection<SqlColumn>()
            {
                new(columnName: "ThreadId", dataType: SqlDbType.Int, allowNull: false),
                new(columnName: "SourceContext", dataType: SqlDbType.NVarChar, allowNull: false),
                new(columnName: "EnvironmentUserName", dataType: SqlDbType.NVarChar, allowNull: false)
            };

             Log.Logger = new LoggerConfiguration()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithThreadId()
            .Enrich.WithProcessId()
            .Enrich.WithMachineName()
            .Enrich.FromLogContext()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System",Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Console()
            .WriteTo.MSSqlServer(
                connectionString: config.GetConnectionString("LogConnectionString"),
                tableName: "Logs",
                autoCreateSqlTable: true,
                schemaName: "dbo",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                columnOptions: columnOption
            )
            .CreateLogger();


            builder.Host.UseSerilog();
            

            Log.Information("API starting..");
        }
        catch (Exception ex)
        {

        }
    }
}

