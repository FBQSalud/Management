using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Dtos
{
    public class InsumosGetDto
    {
        public int InsumosId { get; set; }

        public string Nombre { get; set; }

        public string Especialidad { get; set; }

        public int Stock { get; set; }
    }
}
