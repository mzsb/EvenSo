#region Usings

using EvenSo.Logic.Structures.Visitor;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    internal sealed class NullNode : INode
    {
        private NullNode() { }

        static NullNode() { }

        internal static readonly INode Instance = new NullNode();

        public string Key { get; } = nameof(NullNode);

        public object? Value { get; } = default;

        public INode Parent { get; } = Instance;

        public IEnumerable<INode> Children { get; } = Enumerable.Empty<INode>();

        public void Accept(INodeVisitor visitor) { }
    }
}
