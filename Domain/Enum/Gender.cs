using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Masculine,
        Female
    }
}