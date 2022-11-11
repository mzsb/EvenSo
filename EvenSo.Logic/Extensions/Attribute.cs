#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Model;
using System.Reflection;

#endregion

namespace EvenSo.Logic.Extensions
{
    public static class Attribute
    {
        //public static bool Is<T>(this PropertyInfo property) where T : AttributeBase =>
        //    AttributeBase.Is<T>(property);

        public static (string Name, object Value) Get<T>(this object item) where T : AttributeBase =>
            AttributeBase.Get<T>(item);
    }
}
