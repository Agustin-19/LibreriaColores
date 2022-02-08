using LibreriaColores.Modelos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LibreriaColores.Precentacion
{
    public partial class FrmBoleta : Form
    {
        private readonly ReportViewer reporte;
        
        int ventaSeleccionada;
        Libreria db = new Libreria();
        public FrmBoleta(int IdVenta)
        {
            InitializeComponent();
            ventaSeleccionada = IdVenta;

            //instanciamos un Visor de Reportes
            reporte = new ReportViewer();
            //hacemos que ocupe toda el formulario
            reporte.Dock = DockStyle.Fill;
            //agregamos visualmente el visor de reportes al formulario
            Controls.Add(reporte);
        }

        private void FrmBoleta_Load(object sender, EventArgs e)
        {
            //abrimos el reporte utilizando la clase FileStream
            using var fs = new FileStream(@"reportes\RpBoleta.rdlc", FileMode.Open);
            //asignamos el archivo a la propiedad LocalReport del objeto ReportViewer
            reporte.LocalReport.LoadReportDefinition(fs);
            //buscamos los datos que va a graficar el reporte

            if (ventaSeleccionada > 0)
            {
                var listaDetalle = from detalleDeVenta in db.DetalleDeVentas
                             join venta in db.Ventas
                             on detalleDeVenta.IdVenta equals venta.Id
                             where detalleDeVenta.IdVenta == ventaSeleccionada
                             select new
                             {

                                 Id = detalleDeVenta.Id,
                                 IdVenta = detalleDeVenta.IdVenta,
                                 IdPrducto = detalleDeVenta.IdProducto,
                                 Producto = detalleDeVenta.Producto,
                                 PrecioVenta = detalleDeVenta.PrecioVenta,
                                 Cantidad = detalleDeVenta.Cantidad,
                                 SubTotal = detalleDeVenta.SubTotal,
                                 DNICliente = detalleDeVenta.DNICliente, 
                                 NombreCliente = detalleDeVenta.NombreCliente,
                                 MontoPago =  detalleDeVenta.MontoPago,
                                 MontoTotal =  detalleDeVenta.MontoTotal,
                                 MontoCambio = detalleDeVenta.MontoCambio,
                                 FechaRegistro = detalleDeVenta.FechaRegistro
                             };
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSCompleto", listaDetalle.ToList()));
                reporte.SetDisplayMode(DisplayMode.PrintLayout);
                reporte.RefreshReport();
            }
            else
            {
                
            }
        }
    }
}
