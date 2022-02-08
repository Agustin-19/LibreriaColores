using Microsoft.EntityFrameworkCore;
using LibreriaColores.Modelos;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaColores.Formularios;

namespace LibreriaColores
{
    public partial class FrmInventario : Form
    {
        public Producto _Producto { get; set; }
        public FrmInventario()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            using Libreria db = new Libreria();
            GridInventario.DataSource = db.Productos.ToList();
        }
        private void ActualizarGrillaFiltrada()
        {
            using Libreria db = new Libreria();
            GridInventario.DataSource = db.Productos.Where(s => s.Nombre.Contains(TxtBuscar.Text)
            || s.Marca.ToString().Contains(TxtBuscar.Text)).ToList();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmEditarInventario frmEditarInventario = new FrmEditarInventario();
            frmEditarInventario.ShowDialog();
            ActualizarGrilla();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var idSeleccionado = Convert.ToInt32(GridInventario.CurrentRow.Cells[0].Value);
            var nombreSeleccionado = GridInventario.CurrentRow.Cells[1].Value.ToString() + " " + GridInventario.CurrentRow.Cells[2].Value.ToString();


            DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea borrar a {nombreSeleccionado}?", "Eliminar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (respuesta == DialogResult.Yes)
            {

                using Libreria db = new Libreria();


                Producto inventarios = db.Productos.Find(idSeleccionado);

                db.Productos.Remove(inventarios);


                db.SaveChanges();
                ActualizarGrilla();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            var idSeleccionado = Convert.ToInt32(GridInventario.CurrentRow.Cells[0].Value);
            FrmEditarInventario frmEditarInventario = new FrmEditarInventario(idSeleccionado);
            frmEditarInventario.ShowDialog();
            ActualizarGrilla();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Length > 0)
                ActualizarGrillaFiltrada();
            else
                ActualizarGrilla();
        }

        private void GridInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >= 0)
            {
                _Producto = new Producto()
                {
                    Id = Convert.ToInt32(GridInventario.CurrentRow.Cells["Id"].Value),
                    Nombre = GridInventario.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Marca = GridInventario.Rows[iRow].Cells["Marca"].Value.ToString(),
                    Detalle = GridInventario.Rows[iRow].Cells["Detalle"].Value.ToString(),
                    Precio = Convert.ToDecimal(GridInventario.CurrentRow.Cells["Precio"].Value)
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
