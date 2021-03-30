using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Models
{
    public class Mesa
    {
        [Key]
        public int id_Mesa { get; set; }

        public int id_Entidade { get; set; }

        public string ds_Mesa { get; set; }

        public byte ic_Status { get; set; }
    }
}