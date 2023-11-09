using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models.ViewModels
{
    public class RegisterViewModel
    {
        //[Required] is a data annotation that tells the model binder that this property is required
        //(server side validation)
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage ="A Palavra-passe tem de ter no mínimo 6 caracteres" )]
        public string Password { get; set; }
    }
}
