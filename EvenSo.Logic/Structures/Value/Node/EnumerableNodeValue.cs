#region Usings

using System.Collections;
using System.Collections.Immutable;

#endregion

namespace EvenSo.Logic.Structures.Value
{
    internal sealed class EnumerableNodeValue : ChangeableValue<IEnumerable<object?>>
    {
        internal EnumerableNodeValue(Func<object?> valueGetter) : 
            base(() => (valueGetter() as IEnumerable)?.Cast<object?>()?.ToImmutableArray()) { }

        public override bool IsChanged => (Old, Actual) switch
        {
            (null, null) => false,

            (null, not null) or
            (not null, null) => true,

            _ => Old.Count() != Actual.Count() ||
                 Old.Union(Actual)
                    .Except(Old.Intersect(Actual))
                    .Any()
        };
    }
}
