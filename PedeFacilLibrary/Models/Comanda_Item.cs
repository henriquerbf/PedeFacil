using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Comanda_Item
    {
        [Key]
        public int id_Comanda_Item { get; set; }

        public int id_Comanda { get; set; }

        public int id_Cardapio_Item { get; set; }

        public int qtd_Cardapio_Item { get; set; }

        public float vl_Cardapio_Item { get; set; }
    }
}