using System;
using Newtonsoft.Json;
using Experimental.System.Messaging; 
using System.IO;

namespace agente_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s1=null;
            //Creamos un do while para repetir.
            do{
                Console.WriteLine("");  
                Console.WriteLine("                           Bienvenido a el Microservicio UMG                            ");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Si deseas que el agente 1 genere un nombre  aleatorio escribe 1 de lo contrario escribe 2");
                Console.Write("1. Si \n");
                Console.Write("2. No \n" );
                Console.WriteLine("");
                s1 = Console.ReadLine();
                switch(s1){
        
                case "1":
                //Mensaje de la Cola
                String envio = Path.GetRandomFileName();
                            
                //Conexión a la Cola
                MessageQueue queue = new MessageQueue (".\\private$\\nombres");

                //Converit a Json
                String mesaggeJson=JsonConvert.SerializeObject(envio);

                //Enviar el mensaje
                Console.WriteLine("");
                Console.WriteLine("El nombre se a enviado exitosamente");
                Console.WriteLine("");
                Console.WriteLine(envio);
                queue.Send(envio);
                Console.ReadKey();
                break;
  
                case "2":
                Console.WriteLine("Nos vemos a la proxima");
                break;
                }
                Console.WriteLine("Desea ejecutar de nuevo responde con un si o un no");
                s1 = Console.ReadLine();
                } while(s1== "Si"||s1=="si" );
                { 
                Console.ReadKey();
                }     
        }
    }
    public class MessageNombre
    {
        public String nombre {get; set;}
    }
}