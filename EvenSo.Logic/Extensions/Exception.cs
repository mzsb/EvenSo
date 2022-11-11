#region Usings

using EvenSo.Logic.Enums;
using Microsoft.Azure.Cosmos;

#endregion

namespace EvenSo.Logic.Extensions
{
    internal static class Exception
    {
        internal static ExceptionType GetExceptionType(this CosmosException cosmosException) => (ExceptionType) cosmosException.HResult;
    }
}
