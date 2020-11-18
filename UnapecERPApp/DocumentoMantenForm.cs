using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnapecERPApp.Services;
using UnapecErpData.Dto;
using UnapecErpData.Model;
using TipoPersona = UnapecErpData.Enums.TipoPersona;
using System.Linq;
using EstadoDocumento = UnapecErpData.Enums.EstadoDocumento;

namespace UnapecERPApp
{
    public partial class DocumentoMantenForm : Form
    {
        private DocumentoService _documentoService = new DocumentoService();
        private Documento _selectedDocumento;
        public int ProvedorId { get; set; }

        public DocumentoMantenForm()
        {
            InitializeComponent();
            LoadList();
            cbEstadoDocumento.DataSource = Enum.GetValues(typeof(EstadoDocumento));
        }
        
        private async void button1_Click_1(object sender, EventArgs e)
        {
            var dialog = new DocumentoCrearForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        
        private void CleanForm()
        {
            _selectedDocumento = null;
            ProvedorId = 0;
            txtProvedor.Text = "";
            txtFactura.Text = txtNumero.Text = "";
            btnPagar.Enabled = true;
        }
        private async void LoadList()
        {
            var list = await _documentoService.GetAll();
            if (list != null && list.Any())
            {
                dtProveedor.DataSource = list;
            }
        }

        private void dtConceptoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedDocumento = new Documento()
                {
                    Id = (int)dtProveedor.Rows[e.RowIndex].Cells["Id"].Value,
                    EstadoDocumentoId = (int)dtProveedor.Rows[e.RowIndex].Cells["EstadoDocumentoId"].Value,
                    ProveedorId = (int)dtProveedor.Rows[e.RowIndex].Cells["ProveedorId"].Value,
                    Monto = (decimal)dtProveedor.Rows[e.RowIndex].Cells["Monto"].Value,
                    Numero = dtProveedor.Rows[e.RowIndex].Cells["Numero"].Value.ToString(),
                    NumeroFactura = dtProveedor.Rows[e.RowIndex].Cells["NumeroFactura"].Value.ToString()
                };


            }
            else
            {
                _selectedDocumento = null;
            }

            btnPagar.Enabled = _selectedDocumento != null && _selectedDocumento.EstadoDocumentoId.Equals((int)EstadoDocumento.Pendiente);
            btnLimpiar.Enabled = _selectedDocumento != null;
            SetSelectedInfo();
        }

        private void SetSelectedInfo()
        {
            //txtNombre.Text = _selectedDocumento != null ? _selectedDocumento.Nombre : "";
            //cbTipoPersona.SelectedItem = _selectedDocumento != null ? (TipoPersona)_selectedDocumento.TipoPersonaId : TipoPersona.Fisica;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanForm();
        }
        
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var list = await _documentoService.Search(new DocumentSearchDto
            {
                ProveedorId = ProvedorId,
                Numero = txtNumero.Text.Trim(),
                NumeroFactura = txtFactura.Text.Trim(),
                Monto = 0,
                Fecha = DateTime.Now,
                //FechaCreacion = DateTime.Now,
                //FechaModificacion = DateTime.Now,
                EstadoDocumentoId = (int)cbEstadoDocumento.SelectedValue
                
            });
            dtProveedor.DataSource = list;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await PayDocumento();
        }

        private async Task PayDocumento()
        {
            if (_selectedDocumento == null)
            {
                MessageBox.Show("Seleccione Documento a Pagar", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;

            }

            var result = await _documentoService.Pagar(_selectedDocumento.Id);
            MessageBox.Show(result? "Documento a Cambiado Estado a Pago":"", "Fallo al Actualizar Estado", MessageBoxButtons.OK,
                result? MessageBoxIcon.None:MessageBoxIcon.Exclamation);

            if (result)
            {
                LoadList();
            }
        }
        private void SearchDocumento(object sender, EventArgs e)
        {
            var proveedor = new SearchProvedorPopUp();
            if (proveedor.DialogResult == DialogResult.OK)
            {
                ProvedorId = proveedor._selectedProvedor.Id;
                txtNumero.Text = proveedor._selectedProvedor.Nombre;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var provedorDialog = new SearchProvedorPopUp();
            if (provedorDialog.ShowDialog() == DialogResult.OK)
            {
                ProvedorId = provedorDialog._selectedProvedor.Id;
                txtProvedor.Text = provedorDialog._selectedProvedor.Nombre;
            }
            else
            {
                ProvedorId = 0;
                txtProvedor.Text = "";

            }
        }

    }
}
