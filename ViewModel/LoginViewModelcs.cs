using System.ComponentModel.DataAnnotations;

namespace Chapter_TURMA14.ViewModel
{
    public class LoginViewModelcs
    {
        [Required(ErrorMessage = "Informe e-mail do usuario")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuario")]
        public string? senha { get; set; }


    }
}
