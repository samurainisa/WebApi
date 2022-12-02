using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WebApiClient.Data.Models;
using WebApiClient.Data.Service;

namespace WebApiClient.Data.Transfer
{
    public class UploadData : DataUseCases
    {
        public async Task<List<Club>> GetClubs(string token)
        {
            try
            {
                string data;
                var baseAddress = new Uri("https://localhost:7059");
                var url = "api/Clubs";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var result = await client.GetAsync(url);
                    var bytes = await result.Content.ReadAsByteArrayAsync();
                    data = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                }

                return JsonConvert.DeserializeObject<List<Club>>(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public Task<Club> PostClub(Club club, string token)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                var url = "api/Clubs";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    
                    var result = client.PostAsync(baseAddress + url,
                        new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json")).Result;
                    
                    var bytes = result.Content.ReadAsByteArrayAsync().Result;
                    var data = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    
                    return Task.FromResult(JsonConvert.DeserializeObject<Club>(data));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
        }
    }