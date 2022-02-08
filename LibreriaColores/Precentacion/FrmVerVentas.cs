using LibreriaColores.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibreriaColores.Precentacion
{
    public partial class FrmVerVentas : Form
    {
        string ventaSeleccionada = "";
        int idSocioSeleccionado = 0;
        Libreria db = new Libreria();
        public FrmVerVentas()
        {
            InitializeComponent();
            ActualizarGrilla();
            BtnImprimir.Enabled = false;
            BtnImprimirT.Enabled = false;

        }

        private void GridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ordenarGrilla()
        {

        }

        private void ActualizarGrilla()
        {
            using Libreria db = new Libreria();
            
            var listaVentas = from Venta in db.Ventas
                          join Ventas in db.Ventas
                            on Venta.Id equals Ventas.Id
                          where Venta.NombreCliente == Venta.NombreCliente
                          orderby Venta.Id descending
                          select new
                          {
                              Id = Venta.Id,
                             Nombre = Venta.NombreCliente,
                              DNICliente = Venta.DNICliente,
                              Total = Venta.MontoTotal,
                              MontoPago = Venta.MontoPago,
                              Cambio = Venta.MontoCambio,
                              Fecha = Venta.FechaRegistro,

                          };

            GridVentas.DataSource = listaVentas.ToList();
            
                
        }
        private void ActualizarGrillaFiltrada()
        {
            using Libreria db = new Libreria();
            var listaVentas = from Venta in db.Ventas
                              join Ventas in db.Ventas
                                on Venta.Id equals Ventas.Id
                                where Venta.NombreCliente == Venta.NombreCliente
                                select new
                                {
                                    Id = Venta.Id,
                                    Nombre = Venta.NombreCliente,
                                    DNICliente = Venta.DNICliente,
                                    Total = Venta.MontoTotal,
                                    MontoPago = Venta.MontoPago,
                                    Cambio = Venta.MontoCambio,
                                    Fecha = Venta.FechaRegistro,

                                };
            GridVentas.DataSource = listaVentas.Where(s => s.Nombre.Contains(TxtBuscar.Text) 
            || s.DNICliente.ToString().Contains(TxtBuscar.Text)).ToList();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Length > 0)
                ActualizarGrillaFiltrada();
            else
                ActualizarGrilla();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridVentas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (GridVentas.Rows.Count > 0)
            {
                idSocioSeleccionado = (int)GridVentas.CurrentRow.Cells[0].Value;
                ventaSeleccionada = (string)GridVentas.CurrentRow.Cells[1].Value;
                LblDetalle.Text = ventaSeleccionada;
                DetalleDeLaVenta();
            }
        }
        private void DetalleDeLaVenta()
        {


            var listaDetalles = from DetalleDeVenta in db.DetalleDeVentas
                                join Venta in db.Ventas
                                on DetalleDeVenta.IdVenta equals Venta.Id
                                where DetalleDeVenta.IdVenta == idSocioSeleccionado && DetalleDeVenta.FechaRegistro != null
                                select new
                                {
                                    Id = DetalleDeVenta.Id,
                                    IdVenta = DetalleDeVenta.IdVenta,
                                    IdPrducto = DetalleDeVenta.IdProducto,
                                    Producto = DetalleDeVenta.Producto,
                                    PrecioVenta = DetalleDeVenta.PrecioVenta,
                                    Cantidad = DetalleDeVenta.Cantidad,
                                    SubTotal = DetalleDeVenta.SubTotal,
                                    Fecha = DetalleDeVenta.FechaRegistro,
                                };
            GridDetalle.DataSource = listaDetalles.ToList();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (GridVentas.Rows.Count > 0)
            {
                FrmBoleta frmBoleta = new FrmBoleta((int)GridVentas.CurrentRow.Cells[0].Value);
                frmBoleta.ShowDialog();
            }
            else
            {
                MessageBox.Show("No a seleccionado ninguna venta");
            }
            BtnImprimir.Enabled = false;
            BtnImprimirT.Enabled = false;
        }

        private void BtnImprimirT_Click(object sender, EventArgs e)
        {
            if (GridVentas.Rows.Count > 0)
            {
                FrmTicket frmTicket = new FrmTicket((int)GridVentas.CurrentRow.Cells[0].Value);
                frmTicket.ShowDialog();
            }
            else
            {
                MessageBox.Show("No a seleccionado ninguna venta");
            }
            BtnImprimir.Enabled = false;
            BtnImprimirT.Enabled = false;
        }
        
        private void BtnUltimaVenta_Click(object sender, EventArgs e)
        {
            GridVentas.ClearSelection();
            GridVentas.CurrentCell = null;
            GridVentas.Rows[GridVentas.Rows.Count - 1].Selected = true;
            BtnImprimir.Enabled = false;
            BtnImprimirT.Enabled = false;
        }

        private void GridVentas_Click(object sender, EventArgs e)
        {
            BtnImprimir.Enabled = true;
            BtnImprimirT.Enabled = true;
        }
    }
}
