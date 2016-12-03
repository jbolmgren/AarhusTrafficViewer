using System;
using System.Linq.Expressions;
using AutoMapper;

namespace AutoMapperImpl
{
    internal class MappingExpressionWrapper<TSource, TDestination> : Core.Mapper.IMappingExpression<TSource, TDestination>
    {
        private readonly AutoMapper.IMappingExpression<TSource, TDestination> _mappingExpression;

        internal MappingExpressionWrapper(AutoMapper.IMappingExpression<TSource, TDestination> mappingExpression)
        {
            _mappingExpression = mappingExpression;
        }

        private static Action<AutoMapper.IMemberConfigurationExpression<TSource, TDestination, TMember>>
            WrapMemberOptions<TMember>
            (Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
        {
            return memberConfiguration =>
                   {
                       memberOptions(new MemberConfigurationExpressionWrapper<TSource, TDestination, TMember>(memberConfiguration));
                   };
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> PreserveReferences()
        {
            _mappingExpression.PreserveReferences();
            return this;
        }

        public void ForAllOtherMembers(Action<Core.Mapper.IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            throw new NotImplementedException();
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<Core.Mapper.IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
        {
            throw new NotImplementedException();
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ForMember(string name, Action<Core.Mapper.IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            throw new NotImplementedException();
        }

        public void ForAllMembers(Action<Core.Mapper.IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            throw new NotImplementedException();
        }

        public void ForAllOtherMembers(
            Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            _mappingExpression.ForAllOtherMembers(WrapMemberOptions(memberOptions));
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ForMember<TMember>(
            Expression<Func<TDestination, TMember>> destinationMember,
            Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
        {
            _mappingExpression.ForMember(destinationMember, WrapMemberOptions(memberOptions));
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ForMember(string name,
                                                                   Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            _mappingExpression.ForMember(name, WrapMemberOptions(memberOptions));
            return this;
        }

        public void ForAllMembers(Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            _mappingExpression.ForAllMembers(WrapMemberOptions(memberOptions));
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> IgnoreAllPropertiesWithAnInaccessibleSetter()
        {
            _mappingExpression.IgnoreAllPropertiesWithAnInaccessibleSetter();
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
        {
            _mappingExpression.IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>()
            where TOtherSource : TSource
            where TOtherDestination : TDestination
        {
            _mappingExpression.Include<TOtherSource, TOtherDestination>();
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> IncludeBase<TSourceBase, TDestinationBase>()
        {
            _mappingExpression.IncludeBase<TSourceBase, TDestinationBase>();
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> Include(Type derivedSourceType, Type derivedDestinationType)
        {
            _mappingExpression.Include(derivedSourceType, derivedDestinationType);
            return this;
        }

        public void ProjectUsing(Expression<Func<TSource, TDestination>> projectionExpression)
        {
            _mappingExpression.ProjectUsing(projectionExpression);
        }

        public void ConvertUsing(Func<TSource, TDestination> mappingFunction)
        {
            _mappingExpression.ConvertUsing(mappingFunction);
        }

        public void ConvertUsing(Func<TSource, TDestination, TDestination> mappingFunction)
        {
            _mappingExpression.ConvertUsing(mappingFunction);
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction)
        {
            _mappingExpression.BeforeMap(beforeFunction);
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction)
        {
            _mappingExpression.AfterMap(afterFunction);
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor)
        {
            _mappingExpression.ConstructUsing(ctor);
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ConstructProjectionUsing(
            Expression<Func<TSource, TDestination>> ctor)
        {
            _mappingExpression.ConstructProjectionUsing(ctor);
            return this;
        }

        public void As<T>() where T : TDestination
        {
            _mappingExpression.As<T>();
        }


        public Core.Mapper.IMappingExpression<TSource, TDestination> MaxDepth(int depth)
        {
            _mappingExpression.MaxDepth(depth);
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator()
        {
            _mappingExpression.ConstructUsingServiceLocator();
            return this;
        }

        public Core.Mapper.IMappingExpression<TDestination, TSource> ReverseMap()
        {
            return new MappingExpressionWrapper<TDestination, TSource>(_mappingExpression.ReverseMap());
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> Substitute<TSubstitute>(
            Func<TSource, TSubstitute> substituteFunc)
        {
            _mappingExpression.Substitute(substituteFunc);
            return this;
        }

        public Core.Mapper.IMappingExpression<TSource, TDestination> DisableCtorValidation()
        {
            _mappingExpression.DisableCtorValidation();
            return this;
        }
    }
}