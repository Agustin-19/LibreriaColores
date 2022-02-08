using LibreriaColores.Modelos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaColores.Precentacion
{
    public partial class FrmSplash : Form
    {
        private bool CargaBBDDCompleta = false;
        private bool CargaReporteCompleta = false;
        public FrmSplash()
        {
            InitializeComponent();
        }

        
        private async void FrmSplash_Activated(object sender, EventArgs e)
        {
            await ConsultaDeDatosSqlAsync();
            await ImpresionReporteNoVisibleAsync();
        }
        
        private async Task ConsultaDeDatosSqlAsync()
        {
            await Task.Run(() =>
            {
                var db = new Libreria();
                var listaClientes = db.Clientes.ToList();
                var listaVentas = db.Ventas.ToList();
                var listaDetalles = db.DetalleDeVentas.ToList();
                var listaProductos = db.Productos.ToList();
                CargaBBDDCompleta = true;
            });
        }

        private async Task ImpresionReporteNoVisibleAsync()
        {
            await Task.Run(() =>
            {
                ReportViewer reporte = new ReportViewer();
                //abrimos el reporte utilizando la clase FileStream
                using var fs = new FileStream(@"reportes\RpBoleta.rdlc", FileMode.Open);
                //asignamos el archivo a la propiedad LocalReport del objeto ReportViewer
                reporte.LocalReport.LoadReportDefinition(fs);
                //buscamos los datos que va a graficar el reporte
                using var db = new Libreria();
                var clientes = db.Clientes.ToList();
                //asignamos los datos a la propiedad DataSources del ReportViewer, utilizando
                //un objeto del tipo ReportDataSource
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSCompleto", clientes));
                reporte.SetDisplayMode(DisplayMode.PrintLayout);
                reporte.RefreshReport();
                CargaReporteCompleta = true;
            });
        }
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Barra.Value = Barra.Value + 2;
            

            //si le damos a la barra de progreso un valor mayor al máximo(que en este caso es 100) no dá error, por ello validamos si ya llegó a 100
             if (Barra.Value == 100 || (CargaBBDDCompleta && CargaReporteCompleta))
             {
                 if (CargaBBDDCompleta && CargaReporteCompleta)
                 {
                     //apagamos el cronometro
                     timer1.Enabled = false;
                     var frmPaginaPrincipal = new FrmPaginaPrincipal();
                     frmPaginaPrincipal.ShowDialog();
                     this.Close();
                 }
                 else
                 {
                     Barra.Value = 0;
                 }
             }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
