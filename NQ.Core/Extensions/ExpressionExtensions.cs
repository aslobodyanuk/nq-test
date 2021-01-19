using System;
using System.Linq.Expressions;

namespace NQ.Core.Extensions
{
    public static class ExpressionExtensions
    {
        public static Func<TIn, TOut> CreatePropertyAccessor<TIn, TOut>(string propertyName)
        {
            var param = Expression.Parameter(typeof(TIn));
            var body = Expression.PropertyOrField(param, propertyName);
            return Expression.Lambda<Func<TIn, TOut>>(body, param).Compile();
        }
    }
}
