using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entity
{
    public class Shelter
    {
        [Key]
        public long ShelterID { get; set; }

        [Required(ErrorMessage = "O nome do abrigo é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O endereço deve ter entre 5 e 200 caracteres.")]
        public string Address { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a 0.")]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser maior que 0.")]
        public int Capacity { get; set; }

        // Relação 1:N com User
        public ICollection<User> Users { get; set; } = new List<User>();

        public Shelter() { }

        public Shelter(long shelterID, string name, string address, int quantity, int capacity, int availableSpots)
        {
            ShelterID = shelterID;
            Name = name;
            Address = address;
            Quantity = quantity;
            Capacity = capacity;
        }
    }
}
