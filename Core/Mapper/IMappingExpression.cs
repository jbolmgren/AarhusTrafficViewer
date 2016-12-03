using System;
using System.Linq.Expressions;

namespace Core.Mapper
{
    public interface IMappingExpression<TSource, TDestination>
    {
        IMappingExpression<TSource, TDestination> PreserveReferences();

        void ForAllOtherMembers(
            Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);

        IMappingExpression<TSource, TDestination> ForMember<TMember>(
            Expression<Func<TDestination, TMember>> destinationMember,
            Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions);

        IMappingExpression<TSource, TDestination> ForMember(string name,
                                                            Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);

        void ForAllMembers(Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);
        IMappingExpression<TSource, TDestination> IgnoreAllPropertiesWithAnInaccessibleSetter();
        IMappingExpression<TSource, TDestination> IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

        IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>()
            where TOtherSource : TSource
            where TOtherDestination : TDestination;

        IMappingExpression<TSource, TDestination> IncludeBase<TSourceBase, TDestinationBase>();
        IMappingExpression<TSource, TDestination> Include(Type derivedSourceType, Type derivedDestinationType);
        void ProjectUsing(Expression<Func<TSource, TDestination>> projectionExpression);
        void ConvertUsing(Func<TSource, TDestination> mappingFunction);
        void ConvertUsing(Func<TSource, TDestination, TDestination> mappingFunction);
        //void ConvertUsing(Func<TSource, TDestination, ResolutionContext, TDestination> mappingFunction);
        //void ConvertUsing(ITypeConverter<TSource, TDestination> converter);
        //void ConvertUsing<TTypeConverter>() where TTypeConverter : ITypeConverter<TSource, TDestination>;
        IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction);

        //IMappingExpression<TSource, TDestination> BeforeMap(
        //    Action<TSource, TDestination, ResolutionContext> beforeFunction);

        //IMappingExpression<TSource, TDestination> BeforeMap<TMappingAction>()
        //    where TMappingAction : IMappingAction<TSource, TDestination>;

        IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction);

        //IMappingExpression<TSource, TDestination> AfterMap(
        //    Action<TSource, TDestination, ResolutionContext> afterFunction);

        //IMappingExpression<TSource, TDestination> AfterMap<TMappingAction>()
        //    where TMappingAction : IMappingAction<TSource, TDestination>;

        IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor);

        IMappingExpression<TSource, TDestination> ConstructProjectionUsing(
            Expression<Func<TSource, TDestination>> ctor);

        //IMappingExpression<TSource, TDestination> ConstructUsing(
        //    Func<TSource, ResolutionContext, TDestination> ctor);

        void As<T>() where T : TDestination;
        IMappingExpression<TSource, TDestination> MaxDepth(int depth);
        IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator();
        IMappingExpression<TDestination, TSource> ReverseMap();

        //IMappingExpression<TSource, TDestination> ForSourceMember(Expression<Func<TSource, object>> sourceMember,
        //    Action<ISourceMemberConfigurationExpression> memberOptions);

        //IMappingExpression<TSource, TDestination> ForSourceMember(string sourceMemberName,
        //    Action<ISourceMemberConfigurationExpression> memberOptions);

        IMappingExpression<TSource, TDestination> Substitute<TSubstitute>(
            Func<TSource, TSubstitute> substituteFunc);

        //IMappingExpression<TSource, TDestination> ForCtorParam(string ctorParamName,
        //    Action<ICtorParamConfigurationExpression<TSource>> paramOptions);

        IMappingExpression<TSource, TDestination> DisableCtorValidation();
    }
}