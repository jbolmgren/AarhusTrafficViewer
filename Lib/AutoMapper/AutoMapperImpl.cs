using AutoMapper;
using AutoMapper.Configuration;
using Core.Mapper;

namespace AutoMapperImpl
{
    public class AutoMapperImpl : IAutoMapper
    {
        private readonly MapperConfigurationExpression _expression = new MapperConfigurationExpression();

        public T2 Map<T1, T2>(T1 mapFrom)
        {
            var config = new MapperConfiguration(_expression);

            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);
            var map = mapper.DefaultContext.Mapper.Map<T2>(mapFrom);
            return map;
        }

        public void AddProfile(IMappingProfile mappingProfile)
        {
            mappingProfile.Configure(new MapperConfigurationExpressionWrapper(_expression));
        }
    }
}