using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _01_Socket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string ipAddress = "10.10.13.100";
            int port = 5555;

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            server.Bind(endPoint);
            server.Listen(10);

            Console.WriteLine($"Server started {ipAddress}:{port}");
            Console.WriteLine("Listeting...");

            while(true)
            {
                try
                {
                    Socket client = server.Accept();
                    Console.WriteLine($"Client connected {client.RemoteEndPoint?.ToString()}");

                    try
                    {
                        while (client.Connected)
                        {
                            // receive
                            byte[] buffer = new byte[1024];
                            int l = client.Receive(buffer);
                            string clientMessage = Encoding.UTF8.GetString(buffer, 0, l);
                            Console.WriteLine($"Client message: {clientMessage}");

                            if(clientMessage == "image")
                            {
                                var imageBytes = File.ReadAllBytes("image.jpg");
                                client.Send(imageBytes);
                            }
                            else
                            {
                                // send
                                Console.Write("Enter response: ");
                                string? response = Console.ReadLine();
 
                                response ??= "Empty response";
                                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                                client.Send(responseBytes);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
