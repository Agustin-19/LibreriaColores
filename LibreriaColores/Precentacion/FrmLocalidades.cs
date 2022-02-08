using LibreriaColores.Modelos;
using Microsoft.EntityFrameworkCore;
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
    public partial class FrmLocalidades : Form
    {
        private int idClienteModificado = 0;
        public FrmLocalidades()
        {
            InitializeComponent();
            ActualizarGrilla();
            BtnAgregar.Enabled = false;
        }
        private void ActualizarGrilla()
        {
            using Libreria db = new Libreria();
            GridLocalidades.DataSource = db.Localidades.ToList();
        }
        private void ActualizarGrillaFiltrada()
        {
            using Libreria db = new Libreria();
            GridLocalidades.DataSource = db.Localidades.Where(s => s.Nombre.Contains(TxtBuscar.Text)).ToList();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Length > 0)
                ActualizarGrillaFiltrada();
            else
                ActualizarGrilla();
        }

        
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           Localidad localidad = new Localidad();
           localidad.Nombre = TxtNombre.Text;
            using Libreria db = new Libreria();

            if (this.idClienteModificado == 0)
            {
                db.Localidades.Add(localidad);
            }
            else
            {
                localidad.Id = this.idClienteModificado;
                db.Entry(localidad).State = EntityState.Modified;

            }
            db.SaveChanges();
            ActualizarGrilla();
            TxtNombre.Text = string.Empty;
            BtnAgregar.Enabled = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            BtnAgregar.Enabled = true;
        }
    }
}
