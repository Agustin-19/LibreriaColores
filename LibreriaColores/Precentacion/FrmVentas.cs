using LibreriaColores.Formularios;
using LibreriaColores.Modelos;
using LibreriaColores.Precentacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibreriaColores
{
    public partial class FrmVentas : Form
    {
       
        public FrmVentas()
        {
            InitializeComponent();
            ActualizarGrilla();
           
        }
        private void ActualizarGrilla()
        {
            using Libreria db = new Libreria();
            GridVenta1.DataSource = db.Ventas.ToList();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInventario frmInventario = new FrmInventario();
            frmInventario.ShowDialog();

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditarCliente frmEditarCliente = new FrmEditarCliente();
            frmEditarCliente.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditarInventario frmEditarInventario = new FrmEditarInventario();
            frmEditarInventario.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {

            TxtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            LimpiarCliente();
            
            NudCantidad.Value = 1;
        }

        private void BtnBusCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmClientes())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    TxtNombre.Text = modal._Cliente.Nombre + " " + modal._Cliente.Apellido;
                    NudDNI.Value = modal._Cliente.DNI;
                    TxtIdCliente.Text = modal._Cliente.Id.ToString("0");
                    TxtProducto.Select();
                }
                else
                {
                    TxtNombre.Select();
                }
            }



        }

        private void BtnBusProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmInventario())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    TxtIdProducto.Text = modal._Producto.Id.ToString("0");
                    TxtProducto.Text = modal._Producto.Nombre;
                    TxtMarca.Text = modal._Producto.Marca;
                    TxtPrecio.Text = modal._Producto.Precio.ToString("0.00");
                    NudCantidad.Select();
                    BtnAgregar.Enabled = true;
                }
                else
                {
                    TxtProducto.Select();
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExiste = false;

            if (TxtProducto == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(TxtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(NudCantidad.Value.ToString()) >= 0)
            {

            }

            foreach (DataGridViewRow fila in GridVentas.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == TxtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                GridVentas.Rows.Add(new object[]
                {
                    TxtIdProducto.Text,
                    TxtProducto.Text,
                    precio.ToString("0.00"),
                    NudCantidad.Value.ToString(),
                    (NudCantidad.Value * precio).ToString("0.00")
                });
            }

            CalcularTotal();
            LimpiarProducto();
            TxtProducto.Select();
        }


        // calcular el total sumando los valores en la celda SubTotal
        private void CalcularTotal()
        {
            decimal total = 0;
            if (GridVentas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in GridVentas.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            TxtTotal.Text = total.ToString("0.00");
        }

        private void LimpiarProducto()
        {
            TxtProducto.Text = "";
            TxtPrecio.Text = "0,00";
            TxtIdProducto.Text = "0";
            TxtMarca.Text = "";
            NudCantidad.Value = 1;
            BtnAgregar.Enabled = false;
        }

        
        //descartado
        private void GridVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }
        //descartado
        private void GridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxtPaga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtPaga.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            
        }

        // calcular el cambio utilizando el valor ingresado por teclado en "TxtPagaCon" 
        // y se le resta el valor de "TxtTotal"
        private void calcularCambio()
        {
            if (TxtTotal.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(TxtTotal.Text);

            if (TxtPaga.Text.Trim() == "")
            {
                TxtPaga.Text = "0";
            }

            if (decimal.TryParse(TxtPaga.Text.Trim(), out pagacon))
            {
                if (pagacon < total)
                {
                    TxtCambio.Text = "0,00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    TxtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        // Al precionar la tecla enter se le da lugar a la funcion "calcularCambio"
        private void TxtPaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularCambio();
            }
            BtnCrearVenta.Enabled = true;
        }

         //El boton "crearVenta" hace 50mil cosas 
        private void BtnCrearVenta_Click(object sender, EventArgs e)
        {
            // Hacegurar que se ingrese un cliente. Por defecto esta Seleccionado "consumidor final" 
            if (TxtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // si no hay proguctos ingresados en el DataGridView, no pordra seguir con la venta

            if (GridVentas.Rows.Count < 1 )
            {
                MessageBox.Show("Debe ingresar un Producto para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            calcularCambio();

            
            using Libreria db = new Libreria();


            // guardamos los datos en la tabla venta 
            Venta venta = new Venta();

            
            venta.IdCliente = Convert.ToInt32(TxtIdCliente.Text);
            venta.DNICliente = Convert.ToInt32(NudDNI.Value);
            venta.NombreCliente = TxtNombre.Text;
            venta.MontoPago = Convert.ToDecimal(TxtPaga.Text);
            venta.MontoTotal = Convert.ToDecimal(TxtTotal.Text);
            venta.MontoCambio = Convert.ToDecimal(TxtCambio.Text);
            venta.FechaRegistro = TxtFecha.Text;

            db.Ventas.Add(venta);

            db.SaveChanges();

            //optengo el Ultimo Id generado en la tabla "Ventas"
            //para luego utilizarlo en la tabla "DetalleDeVentas"
            
            int OptnerIDVenta = GridVenta1.RowCount + 1;
            ActualizarGrilla();

            //el foreach recorre el DataGridView para optener los datos de los productos.
            foreach (DataGridViewRow row in GridVentas.Rows)
            {
                // se guardan los datos optenidos en la tabla "DetalleDeVentas"
                DetalleDeVenta detalleDeVenta = new DetalleDeVenta();

                detalleDeVenta.IdVenta = OptnerIDVenta;
                detalleDeVenta.IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                detalleDeVenta.Producto = Convert.ToString(row.Cells["Producto"].Value);
                detalleDeVenta.PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
                detalleDeVenta.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                detalleDeVenta.SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);
                //datos estras utilizados en los reportes.
                detalleDeVenta.DNICliente = Convert.ToInt32(NudDNI.Value);
                detalleDeVenta.NombreCliente = TxtNombre.Text;
                detalleDeVenta.MontoPago = Convert.ToDecimal(TxtPaga.Text);
                detalleDeVenta.MontoTotal = Convert.ToDecimal(TxtTotal.Text);
                detalleDeVenta.MontoCambio = Convert.ToDecimal(TxtCambio.Text);
                detalleDeVenta.FechaRegistro = Convert.ToDateTime(TxtFecha.Text);

                
                db.DetalleDeVentas.Add(detalleDeVenta);

                db.SaveChanges();
            }



            
            //limpiamos la pantalla 
            LimpiarCliente();

            GridVentas.Rows.Clear();

            GridVentas.Refresh();

            if (OptnerIDVenta > 0)
            {
                var result = MessageBox.Show("¿Desea imprimir comproante? ", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    FrmVerVentas frmVerVentas = new FrmVerVentas();
                    frmVerVentas.ShowDialog();
                }
            }
            MessageBox.Show("Venta Completada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                
                
                );
            
           
          


            //fin del Boton CrearVenta
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerVentas frmVerVentas = new FrmVerVentas();
            frmVerVentas.ShowDialog();
        }

        // limpiar los datos ingresados correspondientes al cliente, total a pagar, cambio,
        // y apagamos los botones "agragar" y "crearVenta" 
        private void LimpiarCliente()
        {
            TxtIdCliente.Text = "0";
            TxtNombre.Text = "Consumidor Final";
            NudDNI.Value = 11111;
            TxtPaga.Text = "";
            TxtCambio.Text = "0,00";
            TxtTotal.Text = "0,00";
            BtnCrearVenta.Enabled = false;
            
        }
        

        // Codigo para "pintar" el boton de eliminar en el dataGridView
        private void GridVentas_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.eliminar__1_.Width;
                var h = Properties.Resources.eliminar__1_.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.eliminar__1_, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        // Eliminar una fila del DataGridView, caon el boton "elimina" (pintado) 
        private void GridVentas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (GridVentas.Columns[e.ColumnIndex].Name == "elimina")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    GridVentas.Rows.RemoveAt(index);
                    CalcularTotal();
                }
            }
        }

        
    }
}
