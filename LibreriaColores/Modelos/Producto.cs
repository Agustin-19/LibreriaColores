using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibreriaColores.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
    }
}
