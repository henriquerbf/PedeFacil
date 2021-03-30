using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Tipo
    {
        [Key]
        public int id_Tipo { get; set; }

        public string Descricao { get; set; }

        public string ds_Grupo { get; set; }
    }
}