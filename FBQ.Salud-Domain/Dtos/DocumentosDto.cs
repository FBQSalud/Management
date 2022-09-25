using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Domain.Dtos
{
    public class DocumentosDto
    {
        public int DocumentoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
    }
}
