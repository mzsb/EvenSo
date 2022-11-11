#region Usings

using EvenSo.Logic.Enums;
using Microsoft.Azure.Cosmos;
using System.Net;

#endregion

namespace EvenSo.Logic.Exceptions
{
    internal sealed class InvalidPathException : CosmosException
    {
        internal string InvalidPart => Message.Split("'")[1];

        #region Constructor

        internal InvalidPathException(CosmosException cosmosException)
            : base(cosmosException.Message,
                   cosmosException.StatusCode,
                   cosmosException.SubStatusCode,
                   cosmosException.ActivityId,
                   cosmosException.RequestCharge) { }
        
        #endregion
    }
}
