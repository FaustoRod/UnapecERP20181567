using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnapecERPApp.Services;
using UnapecErpData.Dto;
using UnapecErpData.Model;
using TipoPersona = UnapecErpData.Enums.TipoPersona;
using System.Linq;

namespace UnapecERPApp
{
    public partial class ProveedorMantenForm : Form
    {
        private bool IsCreate;
        private bool IsEdit;
        private ProveedorService _proveedorPagoService = new ProveedorService();
        private ProveedorDto _selectedProvedor;

        public ProveedorMantenForm()
        {
            InitializeComponent();
            LoadList();
            cbTipoPersona.DataSource = Enum.GetValues(typeof(TipoPersona));
        }
        
        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (IsCreate)
            {
                Save();
            }

            if (IsEdit)
            {
                await Edit();
            }
            else if(!IsCreate && !IsEdit)
            {
                CreateMode(true);

            }

        }

        private async Task ChangeEditCreate()
        {
            if (IsCreate)
            {
                Save();
            }
            else if (IsEdit)
            {
                await Edit();
            }
        }
        private void CreateMode(bool isCreateMode)
        {
            IsCreate = isCreateMode;
            txtDocumento.Text = txtNombre.Text = txtBalance.Text = "";
            btnCrear.Text = IsCreate ? "Guardar" : "Crear";
            btnLimpiar.Enabled = IsCreate;
            btnModificar.Enabled  = btnBuscar.Enabled = !IsCreate;
            dtProveedor.Enabled = !isCreateMode;
        }

        private void CleanForm()
        {
            CreateMode(false); 
            EditMode(false);
        }

        private async void Save()
        {
            if (IsCreate)
            {
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Nombre Obligatorio", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtDocumento.Text.Trim()))
                {
                    MessageBox.Show("Documento Obligatorio", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDocumento.Focus();
                    return;
                }

                if (!txtDocumento.Text.Trim().Length.Equals(11) && !txtDocumento.Text.Trim().Length.Equals(9))
                {
                    MessageBox.Show("Numero de Documento Invalido", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDocumento.Focus();
                    return;
                }

                if (txtDocumento.Text.Trim().Length.Equals(11) && !ValidarCedula(txtDocumento.Text.Trim()))
                {
                    MessageBox.Show("Numero de Cedula Invalida", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDocumento.Focus();
                    return;
                }

                btnCrear.Enabled = false;
                var result = await _proveedorPagoService.Create(new Proveedor()
                {
                    Nombre = txtNombre.Text,
                    Documento = txtDocumento.Text,
                    TipoPersonaId = cbTipoPersona.SelectedValue != null ? (int)cbTipoPersona.SelectedValue : 0,
                    Activo = true
                });
                if (result)
                {
                    MessageBox.Show("Provedor Creado con Exito", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
                    CreateMode(false);
                }
                else
                {
                    MessageBox.Show("Erro al Crear Provedor", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);

                }
                btnCrear.Enabled = true;
            }
            CleanForm();
            LoadList();
        }

        private async Task Edit()
        {
            if (IsEdit)
            {
                if (_selectedProvedor == null)
                {
                    MessageBox.Show("Seleccion Provedor a Modificar", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Descripcion Obligatoria", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtDocumento.Text.Trim()))
                {
                    MessageBox.Show("Numero de Documento Obligatoria", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDocumento.Focus();
                    return;
                }
                
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                var result = await _proveedorPagoService.Update(new Proveedor()
                {
                    Nombre = txtNombre.Text,
                    Id = _selectedProvedor.Id,
                    TipoPersonaId = (int)cbTipoPersona.SelectedValue,
                    Documento = txtDocumento.Text.Trim(),
                    Activo = true,
                    Balance = _selectedProvedor.Balance
                });
                if (result)
                {
                    MessageBox.Show("Provedor Modificado con Exito", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
                    EditMode(false);
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Erro al Crear Provedor", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);

                }

                btnCrear.Enabled = true;
                btnModificar.Enabled = true;
            }
        }

        private async void LoadList()
        {
            var list = await _proveedorPagoService.GetAll();
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
                _selectedProvedor = new ProveedorDto()
                {
                    Id = (int)dtProveedor.Rows[e.RowIndex].Cells["Id"].Value,
                    Nombre = dtProveedor.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString(),
                    TipoPersonaId = (int)dtProveedor.Rows[e.RowIndex].Cells["TipoPersonaId"].Value,
                    Balance = (decimal)dtProveedor.Rows[e.RowIndex].Cells["Balance"].Value,
                    TipoNombre = dtProveedor.Rows[e.RowIndex].Cells["TipoNombre"].Value?.ToString(),
                    Documento = dtProveedor.Rows[e.RowIndex].Cells["Documento"].Value?.ToString(),
                    
                    Activo = true
                };

            }
            else
            {
                _selectedProvedor = null;
            }

            btnDelete.Enabled = _selectedProvedor != null;
            btnLimpiar.Enabled = _selectedProvedor != null;
            SetSelectedInfo();
        }

        private void SetSelectedInfo()
        {
            txtNombre.Text = _selectedProvedor != null ? _selectedProvedor.Nombre : "";
            txtDocumento.Text = _selectedProvedor != null ? _selectedProvedor.Documento : "";
            txtBalance.Text = _selectedProvedor != null ? _selectedProvedor.Balance.ToString("N") : "";
            cbTipoPersona.SelectedItem = _selectedProvedor != null ? (TipoPersona)_selectedProvedor.TipoPersonaId : TipoPersona.Fisica;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ChangeEditCreate();
            EditMode(true);
        }

        private void  EditMode(bool isEditMode)
        {
            IsEdit = isEditMode;
            txtNombre.Text =txtDocumento.Text = txtBalance.Text ="";
            btnCrear.Text = isEditMode ? "Guardar" : "Crear";
            btnLimpiar.Enabled = isEditMode;
            btnBuscar.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private async void Delete()
        {
            if (_selectedProvedor != null)
            {
                if (MessageBox.Show("Desea Eliminar Este Proveedor?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnDelete.Enabled = false;
                    var result = await _proveedorPagoService.Delete(_selectedProvedor.Id);
                    MessageBox.Show(result ? "Proveedor Eliminado con Exito" : "Fallo al Eliminar Proveedor", String.Empty, MessageBoxButtons.OK,
                        result ? MessageBoxIcon.None: MessageBoxIcon.Error);

                    if (result)
                    {
                        LoadList();
                        CleanForm();
                    }
                    btnDelete.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Seleccione Concepto a Eliminar");
            }

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool ValidarCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            if (pLongCed < 11 || pLongCed > 11)
                return false;
            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }
            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void SearchProveedor()
        {

        }
    }
}
