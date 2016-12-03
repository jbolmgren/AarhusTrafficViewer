using System;
using System.Reflection;

namespace Core.Mapper
{
    public interface IMapperConfigurationExpression
    {
        void DisableConstructorMapping();
        IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();
        //IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>(MemberList memberList);
        //IMappingExpression CreateMap(Type sourceType, Type destinationType);
        //IMappingExpression CreateMap(Type sourceType, Type destinationType, MemberList memberList);
        void ClearPrefixes();
        void RecognizePrefixes(params string[] prefixes);
        void RecognizePostfixes(params string[] postfixes);
        void RecognizeAlias(string original, string alias);
        void ReplaceMemberName(string original, string newValue);
        void RecognizeDestinationPrefixes(params string[] prefixes);
        void RecognizeDestinationPostfixes(params string[] postfixes);
        void AddGlobalIgnore(string propertyNameStartingWith);
        //void ForAllMaps(Action<TypeMap, IMappingExpression> configuration);
        //void ForAllPropertyMaps(Func<PropertyMap, bool> condition, Action<PropertyMap, IMemberConfigurationExpression> memberOptions);
        //IMemberConfiguration AddMemberConfiguration();
        //IConditionalObjectMapper AddConditionalObjectMapper();
        void IncludeSourceExtensionMethods(Type type);
        bool? AllowNullDestinationValues { get; set; }
        bool? AllowNullCollections { get; set; }
        //INamingConvention SourceMemberNamingConvention { get; set; }
        //INamingConvention DestinationMemberNamingConvention { get; set; }
        Func<PropertyInfo, bool> ShouldMapProperty { get; set; }
        Func<FieldInfo, bool> ShouldMapField { get; set; }
        string ProfileName { get; }
        bool? CreateMissingTypeMaps { get; set; }
        //void AddProfile(Profile profile);
        //void AddProfile<TProfile>() where TProfile : Profile, new();
        void AddProfile(Type profileType);
        void ConstructServicesUsing(Func<Type, object> constructor);
        //void CreateProfile(string profileName, Action<Profile> config);
    }
}