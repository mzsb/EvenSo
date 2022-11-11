#region Usings

using Newtonsoft.Json;

#endregion


namespace EvenSo.Logic.Extensions
{
    public static class Json
    {
        public static string ToJson(this object item) =>
            JsonConvert.SerializeObject(item, Constants._jsonSerializerSettings);
    }
}
