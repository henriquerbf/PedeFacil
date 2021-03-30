using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Cardapio_Item
    {
        [Key]
        public int id_Cardapio_Item { get; set; }

        public int id_Tipo { get; set; }

        [Required(ErrorMessage = "Digite um nome para o item", AllowEmptyStrings = false)]
        [Display(Name = "Nome do item")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite um valor para o item")]
        public float Valor { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Valor de desconto")]
        public float vl_Desconto { get; set; }

        [Display(Name = "Item em destaque")]
        public byte ic_Destaque { get; set; }

        public int id_Cardapio { get; set; }

        [Required(ErrorMessage = "Indique se o produto está ativo ou nao")]
        public byte ic_Ativo { get; set; }
    }
}