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
    public partial class FrmComprador : Form
    {
        public Cliente _Cliente { get; set; }
        public FrmComprador()
        {
            InitializeComponent();
        }
        private void ActualizarGrilla()
        {
            using Libreria db = new Libreria();
            GridClientes.DataSource = db.Clientes.ToList();
        }

        private void ActualizarGrillaFiltrada()
        {
            using Libreria db = new Libreria();
            GridClientes.DataSource = db.Clientes.Where(s => s.Apellido.Contains(TxtBuscar.Text)
            || s.Nombre.Contains(TxtBuscar.Text) || s.DNI.ToString().Contains(TxtBuscar.Text)).ToList();
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
            if (iRow >= 0 && iColum >= 0)
            {
                _Cliente = new Cliente()
                {
                    Nombre = GridClientes.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Apellido = GridClientes.Rows[iRow].Cells["Apellido"].Value.ToString(),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
