namespace EvenSo.Logic.Structures.Value
{
    internal sealed class ObjectNodeValue : ChangeableValue<object?>
    {
        internal ObjectNodeValue(Func<object?> valueGetter) : base(valueGetter) { }

        public override bool IsChanged =>
            !Old?.Equals(Actual) ?? Actual is not null;
    }
}
