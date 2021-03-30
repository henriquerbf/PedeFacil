using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Entidade
    {
        [Key]
        public int id_Entidade { get; set; }

        public int id_Tipo { get; set; }

        [Required(ErrorMessage = "Digite um nome válido", AllowEmptyStrings = false)]
        [Display(Name = "Nome da entidade")]
        public string Nome { get; set; }

        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Digite um CPF/CNPJ válido")]
        [Display(Name = "CPF/CNPJ")]
        public string CNPJ_CPF { get; set; }

        [Display(Name = "Telefone")]
        public Int64 Telefone { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Endereco")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "CEP")]
        [RegularExpression(("[0-9]{5}[0-9]{3}"), ErrorMessage = "Informe um cep válido")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Digite um email", AllowEmptyStrings = false)]
        [RegularExpression(("(?<user>[^@]+)@(?<host>.+)"), ErrorMessage = "Informe um e-mail válido")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}