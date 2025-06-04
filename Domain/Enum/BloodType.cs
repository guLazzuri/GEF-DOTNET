using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BloodType
    {
        APositive,

        ANegative,

        BPositive,

        BNegatuve,

        OPositive,

        ONegative,

        ABPositive,

        ABNegative


    }
}