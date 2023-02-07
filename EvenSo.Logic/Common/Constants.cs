using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Numerics;

namespace EvenSo
{
    public static class Constants
    {
        #region Event

        internal const string _eventContainerId = "event-store";

        #endregion

        #region Json

        internal static readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            Formatting = Formatting.None,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            }
        };

        #endregion

        #region Type

        public static readonly Type[] PrimitiveLikeTypes =
        {
            typeof(decimal),
            typeof(string),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(Guid),
            typeof(TimeSpan),
            typeof(BigInteger),
            typeof(Uri),
        };

        #endregion


    }
}
