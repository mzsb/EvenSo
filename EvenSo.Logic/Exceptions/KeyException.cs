using EvenSo.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Exceptions
{
    internal sealed class KeyException : Exception
    {
        public IEnumerable<KeyType>? KeyTypes { get; }
        internal KeyException(string? message = default, IEnumerable<KeyType>? keyTypes = default) : base(message)
        {
            KeyTypes = keyTypes;
        }
    }
}
