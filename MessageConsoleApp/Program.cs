using System;
using SerialPortManager;
using MessageManager;
using System.Threading;

namespace MessageConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
           
            SerialPortListener listener = new SerialPortListener("COM2");

            listener.RawMessageRecieved += new EventHandler<RecievedMessageEventArgs>(listener_OnMessageRecieved);
            listener.Start();
            Console.WriteLine(listener.ToString());

            Console.WriteLine("Press ESC to exit");
            do
            {
                while (!Console.KeyAvailable)
                {
                    
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            listener.Dispose();

        }

        static void listener_OnMessageRecieved(object sender, RecievedMessageEventArgs e)
        {
            if (e.RawData.Length == 3)
            {
                var deviceMessage = new DeviceMessage(e.RawData, DateTime.Now);
                Console.WriteLine("Message Recieved: {0} {1} {2}", 
                    deviceMessage.GetRawMessage()[0], deviceMessage.GetRawMessage()[1], deviceMessage.GetRawMessage()[2]);
            }
            else
                Console.WriteLine("Recieved Unknown Message of length: " + e.RawData.Length);
        }

   
    }
}
