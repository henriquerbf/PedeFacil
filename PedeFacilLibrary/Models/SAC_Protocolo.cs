using System;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class SAC_Protocolo
    {
        [Key]
        public int id_SAC_Protocolo { get; set; }

        public int id_Entidade { get; set; }

        public int id_Tipo { get; set; }

        public DateTime dt_Abertura_Protocolo { get; set; }
    }
}