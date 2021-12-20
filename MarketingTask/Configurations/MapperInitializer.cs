using AutoMapper;
using MarketingTask.Data;
using MarketingTask.Models;

namespace MarketingTask.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Distributor, DistributorDto>().ReverseMap();
            CreateMap<Distributor, CreateDistributorDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<DistributorSales, DistributorSalesDto>().ReverseMap();
            CreateMap<DistributorSales, CreateDistributorSalesDto>().ReverseMap();
        }
    }
}
