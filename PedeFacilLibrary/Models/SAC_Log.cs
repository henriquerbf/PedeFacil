using System;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class SAC_Log
    {
        [Key]
        public int id_SAC_Log { get; set; }

        public int id_SAC_Protocolo { get; set; }
        
        public int id_Entidade { get; set; }

        public string ds_Mensagem { get; set; }

        public string ds_Assunto { get; set; }

        public DateTime DataHora { get; set; }
    }
}