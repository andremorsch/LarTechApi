using System.ComponentModel.DataAnnotations;

namespace LarTechAPi.Application.DTOs
{
    public class PhoneDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone type is required")]
        [MinLength(3, ErrorMessage = "Phone type invalid")]
        [MaxLength(50, ErrorMessage = "Phone type invalid")]
        public string PhoneType { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MinLength(10, ErrorMessage = "Phone number invalid")]
        [MaxLength(11, ErrorMessage = "Phone number invalid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "PersonId is required")]
        public int PersonId { get; set; }

    }
}
