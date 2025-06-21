using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace _03_http
{
    internal class Program
    {
        static async Task CurrentWeather()
        {
            string apiKey = "5b3e1962e851cae3aa03c407c1743565";
            string cityName = "Rivne";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            HttpClient client = new HttpClient();

            //HttpResponseMessage response = await client.GetAsync(url);
            //if(response.IsSuccessStatusCode)
            //{
            //    string json = await response.Content.ReadAsStringAsync();
            //    WeatherModel? model = JsonSerializer.Deserialize<WeatherModel>(json);

            //    Console.WriteLine($"Місто: {model.name}");
            //    Console.WriteLine($"Температура: {model.main.temp}");
            //    Console.WriteLine($"Швидкість вітру: {model.wind.speed}");
            //    Console.WriteLine($"Тиск: {model.main.pressure}");
            //}


            WeatherModel? model = await client.GetFromJsonAsync<WeatherModel?>(url);

            if (model != null)
            {
                Console.WriteLine($"Місто: {model.name}");
                Console.WriteLine($"Температура: {model.main.temp}");
                Console.WriteLine($"Швидкість вітру: {model.wind.speed}");
                Console.WriteLine($"Тиск: {model.main.pressure}");
            }
        }

        static async Task RandomCatImage()
        {
            string url = "https://api.thecatapi.com/v1/images/search";

            HttpClient client = new HttpClient();
            CatModel[]? model = await client.GetFromJsonAsync<CatModel[]?>(url);
            client.Dispose();

            if(model != null && model.Length > 0)
            {
                string imageUrl = model[0].url;
                client = new HttpClient();

                byte[] image = await client.GetByteArrayAsync(imageUrl);

                var items = imageUrl.Split('/');
                string imageName = items.Last();
                await SaveImage(image, imageName);
            }
        }

        static async Task SaveImage(byte[] image, string imageName)
        {
            string dirPath = "C:\\Users\\traig\\Desktop\\cats";
            string filePath = Path.Combine(dirPath, imageName);

            await File.WriteAllBytesAsync(filePath, image);
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // await CurrentWeather();


            while(true)
            {
                Console.ReadLine();
                await RandomCatImage();
            }
        }
    }
}
