using AutoMapper;
using StockMarketTracker.Model;

namespace StockMarketTracker.API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Stock, StockTO>().ReverseMap();
        }
    }
}
