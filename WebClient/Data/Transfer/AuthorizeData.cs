using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WebClient.Data.Models;
using WebClient.Data.Service;

namespace WebClient.Data.Transfer
{
    public class AuthorizeData : IUserUseCases
    {
        private AuthInfo authInfo;

        public async Task<AuthInfo> LogIn(string email, string password)
        {
            string data;
            var baseAddress = new Uri("https://localhost:7059");
            string url = "login";

            var jsonObject = new
            {
                email,
                password,
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(jsonObject), Encoding.UTF8,
                "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(baseAddress + url, content);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
                authInfo = JsonConvert.DeserializeObject<AuthInfo>(data);
                return authInfo;
            }
            else
            {
                MessageBox.Show("Invalid login or password");
                return null;
            }
        }

        public async Task<string> Register(string email, string password)
        {
            string data;
            var baseAddress = new Uri("https://localhost:7059");
            string url = "signin";
            string message;

            var jsonObject = new
            {
                email,
                password,
                role = "User"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(jsonObject), Encoding.UTF8,
                "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(baseAddress + url, content);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
                message = "ok";
            }
            else
            {
                message = "error";
            }

            return message;
        }
    }
}