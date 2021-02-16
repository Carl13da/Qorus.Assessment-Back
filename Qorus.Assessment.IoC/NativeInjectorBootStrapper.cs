using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Qorus.Assessment.Application.CommandHandlers;
using Qorus.Assessment.Application.QueryHandlers;
using Qorus.Assessment.Application.Services;
using Qorus.Assessment.Data.Repositories;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Dto;
using Qorus.Assessment.Domain.Events.Bus;
using Qorus.Assessment.Domain.Events.Notifications;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Interfaces.Repositories;
using Qorus.Assessment.Domain.Interfaces.Services;
using Qorus.Assessment.Domain.Queries;
using System.Collections.Generic;

namespace Qorus.Assessment.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //ASP.NET HttpContenxt dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // DOmain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain Service
            services.AddScoped<IFileService, FileService>();

            // Repos
            services.AddScoped<IFileRepository, FileRepository>();

            // Domain Queries or Commands
            services.AddScoped<IRequestHandler<GetFilesQuery, List<FileDto>>, GetFilesQueryHandler>();

            services.AddScoped<IRequestHandler<UploadFileCommand, Unit>, UploadFileCommandHandler>();
        }
    }
}
