using FluentFTP;

namespace _05_ftp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string host = "";
            string user = "";
            string password = "";
            string root = "";

            using (var ftpClient = new FtpClient(host, user, password))
            {
                ftpClient.Connect();

                // вивести список всіх файлів та папок у кореневій теці
                //FtpListItem[] items = ftpClient.GetListing(root);
                //foreach (var item in items)
                //{
                //    Console.WriteLine(item.Name);
                //}

                // завантажити файл з FTP-сервера
                var status = ftpClient.DownloadFile("log_2025060604.log", root + "logs/log_2025060604.log");
                Console.WriteLine(status);

                // upload
                status = ftpClient.UploadFile(@"C:\Users\traig\Downloads\minio.png", root + "spr421.png");
                Console.WriteLine(status);
            }
        }
    }
}
