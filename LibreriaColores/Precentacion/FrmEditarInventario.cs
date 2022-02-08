using LibreriaColores.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibreriaColores.Formularios
{
    public partial class FrmEditarInventario : Form
    {
        private int idProductoModificado = 0;
        public FrmEditarInventario()
        {
            InitializeComponent();
            BtnGuardar.Enabled = false;
        }

        public FrmEditarInventario(int idSeleccionado)
        {
            InitializeComponent();
            this.idProductoModificado = idSeleccionado;
            using Libreria db = new Libreria();
            Producto productos = db.Productos.Find(idSeleccionado);
            TxtNombre.Text = productos.Nombre;
            TxtMarca.Text = productos.Marca;
            TxtDetalle.Text = productos.Detalle;
            NumPrecio.Value = productos.Precio;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Producto productos = new Producto
            {
                Nombre = TxtNombre.Text,
                Marca = TxtMarca.Text,
                Detalle = TxtDetalle.Text,
                Precio = Convert.ToDecimal(NumPrecio.Value)
            };

            using Libreria db = new Libreria();
            if (this.idProductoModificado == 0)
            {
                db.Productos.Add(productos);
            }
            else
            {
                productos.Id = this.idProductoModificado;
                db.Entry(productos).State = EntityState.Modified;

            }
            db.SaveChanges();
            BtnGuardar.Enabled = false;
            TxtNombre.Text = string.Empty;
            TxtMarca.Text = string.Empty;
            TxtDetalle.Text = string.Empty;
            NumPrecio.Value = 0;
        }

        private void NumPrecio_ValueChanged(object sender, EventArgs e)
        {
            BtnGuardar.Enabled = true;
        }
    }
}
