using System;
using System.Reflection;
using Core.Mapper;

namespace AutoMapperImpl
{
    public class MapperConfigurationExpressionWrapper : IMapperConfigurationExpression
    {
        private readonly AutoMapper.IMapperConfigurationExpression _mapperConfigurationExpression;

        internal MapperConfigurationExpressionWrapper(AutoMapper.IMapperConfigurationExpression mapperConfigurationExpression)
        {
            _mapperConfigurationExpression = mapperConfigurationExpression;
        }
        public void DisableConstructorMapping()
        {
            _mapperConfigurationExpression.DisableConstructorMapping();
        }

        public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            return
                new MappingExpressionWrapper<TSource, TDestination>(
                    _mapperConfigurationExpression.CreateMap<TSource, TDestination>());
        }

        public void ClearPrefixes()
        {
            _mapperConfigurationExpression.ClearPrefixes();
        }

        public void RecognizePrefixes(params string[] prefixes)
        {
            _mapperConfigurationExpression.RecognizePrefixes(prefixes);
        }

        public void RecognizePostfixes(params string[] postfixes)
        {
            _mapperConfigurationExpression.RecognizePostfixes(postfixes);
        }

        public void RecognizeAlias(string original, string alias)
        {
            _mapperConfigurationExpression.RecognizeAlias(original, alias);
        }

        public void ReplaceMemberName(string original, string newValue)
        {
            _mapperConfigurationExpression.ReplaceMemberName(original, newValue);
        }

        public void RecognizeDestinationPrefixes(params string[] prefixes)
        {
            _mapperConfigurationExpression.RecognizeDestinationPrefixes(prefixes);
        }

        public void RecognizeDestinationPostfixes(params string[] postfixes)
        {
            _mapperConfigurationExpression.RecognizeDestinationPostfixes(postfixes);
        }

        public void AddGlobalIgnore(string propertyNameStartingWith)
        {
            _mapperConfigurationExpression.AddGlobalIgnore(propertyNameStartingWith);
        }

        public void IncludeSourceExtensionMethods(Type type)
        {
            _mapperConfigurationExpression.IncludeSourceExtensionMethods(type);
        }

        public bool? AllowNullDestinationValues
        {
            get { return _mapperConfigurationExpression.AllowNullDestinationValues; }
            set { _mapperConfigurationExpression.AllowNullDestinationValues = value; }
        }

        public bool? AllowNullCollections
        {
            get { return _mapperConfigurationExpression.AllowNullCollections; }
            set { _mapperConfigurationExpression.AllowNullCollections = value; }
        }

        Func<PropertyInfo, bool> IMapperConfigurationExpression.ShouldMapProperty
        {
            get { return ShouldMapProperty; }
            set { ShouldMapProperty = value; }
        }

        Func<FieldInfo, bool> IMapperConfigurationExpression.ShouldMapField
        {
            get { return ShouldMapField; }
            set { ShouldMapField = value; }
        }

        public Func<PropertyInfo, bool> ShouldMapProperty
        {
            get { return _mapperConfigurationExpression.ShouldMapProperty; }
            set { _mapperConfigurationExpression.ShouldMapProperty = value; }
        }

        public Func<FieldInfo, bool> ShouldMapField
        {
            get { return _mapperConfigurationExpression.ShouldMapField; }
            set { _mapperConfigurationExpression.ShouldMapField = value; }
        }

        public string ProfileName
        {
            get { return _mapperConfigurationExpression.ProfileName; }
        }

        public void AddProfile(Type profileType)
        {
            _mapperConfigurationExpression.AddProfile(profileType);
        }


        public void ConstructServicesUsing(Func<Type, object> constructor)
        {
            _mapperConfigurationExpression.ConstructServicesUsing(constructor);
        }

        public bool? CreateMissingTypeMaps
        {
            get { return _mapperConfigurationExpression.CreateMissingTypeMaps; }
            set { _mapperConfigurationExpression.CreateMissingTypeMaps = value; }
        }
    }
}