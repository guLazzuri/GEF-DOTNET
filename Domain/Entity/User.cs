using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Api.Domain.Enum;

namespace Api.Domain.Entity
{
    public class User
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public double Weight { get; set; }
        public string ResponsableName { get; set; }
        public string CPF { get; set; }
        public string CardNumber { get; set; }
        public UserType UserType { get; set; }
        public long ShelterID { get; set; }

        public User() { }

        public User(long userID, string name, int age, Gender gender, BloodType bloodType, double weight, string responsableName, string cPF, string cardNumber, UserType userType, long braceletID, long shelterID)
        {
            UserID = userID;
            Name = name;
            Age = age;
            Gender = gender;
            BloodType = bloodType;
            Weight = weight;
            ResponsableName = responsableName;
            CPF = cPF;
            CardNumber = cardNumber;
            UserType = userType;
            ShelterID = shelterID;
        }

        public string ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length < 2 || Name.Length > 100)
                return "O nome deve ter entre 2 e 100 caracteres.";
            return null;
        }

        public string ValidateAge()
        {
            if (Age < 0 || Age > 130)
                return "A idade deve estar entre 0 e 130.";
            return null;
        }

        public string ValidateGender()
        {
            if (!System.Enum.IsDefined(typeof(Gender), Gender))
                return "O gênero é obrigatório.";
            return null;
        }

        public string ValidateBloodType()
        {
            if (!System.Enum.IsDefined(typeof(BloodType), BloodType))
                return "O tipo sanguíneo é obrigatório.";
            return null;
        }

        public string ValidateWeight()
        {
            if (Weight < 0.0 || Weight > 500.0)
                return "O peso deve estar entre 0 e 500 kg.";
            return null;
        }

        public string ValidateResponsableName()
        {
            if (!string.IsNullOrEmpty(ResponsableName) && ResponsableName.Length > 100)
                return "O nome do responsável deve ter no máximo 100 caracteres.";
            return null;
        }

        public string ValidateCPF()
        {
            if (!string.IsNullOrEmpty(CPF) && !Regex.IsMatch(CPF, @"^\d{11}$"))
                return "O CPF deve conter 11 dígitos numéricos.";
            return null;
        }

        public string ValidateCardNumber()
        {
            if (!string.IsNullOrEmpty(CardNumber) && CardNumber.Length > 20)
                return "O número do cartão deve ter no máximo 20 caracteres.";
            return null;
        }


        public List<string> ValidateAll()
        {
            var errors = new List<string>();
            var validations = new List<Func<string>>
            {
                ValidateName,
                ValidateAge,
                ValidateGender,
                ValidateBloodType,
                ValidateWeight,
                ValidateResponsableName,
                ValidateCPF,
                ValidateCardNumber,
            };

            foreach (var validate in validations)
            {
                var result = validate();
                if (!string.IsNullOrEmpty(result))
                    errors.Add(result);
            }

            return errors;
        }
    }
}
