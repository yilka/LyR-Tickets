using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyR_Tickets
{
    public class Ticket
    {
        private int servicio;

        public int ID_Ticket { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Telefono_Cliente { get; set; }
        public string Comentarios { get; set; }

        public int Servicio { get; set; }

        public Ticket(int id_ticket, DateTime fecha, string nombre_cliente, string telefono_cliente, string comentarios, int servicio)
        {
            ID_Ticket = id_ticket;
            Fecha = fecha;
            Nombre_Cliente = nombre_cliente;
            Telefono_Cliente = telefono_cliente;
            Comentarios = comentarios;
            Servicio = servicio;
        }
    }
}
