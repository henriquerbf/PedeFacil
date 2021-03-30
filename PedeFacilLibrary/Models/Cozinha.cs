using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedeFacilLibrary.Models
{
    public class Cozinha
    {
        [Key]
        public int id_Cozinha { get; set; }
        public int id_Comanda { get; set; }
        public int id_Comanda_Item { get; set; }
        public DateTime DataHora { get; set; }
        public byte ic_Status { get; set; }
        public string ds_Observacao { get; set; }
    }
}
