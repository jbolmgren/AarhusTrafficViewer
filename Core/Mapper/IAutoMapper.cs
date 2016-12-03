using System;

namespace Core.Mapper
{
    public interface IAutoMapper
    {
        T2 Map<T1, T2>(T1 mapFrom);
        void AddProfile(IMappingProfile mappingProfile);
    }
}