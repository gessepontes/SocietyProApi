using Microsoft.Extensions.DependencyInjection;
using SocietyProApi.Data.Repository.EntityFramework;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Ioc
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
            services.AddScoped<IInscriptionRepository, InscriptionRepository>();
        }
    }
}
