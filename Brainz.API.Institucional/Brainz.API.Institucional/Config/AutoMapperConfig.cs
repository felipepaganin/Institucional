using AutoMapper;
using Brainz.Domain.ViewModels;
using Brainz.Service.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Brainz.API.Institucional.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
