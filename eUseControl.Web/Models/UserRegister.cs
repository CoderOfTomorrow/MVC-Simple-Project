using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class UserRegister
    {
        /*public string Nume { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }*/

        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Parola { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}