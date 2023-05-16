using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Structures.PropertyTree
{
    public interface IChangeable
    {
        IEnumerable<IChange> Changes { get; }
    }

    public interface IChange
    {
        ChangeType ChangeType { get; }
        object? Value { get; }
    }

    public enum ChangeType
    {
        NewValue,
        NewElement,
        OldElement
    }

    public class Change : IChange
    {
        public ChangeType ChangeType { get; init; }

        public object? Value { get; init; }
    }
}
