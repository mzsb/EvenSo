namespace EvenSo.Logic.Structures.Value
{
    internal static class NodeValueHelper
    {
        internal static IChangeableValue<object?> ToChangeableValue(this Func<object?> valueGetter) =>
            new ObjectNodeValue(valueGetter);

        internal static IChangeableValue<IEnumerable<object?>> ToEnumerableChangeableValue(this Func<object?> valueGetter) =>
            new EnumerableNodeValue(valueGetter);
    }
}
