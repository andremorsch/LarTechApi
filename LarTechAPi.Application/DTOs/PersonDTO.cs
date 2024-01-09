using System.ComponentModel.DataAnnotations;

namespace LarTechAPi.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name invalid")]
        [MaxLength(50, ErrorMessage = "Name invalid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cpf is required")]
        [MinLength(11, ErrorMessage = "Cpf invalid")]
        [MaxLength(11, ErrorMessage = "Cpf invalid")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public bool IsActive { get; set; }
    }
}
