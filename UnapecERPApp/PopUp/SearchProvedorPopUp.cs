using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnapecERPApp.Services;
using UnapecErpData.Dto;
using UnapecErpData.Model;
using TipoPersona = UnapecErpData.Enums.TipoPersona;

namespace UnapecERPApp
{
    public partial class SearchProvedorPopUp: Form
    {
        public Proveedor _selectedProvedor;
        private ProveedorService _proveedorService = new ProveedorService();
        public SearchProvedorPopUp()
        {
            InitializeComponent();
            LoadList();
            cbTipoPersona.DataSource = Enum.GetValues(typeof(TipoPersona));
        }
        
        private async void LoadList()
        {
            var list = await _proveedorService.GetAll();
            if (list != null && list.Any())
            {
                var newList = new List<ProveedorDto>();
                foreach (var proveedor in list)
                {
                   newList.Add(new ProveedorDto
                   {
                       Documento = proveedor.Documento,
                       Balance = proveedor.Balance,
                       Id = proveedor.Id,
                       TipoPersonaId = proveedor.TipoPersonaId,
                       TipoNombre = proveedor.TipoPersona?.Descripcion,
                       Nombre = proveedor.Nombre
                       
                   });     
                }

                dtProveedor.DataSource = newList;
            }
        }

        private void dtConceptoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedProvedor = new Proveedor()
                {
                    Id = (int)dtProveedor.Rows[e.RowIndex].Cells["Id"].Value,
                    Nombre = dtProveedor.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString(),
                    TipoPersonaId = (int)dtProveedor.Rows[e.RowIndex].Cells["TipoPersonaId"].Value,
                    Balance = (decimal)dtProveedor.Rows[e.RowIndex].Cells["Balance"].Value,
                    Documento = dtProveedor.Rows[e.RowIndex].Cells["Documento"].Value?.ToString(),
                    
                    Activo = true
                };

            }
            else
            {
                _selectedProvedor = null;
            }

            SetSelectedInfo();
        }

        private void SetSelectedInfo()
        {
            txtNombre.Text = _selectedProvedor != null ? _selectedProvedor.Nombre : "";
            txtDocumento.Text = _selectedProvedor != null ? _selectedProvedor.Documento : "";
            cbTipoPersona.SelectedItem = _selectedProvedor != null ? (TipoPersona)_selectedProvedor.TipoPersonaId : TipoPersona.Fisica;
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await SearchProveedor();
        }

        private async Task SearchProveedor()
        {
            var list = await _proveedorService.SearchAll(new ProvedorSearchDto
            {
                Documento = txtDocumento.Text.Trim(),
                TipoId = (int) cbTipoPersona.SelectedValue,
                Nombre = txtNombre.Text
            });
            if (list != null && list.Any())
            {
                var newList = new List<ProveedorDto>();
                foreach (var proveedor in list)
                {
                    newList.Add(new ProveedorDto
                    {
                        Documento = proveedor.Documento,
                        Balance = proveedor.Balance,
                        Id = proveedor.Id,
                        TipoPersonaId = proveedor.TipoPersonaId,
                        TipoNombre = proveedor.TipoPersona?.Descripcion,
                        Nombre = proveedor.Nombre

                    });
                }

                dtProveedor.DataSource = newList;
            }
        }

        private void dtProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
