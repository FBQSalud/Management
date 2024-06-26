﻿using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Dtos
{
    public class InsumosDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Especialidad { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
