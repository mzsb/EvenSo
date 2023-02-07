#region Usings

using EvenSo.Caches;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

#endregion

namespace EvenSo.Events
{
    //public class ListIdJsonConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType) => objectType.IsNotSystem();

    //        //(objectType.IsArray &&
    //        // objectType.GetElementType() is Type elementType &&
    //        // elementType.IsNotPrimitive() //&& elementType.HasNo(Id)
    //        // )
    //        //    ||
    //        //(objectType.GetInterface(nameof(IEnumerable)) is not null &&
    //        // objectType.GenericTypeArguments.Length == 1 &&
    //        // objectType.GenericTypeArguments[0] is Type genericType &&
    //        // genericType.IsNotPrimitive() //&& genericType.HasNo(Id)
    //        // );
             
    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        var token = JToken.ReadFrom(reader);
    //        var i = token.Value<int>(KeyType.Id.ToString());

    //        //var dict = JToken.ReadFrom(reader).ToDictionary(
    //        //    token => token.Value<int>(Id.ToString()),
    //        //    token => token.SelectToken("value").ToObject(objectType.GenericTypeArguments[0], serializer));

    //        //foreach (var item in dict)
    //        //{
    //        //    IdCache.Cache.Add(item.Value, item.Key);
    //        //}
    //        var result = token.ToObject(objectType);

    //        KeyCache.AddId(result, i);

    //        return result;
    //    }

    //    public override bool CanWrite => false;

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //      => throw new NotImplementedException();
    //}
}
