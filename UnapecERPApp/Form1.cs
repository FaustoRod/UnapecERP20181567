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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IsCreate)
            {
                Save();
            }
            else
            {
                CreateMode(true);
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

                var result = await _conceptoPagoService.Create(new ConceptoPago
                {
                    Descripcion = txtDescripcion.Text
                });
                if (result)
                {
                    MessageBox.Show("Concepto de Pago Creado con Exito",String.Empty,MessageBoxButtons.OK,MessageBoxIcon.None);
                    CreateMode(false);
                }
                else
                {
                    MessageBox.Show("Erro al Crear Concepto de Pago", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);

                }

            }

            await LoadList();
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
                };

            }
            else
            {
                _selectedConcepto = null;
            }

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
    }
}
