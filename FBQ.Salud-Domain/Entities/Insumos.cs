using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Domain.Entities
{
    public class Insumos
    {
        public int InsumosId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Especialidad { get; set; }
        [Required]
        public int Stock { get; set; }
        
    }
}
