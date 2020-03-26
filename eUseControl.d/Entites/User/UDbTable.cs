using eUseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entites.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name ="username")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Numele de utilizator nu poate fi mai lung de 30 de caractere")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Parola nu poate fi mai lung de 50 de caractere")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "email")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Email-ul nu poate fi mai lung de 50 de caractere")]
        public string Email { get; set; }

        public URole Level { get; set; }
    }
}
