using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LinqKit;

namespace MezbanCommon.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> collection, string[] filterFields, string search)
        {
            if (string.IsNullOrWhiteSpace(search) || filterFields == null || filterFields.Length == 0)
            {
                return collection;
            }
            var properties = typeof(T).GetProperties().Where(p =>
                    p.PropertyType == typeof(String) && filterFields.Contains(p.Name));
            var propertyInfos = properties as PropertyInfo[] ?? properties.ToArray();
            if (!propertyInfos.Any())
            {
                return collection;
            }
            var predicate = PredicateBuilder.New<T>(false);
            foreach (var property in propertyInfos)
            {
                predicate = predicate.Or(CreateLike<T>(property, search));
            }
            return collection.AsExpandable().Where(predicate);
        }

        public static IQueryable<T> Filter<T>(this IQueryable<T> collection, string filterExpression, bool caseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(filterExpression))
            {
                return collection;
            }

            string[] filterSeparators = { " && " };
            string[] innerSeparators = { " = " };
            var filters = filterExpression.Split(filterSeparators, StringSplitOptions.None);
            
            var filterItems = filters.Select(
                filter =>
                {
                    var items = filter.Split(innerSeparators, StringSplitOptions.None);
                    return new 
                    {
                        FilterKey = items[0],
                        FilterValue = items[1]
                    };
                });

            var properties = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(String))
                .Where(p => filterItems.Select(x => x.FilterKey).Contains(p.Name));

            var propertyInfos = properties as PropertyInfo[] ?? properties.ToArray();
            if (!propertyInfos.Any())
            {
                return collection;
            }
            var predicate = PredicateBuilder.New<T>(true);
            foreach (var property in propertyInfos)
            {
                var search = filterItems.First(x => x.FilterKey == property.Name).FilterValue.ToLower();
                if (!string.IsNullOrWhiteSpace(search))
                {
                    predicate = predicate.And(CreateLike<T>(property, search, caseSensitive));
                }
            }

            return collection.AsExpandable().Where(predicate);
        }
        public static IQueryable<T> FilterInMemory<T>(this IQueryable<T> collection, string[] filterFields, string search)
        {
            if (string.IsNullOrWhiteSpace(search) || filterFields == null || filterFields.Length == 0)
            {
                return collection;
            }
            var properties = typeof(T).GetProperties().Where(p =>
                    p.PropertyType == typeof(String) && filterFields.Contains(p.Name));
            var propertyInfos = properties as PropertyInfo[] ?? properties.ToArray();
            if (!propertyInfos.Any())
            {
                return collection;
            }
            var predicate = PredicateBuilder.New<T>(false);
            foreach (var property in propertyInfos)
            {
                predicate = predicate.Or(CreateIndex<T>(property, search));
            }
            return collection.AsExpandable().Where(predicate);
        }
        private static Expression<Func<T, bool>> CreateLike<T>(PropertyInfo prop, string value, bool caseSensitive = false)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, prop.Name); //x.field
            var constant = Expression.Constant(value);
            var body = Expression.Call(member, nameof(string.Contains), null, constant); //x.field.contain(value)
            if (!caseSensitive)
            {
                body = Expression.Call(Expression.Call(member, nameof(string.ToLower), null), nameof(string.Contains), null, constant); //x.field.contain(value)    
            }
            var nullExp = Expression.Call(typeof(string), (typeof(string).GetMethod(nameof(string.IsNullOrEmpty))).Name, null, member); //!x.field.IsNullOrEmpty(value)
            var notnullExp = Expression.Not(nullExp);
            var andAlso = Expression.AndAlso(notnullExp, body);
            return Expression.Lambda<Func<T, bool>>(andAlso, parameter);//x!null && x.contain(value)
        }
        private static Expression<Func<T, bool>> CreateIndex<T>(PropertyInfo prop, string value)
        {

            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, prop.Name); //x.field

            var constant = Expression.Constant(value);
            // var body = Expression.Call(member, nameof(string.Contains), null, constant); //x.field.contain(value)
            var indexOf = Expression.Call(member, nameof(string.IndexOf), null, constant, Expression.Constant(StringComparison.OrdinalIgnoreCase));//x.Indexof(value,StringComparison.OrdinalIgnoreCase)
            var like = Expression.GreaterThanOrEqual(indexOf, Expression.Constant(0));//x.IndexOf(value,StringComparison.OrdinalIgnoreCase) >=0
            var nullExp = Expression.Call(typeof(string), (typeof(string).GetMethod(nameof(string.IsNullOrEmpty))).Name, null, member); //!x.field.IsNullOrEmpty(value)
            var notnullExp = Expression.Not(nullExp);
            var andAlso = Expression.AndAlso(notnullExp, like);
            return Expression.Lambda<Func<T, bool>>(andAlso, parameter);//x!null && x.IndexOf(value,StringComparison.OrdinalIgnoreCase) >=0
        }
    }
}
