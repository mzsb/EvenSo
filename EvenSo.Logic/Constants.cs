using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EvenSo.Logic
{
    public static class Constants
    {
        #region Event

        public const string _eventContainerId = "event-store";

        #endregion

        #region Json

        internal static readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            Formatting = Formatting.None,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        #endregion
    }
}
