using Hobbit.src.Infrastructure;
using Hobbit.src.Interfaces;
using Hobbit.src.Repositories;
using Hobbit.src.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hobbit;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // *** CONFIGURAÇÃO DO DATABASE CONTEXT ***
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // *** CONFIGURAÇÃO DE CORS ***
        builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }));

        // *** CONFIGURAÇÃO DO SWAGGER ***
        builder.Services.AddSwaggerGen();

         // *** ADICIONANDO CONTROLLERS COM SUPORTE A NEWTONSOFT.JSON ***
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

        builder.Services.AddEndpointsApiExplorer();


        // *** REGISTRO DE DEPENDÊNCIAS ***

        // *** CONTEXTO DE SERVICES ***
        builder.Services.AddScoped<AmbientesService>();

        builder.Services.AddHttpContextAccessor();

        // *** CONTEXTO DE REPOSITORIES ***
        builder.Services.AddScoped<IAmbientesRepository, AmbientesRepository>();



        // *** CONFIGURAÇÃO DO APP ***
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Executa Financeiro API V2");
                c.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors();
        app.UseRouting();

        // *** MIDDLEWARES ***
        // app.UseMiddleware<GlobalExceptionMiddleware>();
        
        // *** AUTENTICAÇÃO E AUTORIZAÇÃO ***
        app.UseAuthentication();
        app.UseAuthorization();

        // *** MAPEAMENTO DE CONTROLLERS ***
        app.MapControllers();

        // *** EXECUÇÃO DA APLICAÇÃO ***
        app.Run();
    }
}