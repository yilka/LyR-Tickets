using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyR_Tickets
{
    public class App
    {
        public static void Main (string[] args)
        {
            DB db = new DB();

            DB.SampleServices(db);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("¡Bienvenido!");
                Console.WriteLine("1.Crear un Ticket");
                Console.WriteLine("2.Ver lista de tickets");
                Console.WriteLine("3.Editar ticket");
                Console.WriteLine("4.Salir");
                Console.WriteLine("Por favor selecione una opción: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        TicketApp.AddTicket(db);
                        break;

                    case 2:
                        TicketApp.ViewTicket(db);
                        break;




                    default:
                        Console.WriteLine("Opción Inválida, Por favor vuelva a intentarlo");
                        break;
                }

                if (choice != 3)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
    }


}
