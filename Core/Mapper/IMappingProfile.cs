namespace Core.Mapper
{
    public interface IMappingProfile
    {
        void Configure(IMapperConfigurationExpression conf);
    }
}