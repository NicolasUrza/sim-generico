using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_4_SIM_Aeropuerto.Entidades;

namespace TP_4_SIM_Aeropuerto.Controlador
{
    public class ControladorSimulacion
    {
        private Principal principalForm;
        private Parametros parametros;
        private FilaSimulacion[] resultadosDesde;

        private Random generadorRandom = new Random();

        private double a = 0;


        public ControladorSimulacion(Principal pri, Parametros par)
        {
            this.principalForm = pri;
            this.parametros = par;

        }

        public void GenerarSimulacion()
        {
            // programar
            // simulacion, usar los parametros de la inicializacion
            // llenar fila de simulacion

        }
    }
}
