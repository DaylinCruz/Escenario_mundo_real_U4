namespace Escenario_mundo_real_U4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void rdoEmpezarCloro_Click(object sender, EventArgs e)
        {

        }

        private void rdoEmpezarCloro_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el RadioButton de "Empezar" está seleccionado
            if (rdoEmpezarCloro.Checked)
            {
                // Verificar si el ComboBox tiene un valor seleccionado
                if (cmbCloro.SelectedItem != null)
                {
                    try
                    {
                        // Convertir el valor seleccionado del ComboBox a entero
                        int moneda = Convert.ToInt32(cmbCloro.SelectedItem);
                        int tiempoCarga = ObtenerTiempoCarga(moneda);

                        if (tiempoCarga > 0)
                        {
                            // Iniciar la barra de progreso
                            CargarBarraProgreso(moneda);
                        }
                        else
                        {
                            MessageBox.Show("Selecciona un valor válido de moneda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecciona un valor de moneda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int ObtenerTiempoCarga(int moneda)
        {
            // Asignar el tiempo de carga en milisegundos según el valor de la moneda
            switch (moneda)
            {
                case 2:
                    return 2000; // 2 segundos
                case 5:
                    return 5000; // 5 segundos
                case 10:
                    return 10000; // 10 segundos
                default:
                    return 0; // Si no es válido, devolver 0
            }
        }

        private async Task CargarBarraProgreso(int tiempoCarga)
        {
            if (pbarCloro != null) // Verificar que la barra de progreso no sea nula
            {
                pbarCloro.Value = 0;
                int intervalo = tiempoCarga / 100; // Dividir el tiempo total en 100 pasos
                for (int i = 0; i <= 100; i++)
                {
                    pbarCloro.Value = i; // Actualizar el progreso
                }
            }
            else
            {
                MessageBox.Show("El control de la barra de progreso no está configurado correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoPararCloro_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPararCloro.Checked)
            {
                pbarCloro.Value = 0; // Reiniciar la barra
            }
        }

        private void pbarCloro_Click(object sender, EventArgs e)
        {

        }

        private void cmbCloro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    
