#region Usings

using System.Diagnostics;

#endregion

namespace EvenSo.Logic.Structures.Value
{
    [DebuggerDisplay("{Actual} ({Old})")]
    internal abstract class ChangeableValue<T> : IChangeableValue<T>
    {
        private readonly Func<T?> _valueGetter;

        protected ChangeableValue(Func<T?> valueGetter)
        {
            _valueGetter = valueGetter;
            Refresh();
        }

        public T? Old { get; private set; }

        public T? Actual { get; private set; }

        public abstract bool IsChanged { get; }

        public void Refresh() => 
            (Old, Actual) = (Actual, _valueGetter());
    }
}
