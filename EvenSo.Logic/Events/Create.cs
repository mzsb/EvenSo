using EvenSo.Logic.Enums;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace EvenSo.Logic.Events
{
    public sealed class Create : Event 
    {
        public override EventType Type => EventType.Create;
    }
}
