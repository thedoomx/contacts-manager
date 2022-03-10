namespace Infrastructure
{
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
    using System;
    using Microsoft.EntityFrameworkCore;
	using Infrastructure.Persistence;
	using Domain;
	using Application;

	public static class InfrastructureConfiguration
	{
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
           => services
               .AddDatabase(configuration)
               .AddRepositories();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddScoped<DbContext, ContactsManagerDbContext>()
                .AddEntityFrameworkNpgsql().AddDbContext<ContactsManagerDbContext>(options => options
                    .UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IContactsManagerDbContext>(provider => provider.GetService<ContactsManagerDbContext>());

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>))
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

    }
}
