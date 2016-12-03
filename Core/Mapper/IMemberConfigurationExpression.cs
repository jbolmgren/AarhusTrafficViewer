using System;
using System.Linq.Expressions;

namespace Core.Mapper
{
    public interface IMemberConfigurationExpression<TSource, TDestination, TMember>
    {
        void NullSubstitute(TMember nullSubstitute);
        //void ResolveUsing<TValueResolver>() where TValueResolver : IValueResolver<TSource, TDestination, TMember>;
        //void ResolveUsing<TValueResolver, TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>;
        //void ResolveUsing<TValueResolver, TSourceMember>(string sourceMemberName) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>;
        //void ResolveUsing(IValueResolver<TSource, TDestination, TMember> valueResolver);
        //void ResolveUsing<TSourceMember>(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember> valueResolver, Expression<Func<TSource, TSourceMember>> sourceMember);
        void ResolveUsing<TResult>(Func<TSource, TResult> resolver);
        void ResolveUsing<TResult>(Func<TSource, TDestination, TResult> resolver);
        void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, TResult> resolver);
        //void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, ResolutionContext, TResult> resolver);
        void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);
        //void MapFrom(string property);
        void MapFromExplicit<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);
        void Ignore();
        void SetMappingOrder(int mappingOrder);
        void UseDestinationValue();
        void DoNotUseDestinationValue();
        void UseValue<TValue>(TValue value);
        //void Condition(Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool> condition);
        void Condition(Func<TSource, TDestination, TMember, TMember, bool> condition);
        void Condition(Func<TSource, TDestination, TMember, bool> condition);
        void Condition(Func<TSource, TDestination, bool> condition);
        void Condition(Func<TSource, bool> condition);
        void PreCondition(Func<TSource, bool> condition);
        //void PreCondition(Func<ResolutionContext, bool> condition);
        void ExplicitExpansion();
    }
}