using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibreriaColores.Modelos
{
    public class Venta
    {
        public int Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public int DNICliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaRegistro { get; set; }
    }
}
