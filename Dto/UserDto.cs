using Api.Domain.Enum;

namespace Api.Dto
{
    namespace Api.Dto
    {
        public class UserDto
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Gender Gender { get; set; } // string para facilitar integração e serialização
            public BloodType BloodType { get; set; }
            public double Weight { get; set; }
            public string ResponsableName { get; set; }
            public string CPF { get; set; }
            public string CardNumber { get; set; }
            public UserType UserType { get; set; }
            public long ShelterID { get; set; }
        }
    }

}
