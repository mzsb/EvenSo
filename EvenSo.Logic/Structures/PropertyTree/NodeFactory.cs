using EvenSo.Caches;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Structures.PropertyTree
{
    public static class NodeFactory
    {
        private static IPropertyNode Create(
            Type type, 
            Func<object?> getter,
            string name,
            IPropertyNode? parent)
        {
            if (type.IsValueType || type == typeof(string))
            {
                return new PrimitiveNode(getter, name, parent);
            }

            if (type.IsEnumerable())
            {
                if(type.GetEnumerableType()?.IsPrimitive() ?? false)
                {
                    _ = 0;
                }

                return new EnumerableNode(getter, name, parent);
            }

            return new ObjectNode(getter, name, parent);
        }

        public static IPropertyNode Create(
            PropertyInfo propertyInfo,
            IPropertyNode? parent = null) 
        {
            var propertyType = propertyInfo.PropertyType;

            if(parent is null) throw new ArgumentNullException(nameof(parent));

            return Create(
                propertyInfo.PropertyType,
                () => propertyInfo.GetValue(parent.Value),
                propertyInfo.Name,
                parent);
        }

        public static IPropertyNode Create(
            object? value,
            string name = "",
            IPropertyNode? parent = null)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            return Create(
                value.GetType(),
                () => value,
                name,
                parent);
        }
    }
}
