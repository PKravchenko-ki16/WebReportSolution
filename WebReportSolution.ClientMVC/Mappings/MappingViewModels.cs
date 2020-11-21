using WebReportSolution.ClientMVC.Mappings.Base;
using WebReportSolution.Entities.Orders;
using WebReportSolution.ViewModels.Orders;

namespace WebReportSolution.ClientMVC.Mappings
{
    public class MappingViewModels : MapperConfigurationBase
    {
        public MappingViewModels()
        {
            CreateMap<Order, OrderViewModel>()
            .ForMember("Date", opt => opt.MapFrom(c => c.Date.ToShortDateString()));

            CreateMap<Order, ModificationOrderViewModel>();

            CreateMap<ModificationOrderViewModel, Order>();
        }
    }
}