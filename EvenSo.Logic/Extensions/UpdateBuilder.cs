#region Usings

using EvenSo.Logic.Builders;
using EvenSo.Logic.Model;
using System.Linq.Expressions;

#endregion

namespace EvenSo.Logic.Extensions
{
    public static class UpdateBuilder
    {
        public static IUpdateBuilder<T> GetUpdateBuilder<T>(this T item) where T : IIdentifiable =>
            new UpdateBuilder<T>(item);

        public static IUpdateBuilder<T> Set<T, K>(this T item, Expression<Func<T, K>> exp, K value) where T : IIdentifiable =>
            new UpdateBuilder<T>(item).Set(exp, value);
    }
}
