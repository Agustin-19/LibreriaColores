using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibreriaColores.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
       
        public int DNI { get; set; }
        [Required]
        public string Teléfono { get; set; }
        [Required]
        public string Dirección { get; set; }
        public int LocalidadId { get; set; }
        public string Localidad { get; set; }
        public string Correo { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }
    }
}
