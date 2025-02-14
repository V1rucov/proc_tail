using System.Configuration;
using Newtonsoft.Json;

namespace proc_tail.TI
{
    public class VirusTotalApi
    {
        public VirusTotalApi(){
            Token = ConfigurationManager.AppSettings["Token"];
        }
        public string Token { get; set;}

        public VirusTotalResponse CheckHash(string hash)
        {
            HttpClient client = new HttpClient();

            string url = $"https://www.virustotal.com/api/v3/files/{hash}";
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("x-apikey", Token);

            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<VirusTotalResponse>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }

        }
    }
}
