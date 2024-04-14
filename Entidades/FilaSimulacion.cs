using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TP_4_SIM_Aeropuerto.Entidades
{
    public class FilaSimulacion
    {
        public string evento { get; set; }
        public double reloj { get; set; }
        public List<Avion> aviones { get; set; }
       

        public FilaSimulacion()
        {
            //estado inicial
                evento = "";
                reloj = 0;
            aviones = new List<Avion>();
        }
        public FilaSimulacion(FilaSimulacion f, bool keep =false)
        {
            // para copiar una fila simulacion
            // prestar mucha atencion a este metodo
            // la clonacion es un metodo que sirve para crear nuevas filas, con los mismos valores que la fila original
            // y es un metodo central de como funciona todo
            // si no se entiende bien, preguntar
            // recorda que debes tener un metodo de clonacion como este en cada clase que quieras clonar
            this.aviones = new List<Avion>();
            foreach (var avion in f.aviones)
            {
                // si queremos clonar un objeto dentro de objeto como esta lista de aviones, tenemos que usar su metodo de clonacion
                // si no lo tiene, hay que crearlo
                this.aviones.Add(new Avion(avion));
            }
          
            this.evento = f.evento;
            this.reloj = f.reloj;
           

        }

     

        public (string, double) siguienteEventoyReloj()
        {
            //programar para devolver el evento y el reloj del proximo evento
            List<(string, double)> Events = new List<(string,double)>();

            double smaller = -1;
            string nextEvent = "";
            //ACA HAY UN EJEMPLO de lo que haciamos antes con los eventos de los aviones
            //for (int i = 0; i < Events.Count; i++)
            //{
            //    if(i == 0)
            //    {
            //        smaller = Events[i].Item2;
            //        nextEvent = Events[i].Item1;
            //    }
                
            //    else if ((smaller == 0 )|| (Events[i].Item2 < smaller && Events[i].Item2 != 0))
            //    {
            //        smaller = Events[i].Item2;
            //        nextEvent = Events[i].Item1;
            //    }
            //}

            return (nextEvent, smaller);
        }

        public string[] ListaString(int cantAvionesTotales, int condicionCorte)
        {
            //programar para devolver un vector de string con los datos de la fila
            var str = new string[]
            {
                
            };
            
            return str;
        }

        
        

    }
}
