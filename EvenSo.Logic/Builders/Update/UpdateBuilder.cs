#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Events;
using EvenSo.Logic.Extensions;
using System.Linq.Expressions;
using EvenSo.Logic.Model;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

#endregion

namespace EvenSo.Logic.Builders
{
    internal sealed class UpdateBuilder<T> : IUpdateBuilder<T>
    {
        private readonly IIdentifiable _item;

        private static readonly Regex _propertyRegex = new ("^[A-Z][^\\W|_]*$", RegexOptions.Compiled);
        private static readonly Regex _indexerRegex = new ("(get|Get|at|At+).*\\([0-9]+\\)$", RegexOptions.Compiled);

        private string _path = string.Empty;
        private Expression ex;
        internal UpdateBuilder(IIdentifiable item, string path = "")
        {
            _item = item;
            _path = path;
        }

        public IUpdateBuilder<T> Set<K>(Expression<Func<T, K>> exp, K value)
        {
            //var member = ((MemberExpression)exp.Body).Member;
            //var i = member.GetCustomAttributes().Where(ca => ca.ToString().Contains("Referenced"));
            //if (i.Any())
            //{
            //    ParameterExpression param = Expression.Parameter(typeof(IIdentifiable));

            //    Expression property = exp.Body.ToString().Split(".")[1..^1]
            //                    .Aggregate<string, Expression>
            //                    (param, (c, m) => Expression.Property(c, m));

            //    var lambda = Expression.Lambda<Func<IIdentifiable, object>>(
            //    Expression.Convert(property, member.DeclaringType), param);


            //    var o = lambda.Compile()((IIdentifiable)_item);

            //    var otype = o.GetType().GetProperty("Id")?.GetValue(o) ?? throw new System.Exception("Hiba");


            //    _ = 0;
            //}

            foreach (var part in exp.Body.ToString().Split(".").Skip(1))
            {
                if(part == "As()") { continue; }
                if (_propertyRegex.IsMatch(part))
                {
                    _path += $"/{part}"; 
                } 
                else
                if (_indexerRegex.IsMatch(part) &&
                    int.TryParse(part[(part.LastIndexOf('(') + 1)..^1], out int index))
                {
                    _path += $"/{index}";
                }
                else throw new System.Exception("Invalid path");
            }

            exp.Update(Expression.Assign(exp.Body, Expression.Constant(value)), exp.Parameters).Compile()((T)_item);

            return this;
        }

        public IUpdateBuilder<K> Over<K>(Expression<Func<T, K>> exp)
        {
            foreach (var part in exp.Body.ToString().Split(".").Skip(1))
            {
                if (part == "As()") { continue; }
                if (_propertyRegex.IsMatch(part))
                {
                    _path += $"/{part}";
                }
                else
                if (_indexerRegex.IsMatch(part) &&
                    int.TryParse(part[(part.LastIndexOf('(') + 1)..^1], out int index))
                {
                    _path += $"/{index}";
                }
                else throw new System.Exception("Invalid path");
            }

            return new UpdateBuilder<K>(_item, _path);
        }
    }
}
