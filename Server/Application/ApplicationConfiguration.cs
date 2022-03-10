using Application.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
            => services
                .AddAutoMapperProfile()
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        public static IServiceCollection AddAutoMapperProfile(
           this IServiceCollection services)
           => services
               .AddAutoMapper(x => x.AddProfile(new MappingProfile()));
    }
}
