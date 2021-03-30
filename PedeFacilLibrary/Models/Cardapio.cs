using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Cardapio
    {
        [Key]
        public int id_Cardapio { get; set; }

        public int id_Entidade { get; set; }
    }
}