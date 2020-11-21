using Microsoft.Extensions.DependencyInjection;
using WebReportSolution.DAL;
using WebReportSolution.DAL.Repository;

namespace WebReportSolution.ClientMVC.Infrastructure.DependencyInjection
{
    public class DependencyContainerRegistrations
    {
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<ApplicationContext>();
            services.AddTransient<OrdersRepository>();
        }
    }
}
