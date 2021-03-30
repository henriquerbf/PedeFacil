using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Usuario
    {
        [Key]
        public int id_Usuario { get; set; }

        public int id_Entidade { get; set; }

        public int id_Tipo { get; set; }

        [Required(ErrorMessage = "Digite um login para o usuario", AllowEmptyStrings = false)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite uma senha para o usuario", AllowEmptyStrings = false)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public byte ic_Ativo { get; set; }
    }
}