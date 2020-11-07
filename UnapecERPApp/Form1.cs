using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnapecERPApp.Services;
using UnapecErpData.Model;

namespace UnapecERPApp
{
    public partial class Form1 : Form
    {
        private bool IsCreate;
        private bool IsEdit;
        private ConceptoPagoService _conceptoPagoService = new ConceptoPagoService();
        private ConceptoPago _selectedConcepto;
        public Form1()
        {
            InitializeComponent();
            LoadList();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await new ConceptoPagoService().Delete(2);
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
            else
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
            txtDescripcion.ReadOnly = !IsCreate;
            txtDescripcion.Text = "";
            btnCrear.Text = IsCreate ? "Guardar" : "Crear";
            btnLimpiar.Enabled = IsCreate;
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
                if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Descripcion Obligatoria", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return;
                }

                btnCrear.Enabled = false;
                var result = await _conceptoPagoService.Create(new ConceptoPago
                {
                    Descripcion = txtDescripcion.Text
                });
                if (result)
                {
                    MessageBox.Show("Concepto de Pago Creado con Exito", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
                    CreateMode(false);
                }
                else
                {
                    MessageBox.Show("Erro al Crear Concepto de Pago", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);

                }
                btnCrear.Enabled = true;
            }

            await LoadList();
        }

        private async Task Edit()
        {
            if (IsEdit)
            {
                if (_selectedConcepto == null)
                {
                    MessageBox.Show("Seleccion Concepto de Pago a Modificar", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Descripcion Obligatoria", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return;
                }

                if (txtDescripcion.Text.Equals(_selectedConcepto.Descripcion))
                {
                    MessageBox.Show("Nueva Descripcion  Debe ser Distinta a la Anterior", String.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return;
                }

                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                var result = await _conceptoPagoService.Update(new ConceptoPago
                {
                    Descripcion = txtDescripcion.Text,
                    Id = _selectedConcepto.Id
                });
                if (result)
                {
                    MessageBox.Show("Concepto de Pago Modificado con Exito", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
                    EditMode(false);
                }
                else
                {
                    MessageBox.Show("Erro al Crear Concepto de Pago", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);

                }

                btnCrear.Enabled = true;
                btnModificar.Enabled = true;
            }
        }

        private async Task LoadList()
        {
            dtConceptoPago.DataSource = await _conceptoPagoService.GetAll();
        }

        private void dtConceptoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedConcepto = new ConceptoPago
                {
                    Id = (int)dtConceptoPago.Rows[e.RowIndex].Cells["Id"].Value,
                    Descripcion = dtConceptoPago.Rows[e.RowIndex].Cells["Descripcion"].Value?.ToString(),
                    Activo = true
                };

            }
            else
            {
                _selectedConcepto = null;
            }

            btnDelete.Enabled = _selectedConcepto != null;
            btnLimpiar.Enabled = _selectedConcepto != null;
            SetSelectedInfo();
        }

        private void SetSelectedInfo()
        {
            txtDescripcion.Text = _selectedConcepto != null ? _selectedConcepto.Descripcion : "";
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
            txtDescripcion.ReadOnly = !isEditMode;
            txtDescripcion.Text = "";
            btnCrear.Text = isEditMode ? "Guardar" : "Crear";
            btnLimpiar.Enabled = isEditMode;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private async void Delete()
        {
            if (_selectedConcepto != null)
            {
                if (MessageBox.Show("Desea Eliminar Este Concepto de Pago?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnDelete.Enabled = false;
                    var result = await _conceptoPagoService.Delete(_selectedConcepto.Id);
                    MessageBox.Show(result ? "Concept de Pago Eliminado con Exito" : "Fallo al Eliminar Concepto de Pago", String.Empty, MessageBoxButtons.OK,
                        result ? MessageBoxIcon.None: MessageBoxIcon.Error);

                    if (result)
                    {
                        await LoadList();
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
    }
}
