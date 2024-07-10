
using Archive.Application.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace Archive.Application.Extensions;

public static class ServiceCollectionExtention
{
    public static void AddApplication(this IServiceCollection services) 
    {
        var applicationAssembly = typeof(ServiceCollectionExtention).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();


        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}
