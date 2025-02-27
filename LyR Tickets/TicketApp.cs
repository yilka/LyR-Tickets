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

        public static void EditTicket(DB db)
        {
            Console.WriteLine("Ingrese el ID del ticket que quiere modificar:");
            int ID_ticket = Convert.ToInt32(Console.ReadLine());

            Ticket tickettoedit = db.Tickets.Find(t => t.ID_Ticket == ID_ticket);
            if(tickettoedit == null)
            {
                Console.WriteLine(" ");
                Console.WriteLine("No se ha encontrado el ticket");
                return;
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Ticket ID a editar: {tickettoedit.ID_Ticket}");
            Console.WriteLine(" ");
            Console.WriteLine($"Nombre de cliente: {tickettoedit.Nombre_Cliente}");
            Console.WriteLine(" ");
            Console.WriteLine($"Telefono: {tickettoedit.Telefono_Cliente}");
            Console.WriteLine(" ");
            Console.WriteLine($"Servicio: {db.Servicios.Find(s => s.ID_Servicio == tickettoedit.Servicio)?.Servicio}");
            Console.WriteLine(" ");
            Console.WriteLine($"Comentarios: {tickettoedit.Comentarios}");
            Console.WriteLine(" ");



            Console.WriteLine("Modifique el nombre del cliente (dejar en blanco si quiere mantener el actual): ");
            Console.WriteLine(" ");
            string newnombrecliente = Console.ReadLine();
            if (!string.IsNullOrEmpty(newnombrecliente))
            {
                tickettoedit.Nombre_Cliente = newnombrecliente;
            }


            Console.WriteLine("Modifique el teléfono del cliente (dejar en blanco si quiere mantener el actual): ");
            Console.WriteLine(" ");
            string newtelcliente = Console.ReadLine();
            if (!string.IsNullOrEmpty(newtelcliente))
            {
                tickettoedit.Telefono_Cliente = newtelcliente;
            }

            Console.WriteLine("Su ticket ha sido actualizado exitosamente");
            Console.WriteLine(" ");
        }
    }
}
