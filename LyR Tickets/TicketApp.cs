using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyR_Tickets
{
    public class TicketApp
    {
        public static void AddTicket (DB db)
        {
            Console.WriteLine("Ingrese el nombre del cliente: ");
            string Nombre_Cliente = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Ingrese el teléfono del cliente: ");
            string Telefono_Cliente = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Seleccione el servicio: ");
            for (int i = 0; i < db.Servicios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {db.Servicios[i].Servicio} - ${db.Servicios[i].Precio}");
            }

            int ServiceChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            Service selectedService = db.Servicios[ServiceChoice];
            Console.WriteLine(" ");

            Console.WriteLine("Ingrese sus comentarios: ");
            string Comentarios = Console.ReadLine();

            Ticket newTicket = new Ticket(
                id_ticket: db.Tickets.Count + 1,
                fecha: DateTime.Now,
                nombre_cliente: Nombre_Cliente,
                telefono_cliente: Telefono_Cliente,
                servicio: selectedService.ID_Servicio,
                comentarios: Comentarios );

            db.Tickets.Add(newTicket);
            Console.WriteLine(" ");
            Console.WriteLine($"Ticket creado exitosamente (Número de ticket: {newTicket.ID_Ticket})");
            Console.WriteLine(" ");
        }
        public static void ViewTicket(DB db)
        {
            Console.WriteLine("Todos los tickets:");
            foreach(var ticket in db.Tickets)
            {
                Service service = db.Servicios.Find(s => s.ID_Servicio == ticket.Servicio);
                Console.WriteLine($"Ticket ID: {ticket.ID_Ticket},Fecha: {ticket.Fecha} ,Cliente: {ticket.Nombre_Cliente}, Teléfono: {ticket.Telefono_Cliente}, Servicio: {service.Servicio}, Comentarios: {ticket.Comentarios}");
            }
        }
    }
}
