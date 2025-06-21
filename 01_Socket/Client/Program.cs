using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string ipAddress = "10.10.13.100";
            int port = 5555;
            EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(serverEndPoint);

            try
            {
                while (client.Connected)
                {
                    // send
                    Console.Write("Enter message: ");
                    string? message = Console.ReadLine();
                    message ??= "Empty message";

                    var messageBytes = Encoding.UTF8.GetBytes(message);
                    client.Send(messageBytes);

                    // receive
                    if(message == "image")
                    {
                        byte[] buffer = new byte[8096];
                        List<byte> imageBytes = new List<byte>();

                        while(true)
                        {
                            int l = client.Receive(buffer);
                            imageBytes.AddRange(buffer);
                            if(l < 8096)
                            {
                                break;
                            }
                        }

                        File.WriteAllBytes("C:/serverImage.jpg", imageBytes.ToArray());
                        Console.WriteLine("Image saved");
                    }
                    else
                    {
                        byte[] buffer = new byte[8096];
                        int l = client.Receive(buffer);
                        string serverResponse = Encoding.UTF8.GetString(buffer, 0, l);

                        Console.WriteLine($"Server send: {serverResponse}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
