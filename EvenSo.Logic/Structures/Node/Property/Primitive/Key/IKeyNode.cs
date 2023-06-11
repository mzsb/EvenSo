namespace EvenSo.Logic.Structures.Node
{
    internal interface IKeyNode : IPrimitiveNode
    {
        Type KeyType { get; }

        Type EntityType { get; }

        object KeyValue { get; }
    }
}
