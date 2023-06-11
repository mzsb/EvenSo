#region Usings

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace EvenSo.Logic.Model.Event
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeType
    {
        ValueChanged,
        ElementAdded,
        ElementRemoved,
    }
}
