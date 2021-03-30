using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Comanda
    {
        [Key]
        public int id_Comanda { get; set; }

        public int id_Entidade { get; set; }

        public int id_Mesa { get; set; }

        public string nm_Comanda { get; set; }

        public byte ic_Status { get; set; }

        public DateTime DataHora { get; set; }
    }
}