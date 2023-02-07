namespace EvenSo.PropertyTrees
{
    public enum PropertyNodeType
    {
        Node = 0,
        Internal = 1,
        External = 2,

        Collection = 4,

        Internal_Collection = Collection | Internal,
        External_Collection = Collection | External,
    }
}
