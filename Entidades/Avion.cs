using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_SIM_Aeropuerto.Entidades
{
    public class Avion
    {
        //ESte deberia ser tu clase manufactura o como lo quieras llamar, aca seria un objeto de tipo manufactura
        // cambiale los atributos como vos quieras
        private string estado;
        private double horaLlegada;
        public Avion()
        {
            estado = "EP";
            horaLlegada = 0;
        }
        public Avion(string estado, double horaLlegada)
        {
            this.estado = estado;
            this.horaLlegada = horaLlegada;
        }
        public Avion(Avion a)
        {
            estado = a.estado;
            horaLlegada = a.horaLlegada;
        }
       
    }
}
