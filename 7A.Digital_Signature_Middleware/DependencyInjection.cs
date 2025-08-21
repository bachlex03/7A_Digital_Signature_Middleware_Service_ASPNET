using _7A.Digital_Signature_Middleware.Abstractions;
using _7A.Digital_Signature_Middleware.Services;
using _7A.Digital_Signature_Middleware.Settings;

namespace _7A.Digital_Signature_Middleware;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SslThirdPartySettings>(configuration.GetSection(SslThirdPartySettings.SettingKey));

        services.AddSingleton<IAuthService, AuthService>();

        return services;
    }
}
