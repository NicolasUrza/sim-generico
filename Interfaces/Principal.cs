using TP_4_SIM_Aeropuerto.Controlador;
using TP_4_SIM_Aeropuerto.Entidades;
using TP_4_SIM_Aeropuerto.Interfaces;

namespace TP_4_SIM_Aeropuerto
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

      
        public bool ValidarParametros()
        {
            try{
                // agregar tus validaciones aqui

            }
            catch (Exception e)
            {
                MessageBox.Show("Verifique los valores ingresados");
                return false;
            }
            return true;
        }

        public void CargarResultados(FilaSimulacion[] simulacion, Metricas m)
        {
            //programar
            //el controlador llama a este metodo para mostrar los resultados
            //limpiamos el panel
            this.pnSolucion.Controls.Clear();
            // creamos el control de resultados
            // le pasamos las filas de la simulacion para que las carge
            // y las metricas para la pantalla de conclusiones
            var res = new ResultadosControl(simulacion, m);
            res.Dock = DockStyle.Fill;

            //lo mostramos
            this.pnSolucion.Controls.Add(res);


        }

        private void btnGenerarSimulacion_Click_1(object sender, EventArgs e)
        {
                if (ValidarParametros())
                {
                    var param = new Parametros();
                    param.MediaLlegadaAvion = double.Parse(this.txtLlegadaAvion.Text);
                    param.MediaAterrizaje = double.Parse(this.txtAterrizaje.Text);
                    param.CantidadDeIteraciones = int.Parse(this.txtCantIteraciones.Text);
                    param.Desde = int.Parse(this.txtDesde.Text);
                    var controlador = new ControladorSimulacion(this, param);
                    controlador.GenerarSimulacion();

                }
            }

           

        private void Principal_Load_1(object sender, EventArgs e)
        {
            // aca podes cargar datos si queres
            // este metodo funciona al principio del programa
        }

        private void txtLlegadaAvion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
           
        }

        private void txtAterrizaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtMediaMuelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtMediaCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtAerolineaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtAerolineaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }

        private void txtCantIteraciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantIteraciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIntencionCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtIntencionMuelle_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtIntencionMuelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtIntencionCarga_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}