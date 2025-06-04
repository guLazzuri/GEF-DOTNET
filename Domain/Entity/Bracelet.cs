using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entity
{
    public class Bracelet
    {
        [Key]
        public long BraceletID { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public long UserId { get; set; }
        public int? LastBPM { get; set; }
        public DateTime LastUpdate { get; set; }
        public Bracelet() { }

        public Bracelet(
            long id,
            long userId,
            int LastBPM,
            DateTime lastUpdate)
        {
            BraceletID = id;
            UserId = userId;
            LastBPM = LastBPM;
            LastUpdate = lastUpdate;
        }
    }
}