﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;

namespace MezbanCommon.Extensions
{
    public static class SortExtensions
    {
        public static IQueryable Sort(this IQueryable collection, string sortBy, bool reverse = false)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return collection;
            return collection.OrderBy(sortBy + (reverse ? " descending" : ""));
        }
        public static IQueryable<T> Sort<T>(this IQueryable<T> collection, string sortByFields)
        {
            if (string.IsNullOrWhiteSpace(sortByFields))
                return collection;
            return collection.OrderBy(sortByFields);
        }
        public static IOrderedEnumerable<T> SortOnMemory<T>(this IEnumerable<T> Source, string sortExpression)
        {
            var sortinfo = sortExpression.Split(' ');
            var memberName = sortinfo[0].Trim();
            var sortDirection = sortinfo.Length == 2 ? sortinfo[1].Trim() : "asc";
            
            MemberInfo mi = typeof(T).GetField(memberName);
            if (mi == null)
                mi = typeof(T).GetProperties().FirstOrDefault(x => x.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));
            //mi = typeof(T).GetProperty(memberName,t);
            if (mi == null)
                throw new InvalidOperationException("Field or property '" + memberName + "' not found");

            // get the field or property's type, and make a delegate type that takes a T and returns this member's type
            Type memberType = mi is FieldInfo ? (mi as FieldInfo).FieldType : (mi as PropertyInfo).PropertyType;
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), memberType);

            // we need to call ValueProxy.ReturnValue, which is a generic type
            MethodInfo genericReturnValueMethod = typeof(ValueProxy).GetMethod("GetValue");
            // it's type parameters are MemberType and <T>, so we "make" a method to bake in those specific types
            MethodInfo getValueMethod = genericReturnValueMethod.MakeGenericMethod(memberType, typeof(T));

            var proxy = new ValueProxy(mi);

            // now create a delegate using the delegate type and method we just constructed
            Delegate methodDelegate = Delegate.CreateDelegate(delegateType, proxy, getValueMethod);

            // method name on IEnumerable/IOrderedEnumerable to call later
            string methodName = null;

            // do we already have at least one sort on this collection?
           
                if (sortDirection.Equals("asc", StringComparison.OrdinalIgnoreCase))
                    methodName = "OrderBy";
                else
                    methodName = "OrderByDescending";
            

            MethodInfo method = typeof(Enumerable).GetMethods()
                .Single(m => m.Name == methodName && m.MakeGenericMethod(typeof(int), typeof(int)).GetParameters().Length == 2);
            var result = method.MakeGenericMethod(typeof(T), memberType)
                .Invoke(Source, new object[] {Source, methodDelegate});
            return result as IOrderedEnumerable<T>;
        }
    }
    public class ValueProxy
    {
        private MemberInfo Member;

        public T GetValue<T, TKey>(TKey obj)
        {
            if (Member is FieldInfo)
                return (T)(Member as FieldInfo).GetValue(obj);
            else if (Member is PropertyInfo)
                return (T)(Member as PropertyInfo).GetValue(obj, null);

            return default(T);
        }

        public ValueProxy(MemberInfo Member)
        {
            this.Member = Member;
        }
    }
}