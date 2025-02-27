using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyR_Tickets
{
    public class Service
    {
        public int ID_Servicio { get; set; }
        public string Servicio { get; set; }
        public int Precio{ get; set; }


        public Service(int ID_servicio, string servicio, int precio)
        {
            ID_Servicio = ID_servicio;
            Servicio = servicio;
            Precio = precio;
        }
    }
}
