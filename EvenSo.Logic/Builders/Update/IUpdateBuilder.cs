#region Usings

using EvenSo.Logic.Model;
using System.Linq.Expressions;

#endregion

namespace EvenSo.Logic.Builders
{
    public interface IUpdateBuilder<T>
    {
        public IUpdateBuilder<T> Set<ValueType>(Expression<Func<T, ValueType>> exp, ValueType value);

        public IUpdateBuilder<K> Over<K>(Expression<Func<T, K>> exp);
    }
}
