namespace EvenSo.Logic.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class KeyAttribute : Attribute 
    {
        internal KeyAttribute(Type? entityType)
        {
            EntityType = entityType;
        }

        internal Type? EntityType { get; }
    }
}
