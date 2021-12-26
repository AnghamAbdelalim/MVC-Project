using AutoMapper;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Configur
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, RegisterViewodel>().ReverseMap();
                    cfg.CreateMap<OrderDetails, OrderDetailsViewModel>().ReverseMap();
                    cfg.CreateMap<Shipper, ShipperViewModel>().ReverseMap();
                    cfg.CreateMap<Category, categoryViewModelcs>().ReverseMap();
                    cfg.CreateMap<Product, productViewModel>().ReverseMap();
                    //cfg.CreateMap<IdentityResult, ResultStatue>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
