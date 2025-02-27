using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyR_Tickets
{
    public class DB
    {
        public List<Ticket> Tickets { get; set; }
        public List<Service> Servicios { get; set; }


        public DB()
        {
            Tickets = new List<Ticket>();
            Servicios = new List<Service>();
        }

        public static void SampleServices (DB db)
        {
            db.Servicios.Add(new Service(1, "Cambio de Aceite", 40000));
            db.Servicios.Add(new Service(2, "Revisión General", 50000));
            db.Servicios.Add(new Service(3, "Cambio de Frenos", 60000));
        }
    }
}
