using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.TI
{
    public class VirusTotalApi
    {
        public VirusTotalApi(string Token){
            this.Token = Token;
        }
        public string Token { get; set;}

        public async void CheckHash(string hash)
        {
            HttpClient client = new HttpClient();

            string url = $"https://www.virustotal.com/api/v3/files/{hash}";
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("x-apikey", Token);

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }
}
