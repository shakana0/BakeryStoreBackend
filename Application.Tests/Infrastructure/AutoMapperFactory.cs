using Application.Infrastructure.AutoMapper;
using AutoMapper;

namespace Application.Tests.Infrastructure
{
    public class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}