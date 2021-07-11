using Dapper;
using Domain.Commands.DeleteList;
using Domain.Commands.InsertList;
using Domain.Commands.UpdateList;
using Domain.Interfaces;
using Infra.Base;
using Infra.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace TodoListDDDMediator
{
    public static class ServicesCollectionsExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<RepositoryBase, RepositoryBase>();
            services.AddScoped<IRepositoryList, RepositoryList>();

            return services;
        }

        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(InsertListCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateListCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteListCommand).GetTypeInfo().Assembly);

            return services;
        }

        public static IServiceCollection SwaggerService(this IServiceCollection services)
        {
            services.AddMvcCore().AddApiExplorer();
            services.AddResponseCompression();
            services.AddSwaggerGen(conf =>
            {
                conf.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TodoList",
                    Version = "v1"
                });

                // Comentarios Swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                conf.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection DapperService(this IServiceCollection services)
        {
            services.AddScoped<RepositoryList>();
            services.AddScoped<IRepositoryList, RepositoryList>();
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            return services;
        }
    }
}
