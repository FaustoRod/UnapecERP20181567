namespace UnapecERPApp
{
    partial class DocumentoMantenForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtProveedor = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtProvedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEstadoDocumento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProveedorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDocumentoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedorDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtProveedor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtProveedor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1579, 615);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtProveedor
            // 
            this.dtProveedor.AllowUserToAddRows = false;
            this.dtProveedor.AllowUserToDeleteRows = false;
            this.dtProveedor.AutoGenerateColumns = false;
            this.dtProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProveedorId,
            this.Numero,
            this.NumeroFactura,
            this.Fecha,
            this.Monto,
            this.EstadoDocumentoId,
            this.proveedorDataGridViewTextBoxColumn,
            this.estadoDocumentoDataGridViewTextBoxColumn,
            this.Id,
            this.FechaCreacion,
            this.FechaModificacion});
            this.dtProveedor.DataSource = this.documentoBindingSource;
            this.dtProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtProveedor.Location = new System.Drawing.Point(3, 218);
            this.dtProveedor.Name = "dtProveedor";
            this.dtProveedor.ReadOnly = true;
            this.dtProveedor.RowHeadersWidth = 51;
            this.dtProveedor.RowTemplate.Height = 24;
            this.dtProveedor.Size = new System.Drawing.Size(1573, 394);
            this.dtProveedor.TabIndex = 0;
            this.dtProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtConceptoPago_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPagar);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtProvedor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.txtFactura);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbEstadoDocumento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCrear);
            this.panel1.Controls.Add(this.txtNumero);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1573, 209);
            this.panel1.TabIndex = 1;
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(1192, 150);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(120, 46);
            this.btnPagar.TabIndex = 20;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::UnapecERPApp.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(997, 86);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 36);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtProvedor
            // 
            this.txtProvedor.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvedor.Location = new System.Drawing.Point(620, 86);
            this.txtProvedor.Name = "txtProvedor";
            this.txtProvedor.ReadOnly = true;
            this.txtProvedor.Size = new System.Drawing.Size(353, 36);
            this.txtProvedor.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(485, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 29);
            this.label6.TabIndex = 17;
            this.label6.Text = "Proveedor";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.maskedTextBox1.Location = new System.Drawing.Point(620, 160);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(353, 36);
            this.maskedTextBox1.TabIndex = 16;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.Visible = false;
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.txtFecha.Location = new System.Drawing.Point(143, 160);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(295, 36);
            this.txtFecha.TabIndex = 15;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            this.txtFecha.Visible = false;
            // 
            // txtFactura
            // 
            this.txtFactura.BackColor = System.Drawing.SystemColors.Window;
            this.txtFactura.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.Location = new System.Drawing.Point(620, 26);
            this.txtFactura.MaxLength = 8;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(353, 36);
            this.txtFactura.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(485, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "No. Factura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desde";
            this.label4.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(1066, 150);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 46);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(531, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hasta";
            this.label3.Visible = false;
            // 
            // cbEstadoDocumento
            // 
            this.cbEstadoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoDocumento.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.cbEstadoDocumento.FormattingEnabled = true;
            this.cbEstadoDocumento.Location = new System.Drawing.Point(143, 91);
            this.cbEstadoDocumento.Name = "cbEstadoDocumento";
            this.cbEstadoDocumento.Size = new System.Drawing.Size(295, 36);
            this.cbEstadoDocumento.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Estado";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(1318, 150);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 46);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(1444, 150);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(120, 46);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumero.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(143, 29);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(295, 36);
            this.txtNumero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // ProveedorId
            // 
            this.ProveedorId.DataPropertyName = "ProveedorId";
            this.ProveedorId.HeaderText = "ProveedorId";
            this.ProveedorId.MinimumWidth = 6;
            this.ProveedorId.Name = "ProveedorId";
            this.ProveedorId.ReadOnly = true;
            this.ProveedorId.Visible = false;
            this.ProveedorId.Width = 125;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.MinimumWidth = 6;
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // NumeroFactura
            // 
            this.NumeroFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroFactura.DataPropertyName = "NumeroFactura";
            this.NumeroFactura.HeaderText = "NumeroFactura";
            this.NumeroFactura.MinimumWidth = 6;
            this.NumeroFactura.Name = "NumeroFactura";
            this.NumeroFactura.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 6;
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // EstadoDocumentoId
            // 
            this.EstadoDocumentoId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EstadoDocumentoId.DataPropertyName = "EstadoDocumentoId";
            this.EstadoDocumentoId.HeaderText = "EstadoDocumentoId";
            this.EstadoDocumentoId.MinimumWidth = 6;
            this.EstadoDocumentoId.Name = "EstadoDocumentoId";
            this.EstadoDocumentoId.ReadOnly = true;
            this.EstadoDocumentoId.Visible = false;
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            this.proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            this.proveedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.proveedorDataGridViewTextBoxColumn.Visible = false;
            this.proveedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // estadoDocumentoDataGridViewTextBoxColumn
            // 
            this.estadoDocumentoDataGridViewTextBoxColumn.DataPropertyName = "EstadoDocumento";
            this.estadoDocumentoDataGridViewTextBoxColumn.HeaderText = "EstadoDocumento";
            this.estadoDocumentoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.estadoDocumentoDataGridViewTextBoxColumn.Name = "estadoDocumentoDataGridViewTextBoxColumn";
            this.estadoDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDocumentoDataGridViewTextBoxColumn.Visible = false;
            this.estadoDocumentoDataGridViewTextBoxColumn.Width = 125;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            this.FechaCreacion.HeaderText = "FechaCreacion";
            this.FechaCreacion.MinimumWidth = 6;
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Visible = false;
            this.FechaCreacion.Width = 125;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.HeaderText = "FechaModificacion";
            this.FechaModificacion.MinimumWidth = 6;
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            this.FechaModificacion.Visible = false;
            this.FechaModificacion.Width = 125;
            // 
            // documentoBindingSource
            // 
            this.documentoBindingSource.DataSource = typeof(UnapecErpData.Model.Documento);
            // 
            // proveedorDtoBindingSource
            // 
            this.proveedorDtoBindingSource.DataSource = typeof(UnapecErpData.Dto.ProveedorDto);
            // 
            // DocumentoMantenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentoMantenForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Concepto de Pago";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtProveedor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtProveedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEstadoDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource proveedorDtoBindingSource;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtProvedor;
        private System.Windows.Forms.BindingSource documentoBindingSource;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProveedorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDocumentoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
    }
}

