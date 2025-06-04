using System.Text.Json.Serialization;

namespace Api.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        ADMIN,
        DOCTOR,
        PATIENT
    }
}