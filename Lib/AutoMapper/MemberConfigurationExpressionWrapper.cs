using System;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;

namespace AutoMapperImpl
{
    internal class MemberConfigurationExpressionWrapper<TSource, TDestination, TMember> : IMemberConfigurationExpression<TSource, TDestination, TMember>
    {
        private readonly AutoMapper.IMemberConfigurationExpression<TSource, TDestination, TMember> _memberConfigurationExpression;

        internal MemberConfigurationExpressionWrapper(AutoMapper.IMemberConfigurationExpression<TSource, TDestination, TMember> memberConfigurationExpression)
        {
            _memberConfigurationExpression = memberConfigurationExpression;
        }

        public void NullSubstitute(TMember nullSubstitute)
        {
            _memberConfigurationExpression.NullSubstitute(nullSubstitute);
        }

        public void NullSubstitute(object nullSubstitute)
        {
            throw new NotImplementedException();
        }

        public void ResolveUsing<TValueResolver>() where TValueResolver : IValueResolver<TSource, TDestination, TMember>
        {
            throw new NotImplementedException();
        }

        public void ResolveUsing<TValueResolver, TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>
        {
            throw new NotImplementedException();
        }

        public void ResolveUsing<TValueResolver, TSourceMember>(string sourceMemberName) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>
        {
            throw new NotImplementedException();
        }

        public void ResolveUsing(IValueResolver<TSource, TDestination, TMember> valueResolver)
        {
            throw new NotImplementedException();
        }

        public void ResolveUsing<TSourceMember>(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember> valueResolver, Expression<Func<TSource, TSourceMember>> sourceMember)
        {
            throw new NotImplementedException();
        }

        public void ResolveUsing<TResult>(Func<TSource, TResult> resolver)
        {
            _memberConfigurationExpression.ResolveUsing(resolver);
        }

        public void ResolveUsing<TResult>(Func<TSource, TDestination, TResult> resolver)
        {
            _memberConfigurationExpression.ResolveUsing(resolver);
        }

        public void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, TResult> resolver)
        {
            _memberConfigurationExpression.ResolveUsing(resolver);
        }

        public void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, ResolutionContext, TResult> resolver)
        {
            throw new NotImplementedException();
        }

        public void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember)
        {
            _memberConfigurationExpression.MapFrom(sourceMember);
        }

        public void MapFrom(string property)
        {
            _memberConfigurationExpression.MapFrom(property);
        }

        public void MapFromExplicit<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember)
        {
            _memberConfigurationExpression.MapFrom(sourceMember);
            _memberConfigurationExpression.ExplicitExpansion();
        }

        public void Ignore()
        {
            _memberConfigurationExpression.Ignore();
        }

        public void AllowNull()
        {
            throw new NotImplementedException();
        }

        public void SetMappingOrder(int mappingOrder)
        {
            _memberConfigurationExpression.SetMappingOrder(mappingOrder);
        }

        public void UseDestinationValue()
        {
            _memberConfigurationExpression.UseDestinationValue();
        }

        public void DoNotUseDestinationValue()
        {
            _memberConfigurationExpression.DoNotUseDestinationValue();
        }

        public void UseValue<TValue>(TValue value)
        {
            _memberConfigurationExpression.UseValue(value);
        }

        public void Condition(Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool> condition)
        {
            throw new NotImplementedException();
        }

        public void Condition(Func<TSource, TDestination, TMember, TMember, bool> condition)
        {
            _memberConfigurationExpression.Condition(condition);
        }

        public void Condition(Func<TSource, TDestination, TMember, bool> condition)
        {
            _memberConfigurationExpression.Condition(condition);
        }

        public void Condition(Func<TSource, TDestination, bool> condition)
        {
            _memberConfigurationExpression.Condition(condition);
        }

        public void Condition(Func<TSource, bool> condition)
        {
            _memberConfigurationExpression.Condition(condition);
        }

        public void PreCondition(Func<TSource, bool> condition)
        {
            _memberConfigurationExpression.PreCondition(condition);
        }

        public void PreCondition(Func<ResolutionContext, bool> condition)
        {
            throw new NotImplementedException();
        }

        public void ExplicitExpansion()
        {
            _memberConfigurationExpression.ExplicitExpansion();
        }

        public MemberInfo DestinationMember { get; private set; }
    }
}