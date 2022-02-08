using LibreriaColores.Formularios;
using LibreriaColores.Precentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaColores
{
    public partial class FrmPaginaPrincipal : Form
    {
        public FrmPaginaPrincipal()
        {
            InitializeComponent();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogo_Click(object sender, EventArgs e)
        {
            FrmNosotros frmNosotros = new FrmNosotros();
            frmNosotros.ShowDialog();
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario frmInventario = new FrmInventario();
            frmInventario.ShowDialog();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();
            frmVentas.ShowDialog();
        }

       

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmEditarCliente frmEditarCliente = new FrmEditarCliente();
            frmEditarCliente.ShowDialog();
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmEditarInventario frmEditarInventario = new FrmEditarInventario();
            frmEditarInventario.ShowDialog();

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

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();
            frmVentas.ShowDialog();
        }

        private void agregarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditarCliente frmEditarCliente = new FrmEditarCliente();
            frmEditarCliente.ShowDialog();
        }

        private void agregarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditarInventario frmEditarInventario = new FrmEditarInventario();
            frmEditarInventario.ShowDialog();
        }

        private void detalleDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerVentas frmVerVentas = new FrmVerVentas();
            frmVerVentas.ShowDialog();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalidades frmLocalidades = new FrmLocalidades();
            frmLocalidades.ShowDialog();
        }
    }
}
