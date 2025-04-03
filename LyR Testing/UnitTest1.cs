using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using LyR_Tickets;
using System.Linq;

namespace LyR_Testing
{
    [TestClass]
    public class UnitTest1
    {
        private void SimulateUser (String[] inputs)
        {
            Console.SetIn(new StringReader("1"));
        }


        public string consoleoutput(Action action)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                action();
                return sw.ToString();
            }
        }


        [TestMethod]
        public void Pantalla_Inicio()
        {

            var output = consoleoutput(() => App.Main(Array.Empty<string>()));

            StringAssert.Contains("¡Bienvenido!", output);
            StringAssert.Contains("1.Crear un Ticket", output);
            StringAssert.Contains("2.Ver lista de tickets", output);
            StringAssert.Contains("3.Editar ticket", output);
            StringAssert.Contains("4.Salir", output);
            StringAssert.Contains("Por favor selecione una opción: ", output);
        }





        [TestMethod]
        public void view_data()
        {

            var app = new TicketApp();
            app.AddTicket();

            SimulateUser(new string[] { "1", "Juan", "88453421", "2", "N/A" });

            var output = consoleoutput(() => app.ViewTicket());

            StringAssert.Contains("Ticket ID:", output);
            StringAssert.Contains("Fecha:", output);
            StringAssert.Contains("Cliente:", output);
            StringAssert.Contains("Teléfono:", output);
            StringAssert.Contains("Servicio:", output);
            StringAssert.Contains("Comentarios:", output);
        }




    }
}

 

