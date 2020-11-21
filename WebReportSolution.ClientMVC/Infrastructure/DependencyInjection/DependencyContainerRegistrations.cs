using Microsoft.Extensions.DependencyInjection;
using WebReportSolution.BusinessLayer;
using WebReportSolution.ClientMVC.Infrastructure.Report;
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
            services.AddTransient<OperationOrders>();
            services.AddTransient<GeneratingReport>();
            services.AddTransient<FillingOutReport>();
        }
    }
}
