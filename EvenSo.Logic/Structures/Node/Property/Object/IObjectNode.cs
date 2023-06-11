#region Usings

using EvenSo.Logic.Attributes;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    internal interface IObjectNode : IPropertyNode<object?>
    {
        public Type ObjectType { get; }

        public IEnumerable<IKeyNode> Keys { get; }

        void UpdateChildren();

        bool Has<T>() where T : KeyAttribute;

        IKeyNode Get<T>() where T : KeyAttribute;
    }
}
