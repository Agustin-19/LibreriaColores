
namespace LibreriaColores.Precentacion
{
    partial class FrmVerVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerVentas));
            this.GridVentas = new System.Windows.Forms.DataGridView();
            this.GridDetalle = new System.Windows.Forms.DataGridView();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblDetalle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnImprimirT = new System.Windows.Forms.Button();
            this.BtnUltimaVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // GridVentas
            // 
            this.GridVentas.AllowUserToOrderColumns = true;
            this.GridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridVentas.Location = new System.Drawing.Point(12, 172);
            this.GridVentas.Name = "GridVentas";
            this.GridVentas.RowTemplate.Height = 25;
            this.GridVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridVentas.Size = new System.Drawing.Size(872, 150);
            this.GridVentas.TabIndex = 0;
            this.GridVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVentas_CellContentClick);
            this.GridVentas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVentas_CellEnter);
            this.GridVentas.Click += new System.EventHandler(this.GridVentas_Click);
            // 
            // GridDetalle
            // 
            this.GridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDetalle.Location = new System.Drawing.Point(12, 368);
            this.GridDetalle.Name = "GridDetalle";
            this.GridDetalle.RowTemplate.Height = 25;
            this.GridDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDetalle.Size = new System.Drawing.Size(872, 101);
            this.GridDetalle.TabIndex = 1;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtBuscar.Location = new System.Drawing.Point(394, 137);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(100, 32);
            this.TxtBuscar.TabIndex = 2;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtnSalir.BackgroundImage = global::LibreriaColores.Properties.Resources.apagar;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.ForeColor = System.Drawing.Color.Black;
            this.BtnSalir.Location = new System.Drawing.Point(820, 9);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 67);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblDetalle
            // 
            this.LblDetalle.AutoSize = true;
            this.LblDetalle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDetalle.Location = new System.Drawing.Point(12, 340);
            this.LblDetalle.Name = "LblDetalle";
            this.LblDetalle.Size = new System.Drawing.Size(168, 25);
            this.LblDetalle.TabIndex = 6;
            this.LblDetalle.Text = "Detalle de la venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buscar venta por Nombre o Dni del Cliente:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.LightGreen;
            this.LblTitulo.Font = new System.Drawing.Font("Segoe Script", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTitulo.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulo.Location = new System.Drawing.Point(39, 9);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(519, 58);
            this.LblTitulo.TabIndex = 13;
            this.LblTitulo.Text = "Libreria Mil Colores";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.BackColor = System.Drawing.Color.LightGreen;
            this.BtnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.LightGreen;
            this.BtnImprimir.FlatAppearance.BorderSize = 0;
            this.BtnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnImprimir.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnImprimir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Image")));
            this.BtnImprimir.Location = new System.Drawing.Point(661, 93);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(76, 76);
            this.BtnImprimir.TabIndex = 14;
            this.BtnImprimir.Text = "Boleta";
            this.BtnImprimir.UseVisualStyleBackColor = false;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnImprimirT
            // 
            this.BtnImprimirT.BackColor = System.Drawing.Color.LightGreen;
            this.BtnImprimirT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnImprimirT.FlatAppearance.BorderColor = System.Drawing.Color.LightGreen;
            this.BtnImprimirT.FlatAppearance.BorderSize = 0;
            this.BtnImprimirT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnImprimirT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnImprimirT.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnImprimirT.ForeColor = System.Drawing.Color.Black;
            this.BtnImprimirT.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimirT.Image")));
            this.BtnImprimirT.Location = new System.Drawing.Point(743, 93);
            this.BtnImprimirT.Name = "BtnImprimirT";
            this.BtnImprimirT.Size = new System.Drawing.Size(76, 76);
            this.BtnImprimirT.TabIndex = 15;
            this.BtnImprimirT.Text = "Ticket";
            this.BtnImprimirT.UseVisualStyleBackColor = false;
            this.BtnImprimirT.Click += new System.EventHandler(this.BtnImprimirT_Click);
            // 
            // BtnUltimaVenta
            // 
            this.BtnUltimaVenta.BackColor = System.Drawing.Color.Teal;
            this.BtnUltimaVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnUltimaVenta.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.BtnUltimaVenta.FlatAppearance.BorderSize = 0;
            this.BtnUltimaVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnUltimaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnUltimaVenta.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnUltimaVenta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnUltimaVenta.Location = new System.Drawing.Point(500, 109);
            this.BtnUltimaVenta.Name = "BtnUltimaVenta";
            this.BtnUltimaVenta.Size = new System.Drawing.Size(83, 60);
            this.BtnUltimaVenta.TabIndex = 16;
            this.BtnUltimaVenta.Text = "Ultima \r\nVenta";
            this.BtnUltimaVenta.UseVisualStyleBackColor = false;
            this.BtnUltimaVenta.Click += new System.EventHandler(this.BtnUltimaVenta_Click);
            // 
            // FrmVerVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(898, 481);
            this.Controls.Add(this.BtnUltimaVenta);
            this.Controls.Add(this.BtnImprimirT);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblDetalle);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.GridDetalle);
            this.Controls.Add(this.GridVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVerVentas";
            this.Text = "FrmVerVentas";
            ((System.ComponentModel.ISupportInitialize)(this.GridVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridVentas;
        private System.Windows.Forms.DataGridView GridDetalle;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblDetalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnImprimirT;
        private System.Windows.Forms.Button BtnUltimaVenta;
    }
}