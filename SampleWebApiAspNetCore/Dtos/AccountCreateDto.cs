using System.ComponentModel.DataAnnotations;

namespace WebApiAspNetCore.Dtos
{
    public class AccountCreateDto
    {
        [Required]
        public string FName { get; set; }
        public string LName { get; set; }
        public string ContactNum { get; set; }
        public string AccType { get; set; }
        public bool IsSubscribed { get; set; }
        public DateTime AccCreated { get; set; }
    }
}
