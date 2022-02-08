using Microsoft.EntityFrameworkCore;
using LibreriaColores.Modelos;
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
    
    public partial class FrmClientes : Form
    {


        public Cliente _Cliente { get; set; }


        public FrmClientes()
        {
            InitializeComponent();
            ActualizarGrilla();
            
        }
        private void ActualizarGrilla()
        {
            using Libreria db = new Libreria();
            var listaClientes = from Cliente in db.Clientes
                                join Clientes in db.Clientes
                                on Cliente.Id equals Clientes.Id
                                where Cliente.Nombre == Cliente.Nombre 
                                select new
                                {
                                    Id = Cliente.Id,
                                    Nombre = Cliente.Nombre,
                                    Apellido = Cliente.Apellido,
                                    DNI = Cliente.DNI,
                                    Teléfono = Cliente.Teléfono,
                                    Direccion = Cliente.Dirección,
                                    Localidad = Cliente.Localidad,
                                    Correo = Cliente.Correo,
                                   
                                };
            GridClientes.DataSource = listaClientes.ToList();
        }
        private void ActualizarGrillaFiltrada()
        {
            using Libreria db = new Libreria();
            var listaClientes = from Cliente in db.Clientes
                                join Clientes in db.Clientes
                                on Cliente.Id equals Clientes.Id
                                where Cliente.Nombre == Cliente.Nombre
                                select new
                                {
                                    Id = Cliente.Id,
                                    Nombre = Cliente.Nombre,
                                    Apellido = Cliente.Apellido,
                                    DNI = Cliente.DNI,
                                    Teléfono = Cliente.Teléfono,
                                    Direccion = Cliente.Dirección,
                                    Localidad = Cliente.Localidad,
                                    Correo = Cliente.Correo,

                                };
            GridClientes.DataSource = listaClientes.Where(s => s.Apellido.Contains(TxtBuscar.Text)
            || s.Nombre.Contains(TxtBuscar.Text) || s.DNI.ToString().Contains(TxtBuscar.Text)).ToList();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmEditarCliente frmEditarCliente = new FrmEditarCliente();
            frmEditarCliente.ShowDialog();
            ActualizarGrilla();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var idSeleccionado = Convert.ToInt32(GridClientes.CurrentRow.Cells[0].Value);
            var nombreSeleccionado = GridClientes.CurrentRow.Cells[1].Value.ToString() + " " + GridClientes.CurrentRow.Cells[2].Value.ToString();


            DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea borrar a {nombreSeleccionado}?", "Eliminar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (respuesta == DialogResult.Yes)
            {

                using Libreria db = new Libreria();


                Cliente cliente = db.Clientes.Find(idSeleccionado);

                db.Clientes.Remove(cliente);


                db.SaveChanges();
                ActualizarGrilla();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            var idSeleccionado = Convert.ToInt32(GridClientes.CurrentRow.Cells[0].Value);
            FrmEditarCliente frmEditarCliente = new FrmEditarCliente(idSeleccionado);
            frmEditarCliente.ShowDialog();
            ActualizarGrilla();

        }

        

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Length > 0)
                ActualizarGrillaFiltrada();
            else
                ActualizarGrilla();
        }

        private void GridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >=0)
            {
                _Cliente = new Cliente()
                {
                    Nombre = GridClientes.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Apellido = GridClientes.Rows[iRow].Cells["Apellido"].Value.ToString(),
                    DNI = Convert.ToInt32(GridClientes.CurrentRow.Cells["DNI"].Value),
                    Id = Convert.ToInt32(GridClientes.CurrentRow.Cells["Id"].Value)
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
