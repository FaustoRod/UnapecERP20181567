using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnapecERPApp.Services;
using UnapecErpData.Model;

namespace UnapecERPApp
{
    public partial class DocumentoCrearForm : Form
    {
        private int ProveedorId = 0;
        private DocumentoService _service = new DocumentoService();
        public DocumentoCrearForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {
                MessageBox.Show("Numero de Documento Obligatorio", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtNumero.Focus();
                return false;

            }

            if (!txtNumero.Text.Trim().Length.Equals(txtNumero.MaxLength))
            {
                MessageBox.Show("Numero de Documento Invalido", "Campo Invalido", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtNumero.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFactura.Text.Trim()))
            {
                MessageBox.Show("Numero de Factura Obligatorio", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtNumero.Focus();
                return false;
            }

            if (!txtFactura.Text.Trim().Length.Equals(txtFactura.MaxLength))
            {
                MessageBox.Show("Numero de Factura Invalido", "Campo Invalido", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtNumero.Focus();
                return false; ;

            }

            if (ProveedorId <= 0)
            {
                MessageBox.Show("Proveedor es Obligatorio", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (!txtFecha.MaskCompleted)
            {
                MessageBox.Show("Fecha es Obligatorio", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtFecha.Focus();
                return false;
            }

            DateTime date = new DateTime();
            if (!DateTime.TryParse(txtFecha.Text, out date))
            {
                MessageBox.Show("Fecha Invalida", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtFecha.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMonto.Text.Trim()))
            {
                MessageBox.Show("Monto es Obligatorio", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtFecha.Focus();
                return false;
            }

            decimal monto = 0;
            if (!Decimal.TryParse(txtMonto.Text.Trim(), out monto))
            {
                MessageBox.Show("Monto Invalida", "Campo Obligatorio", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                return false;
            }

            return true;
        }

        private async Task Save()
        {
            if (ValidateFields())
            {
                btnGuardar.Enabled = false;
                var result = await _service.Create(new Documento
                {
                    Monto = Decimal.Parse(txtMonto.Text.Trim()),
                    Numero = txtNumero.Text.Trim(),
                    NumeroFactura = txtFactura.Text.Trim(),
                    Fecha = DateTime.Parse(txtFecha.Text),
                    ProveedorId = ProveedorId
                    
                });

                MessageBox.Show(!result ? "Error al Crear Documento" : "Documento Creado con Exito", String.Empty,
                    MessageBoxButtons.OK, MessageBoxIcon.None);

                btnGuardar.Enabled = true;

                if (result)
                {
                    Clean();
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Clean();

        }

        private void Clean()
        {
            txtFecha.Text = "";
            txtNumero.Text = "";
            txtFactura.Text = "";
            txtMonto.Text = "";
            ProveedorId = 0;
            txtProvedor.Text = "";
            btnGuardar.Enabled = true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var provedorDialog = new SearchProvedorPopUp();
            if (provedorDialog.ShowDialog() == DialogResult.OK)
            {
                ProveedorId = provedorDialog._selectedProvedor.Id;
                txtProvedor.Text = provedorDialog._selectedProvedor.Nombre;
            }
            else
            {
                ProveedorId = 0;
                txtProvedor.Text = "";

            }
        }
    }
}
