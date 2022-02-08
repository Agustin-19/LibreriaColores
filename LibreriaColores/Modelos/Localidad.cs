using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibreriaColores.Modelos
{
    public class Localidad
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
