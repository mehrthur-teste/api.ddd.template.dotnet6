using api.cross_cutting.template.DependencyInjection;
using api.domain.template.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container test.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services);




IConfiguration configuration = builder.Configuration;
var signingConfigurations = new SigningConfigurations();

builder.Services.AddSingleton(signingConfigurations); // System.InvalidOperationException: 'Cannot modify ServiceCollection after application is built.'
var tokenConfigurations = new TokenConfigurations();

new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations"))
                     .Configure(tokenConfigurations);
builder.Services.AddSingleton(tokenConfigurations);

    builder.Services.AddAuthentication(authOptions =>
    {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(bearerOptions =>
    {
        var paramsValidation = bearerOptions.TokenValidationParameters;
        paramsValidation.IssuerSigningKey = signingConfigurations.Key;
        paramsValidation.ValidAudience = tokenConfigurations.Audience;
        paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

        // Valida a assinatura de um token recebido
        paramsValidation.ValidateIssuerSigningKey = true;

        // Verifica se um token recebido ainda é válido
        paramsValidation.ValidateLifetime = true;

        // Tempo de tolerância para a expiração de um token (utilizado
        // caso haja problemas de sincronismo de horário entre diferentes
        // computadores envolvidos no processo de comunicação)
        paramsValidation.ClockSkew = TimeSpan.Zero;
    });

    // Ativa o uso do token como forma de autorizar o acesso
    // a recursos deste projeto
    builder.Services.AddAuthorization(auth =>
    {
        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            .RequireAuthenticatedUser().Build());
    });


    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Template .Net 6.0 ",
            Description = "Arch DDD",
            TermsOfService = new Uri("https://github.com/mehrthur-teste"),
            Contact = new OpenApiContact
            {
                Name = "Mehrthur",
                Email = "mehrthurfordevtools@mail.com",
                Url = new Uri("https://www.linkedin.com/in/mehrthur-silva-2528161b1/")
            },
            License = new OpenApiLicense
            {
                Name = "Term of license",
                Url = new Uri("https://www.linkedin.com/in/mehrthur-silva-2528161b1/")
            }
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Login with Token JWT",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            }, new List<string>()
                        }
                    });
    });

var app = builder.Build();
// Configure the HTTP request pipeline .
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCore 3.1");
        //c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
