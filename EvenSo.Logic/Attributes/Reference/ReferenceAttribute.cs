namespace EvenSo.Logic.Attributes.Reference
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ReferenceAttribute : Attribute
    {
        public ReferenceAttribute(Type? of = null) 
        {
            EntityType = of;
        }

        internal Type? EntityType { get; }
    }
}
