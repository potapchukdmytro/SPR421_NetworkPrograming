using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Client
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
    }

    internal class Program
    {
        static Dictionary<Socket, Client> clients = new Dictionary<Socket, Client>();

        static byte[] StringToBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        static string BytesToString(byte[] bytes, int index, int length)
        {
            return Encoding.UTF8.GetString(bytes, index, length);
        }

        static Client GetClient(Socket socket)
        {
            foreach (var s in clients)
            {
                if(s.Key.RemoteEndPoint == socket.RemoteEndPoint)
                {
                    return s.Value;
                }
            }

            return null;
        }

        static void WorkWithClient(Socket client)
        {
            Task.Run(() =>
            {
                try
                {
                    var buffer = new byte[8096];

                    client.Send(StringToBytes("Enter your name"));
                    int l = client.Receive(buffer);
                    string clientData = BytesToString(buffer, 0, l);

                    string clientName = clientData.Split(" - ")[0];
                    string clientColor = clientData.Split(" - ")[1];
                    Client clientObj = new Client { Name = clientName, Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor) ,clientColor) };

                    clients.Add(client, clientObj);
                    Console.ForegroundColor = clientObj.Color;
                    Console.WriteLine($"Client added: {clientName} - {client.RemoteEndPoint}");
                    Console.ResetColor();
                    ClientChat(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        static void ClientChat(Socket client)
        {
            var buffer = new byte[8096];
            while (client.Connected)
            {
                int l = client.Receive(buffer);
                string message = BytesToString(buffer, 0, l);
                var clientObj = GetClient(client);
                Console.ForegroundColor = clientObj.Color;
                Console.WriteLine($"{clientObj.Name}: {message}");
                Console.ResetColor();

                foreach (var c in clients)
                {
                    if(c.Key.RemoteEndPoint != client.RemoteEndPoint)
                    {
                        c.Key.Send(StringToBytes($"{clientObj.Name}: {message}"));
                    }
                }
            }
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var ip = IPAddress.Parse("26.251.103.65");
            int port = 5555;
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var endPoint = new IPEndPoint(ip, port);
            server.Bind(endPoint);
            server.Listen(50);

            Console.WriteLine($"Server started {endPoint}");

            while(true)
            {
                try
                {
                    Console.WriteLine("Wait for client...");
                    Socket client = await server.AcceptAsync();
                    Console.WriteLine($"Client connected {client.RemoteEndPoint}");
                    WorkWithClient(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
