using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_4_SIM_Aeropuerto.Entidades;
using static System.Windows.Forms.DataFormats;

namespace TP_4_SIM_Aeropuerto.Interfaces
{
    public partial class SimulacionControl : UserControl
    {
        private FilaSimulacion[] simulacion;
        Color headerColor = Color.FromArgb(0, 51, 102);
        public SimulacionControl(FilaSimulacion[] f)
        {
            this.simulacion = f;

            InitializeComponent();
            CargarSimulacion();
            this.dataGridView1.AllowUserToOrderColumns = false;

        }
        private void CargarSimulacion()
        {
            // programar para cargar la simulacion
            // en el datagridview
            // recorre lo que sea que le pases y lo carga en el datagridview
            // acordate de crear las columnas ANA
            // y de ponerle el nombre a las columnas
            // te dejamos aca como crear las columnas que se muestran en el datagridview
            this.dataGridView1.Columns.Add("Reloj", "Reloj");
            this.dataGridView1.Columns.Add("RND", "RND");

           int i = 1;
            var contador = 0;
            bool overflow = false;
            // esto añade las columnas del avion, tene cuidado aca
            // esto es solo un ejemplo, vos tenes que hacerlo con las columnas que necesites de las maquinas de manufactura
            // lo deje aca para que mantengas el overflow que es lo que impide que se rompa el programa
            foreach (Avion a in simulacion[simulacion.Length - 1].aviones)
            {
                try
                {
                    this.dataGridView1.Columns.Add("estado_avion" + i.ToString(), "Estado");
                    this.dataGridView1.Columns.Add("hora_llegada" + i.ToString(), "Hora Llegada");
                    contador++;
                }
                catch (Exception e)
                {
                    overflow = true;
                    this.dataGridView1.Columns.Remove("estado_avion" + i.ToString());
                }
                if (overflow)
                    break;
            }
          
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 3 + 20;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            this.dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
            this.dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
            this.dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;

            var cantAvionesTotal = simulacion[simulacion.Length - 1].aviones.Count();
            foreach (DataGridViewTextBoxColumn d in dataGridView1.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (FilaSimulacion f in simulacion)
            {
                this.dataGridView1.Rows.Add(f.ListaString(cantAvionesTotal, contador));
            }


        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
            this.dataGridView1.AllowUserToOrderColumns = false;

        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
            this.dataGridView1.AllowUserToOrderColumns = false;

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            // esto de aca lo que hace es que pinta el header de la tabla
            // es decir, viste que hay columnas con varios datos, bueno, esas columnas tiene un header que ocupa todo el largo de las columnas
            // y este metodo es crearlo y pintarlo

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                // i y e no lo toques
                // index le tenes que cambiar por donde empieza la columna
                if (this.dataGridView1.Columns[i].Index == 2)
                {
                    //ese 3 significa que va a ocupar 3 columnas, iniciando por la 2
                    //entonces ocupa la 2, 3 y 4
                    // en este caso entonces se va a pintar el header como "LLegada avion"
                    CustomizeCell(i, e, "Llegada Avion", 3);
                }
                // la siguiente entonces va a empezar en el 5
                if (this.dataGridView1.Columns[i].Index == 5)
                {
                    // y como ocupa 3 , va a ocupar la 5, 6, 7 
                    CustomizeCell(i, e, "Llegada Avion Aerolinea", 3);
                }
               
            }

            int c = 0;
            int inicioColumna = 46;
            int anchoDeLaColumna = 2;
            foreach (Avion a in simulacion[simulacion.Length - 1].aviones)
            {
                // en este caso lo que hacemos es que agregamos la columnas de cada Avion, vos no vas a tener aviones
                // pero bueno despues cambias esas clases con lo que vos necesites.
                // puse 46 porque el primer avion va a estar en la columna 46 en inicioColumna porque originalmente asi funcionaba
                // pero ahora te tenes que fijar vos donde iniciarian los objetos que creaste
                // el c es el numero del objeto (avion 1, avion 2, avion3, etc)
                // el anchoDeLaColumna es cuantas columnas va a ocupar el objeto (en nuestro caso eran 2)
                CustomizeCell(inicioColumna + c * anchoDeLaColumna, e, "Avion" + (c + 1).ToString(), anchoDeLaColumna);
                c++;
                // esto de aca es para que no se pase de la cantidad de columnas que se pueden crear
                if (inicioColumna -1 + c * 2 > 652)
                    break;
            }
 
            this.dataGridView1.AllowUserToOrderColumns = false;

        }

        private void CustomizeCell(int index, PaintEventArgs e, string header, int cellsOverlapped)
        {
            Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(index, -1, true);

            int[] wk = new int[cellsOverlapped];
            int sum = 0;

            for (int i = 1; i < cellsOverlapped; i++)
            {
                wk[i] = this.dataGridView1.GetCellDisplayRectangle(index + i, -1, true).Width;
                sum += wk[i];
            }

            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + sum - 2;
            r1.Height = r1.Height / 3 - 2;
            e.Graphics.FillRectangle(new SolidBrush(headerColor), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(header,
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
            new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),
            r1,
            format);
            this.dataGridView1.AllowUserToOrderColumns = false;


        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
            this.dataGridView1.AllowUserToOrderColumns = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.AllowUserToOrderColumns = false;

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
