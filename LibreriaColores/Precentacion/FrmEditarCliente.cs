using Microsoft.EntityFrameworkCore;
using LibreriaColores.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace LibreriaColores
{
    public partial class FrmEditarCliente : Form
    {
        private int idClienteModificado = 0;
        Libreria db = new Libreria();

        public FrmEditarCliente()
        {
            InitializeComponent();
            CargarComboLocalidades();
            BtnGuardar.Enabled = false;
        }
        private void CargarComboLocalidades(int? localidadId = 0)
        {

            CboLocalidad.DataSource = db.Localidades.ToList();
            CboLocalidad.DisplayMember = "Nombre";
            CboLocalidad.ValueMember = "Id";
            CboLocalidad.SelectedValue = 1;
            

            AutoCompleteStringCollection autoCompletado = new AutoCompleteStringCollection();
            foreach (Localidad item in db.Localidades.ToList())
            {
                autoCompletado.Add(item.Nombre.ToString());
            }
            CboLocalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboLocalidad.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboLocalidad.AutoCompleteCustomSource = autoCompletado;
        }
        public FrmEditarCliente(int idSeleccionado)
        {
            InitializeComponent();
            this.idClienteModificado = idSeleccionado;
            using Libreria db = new Libreria();
            Cliente clientes = db.Clientes.Find(idSeleccionado);
            TxtApellido.Text = clientes.Apellido;
            TxtNombre.Text = clientes.Nombre;
            TxtTelefono.Text = clientes.Teléfono;
            TxtDireccion.Text = clientes.Dirección;
            NudDNI.Value = clientes.DNI;
            CargarComboLocalidades(clientes.LocalidadId);
            TxtCorreo.Text = clientes.Correo;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Cliente clientes = new Cliente();
            clientes.Nombre = TxtNombre.Text;
            clientes.Apellido = TxtApellido.Text;
            clientes.DNI = Convert.ToInt32(NudDNI.Value);
            clientes.Teléfono = TxtTelefono.Text;
            clientes.Dirección = TxtDireccion.Text;
            clientes.Correo = TxtCorreo.Text;
            clientes.LocalidadId = (int)CboLocalidad.SelectedValue;
            clientes.Localidad = CboLocalidad.Text;

            using Libreria db = new Libreria();
            if (this.idClienteModificado == 0)
            {
                db.Clientes.Add(clientes);
            }
            else
            {
                clientes.Id = this.idClienteModificado;
                db.Entry(clientes).State = EntityState.Modified;

            }
            db.SaveChanges();
            BtnGuardar.Enabled = false;
            Close();
        }

       

        private void TxtCorreo_TextChanged(object sender, EventArgs e)
        {
            BtnGuardar.Enabled = true;
        }
    }
}
