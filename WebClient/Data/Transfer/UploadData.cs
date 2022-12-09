using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WebClient.Data.Models;
using WebClient.Data.Service;

namespace WebClient.Data.Transfer
{
    public class UploadData : IDataUseCases
    {
        public async Task<List<Sport>> GetSports(string token)
        {
            return await GetData<Sport>(token, "api/Sports");
        }

        public Task<List<SportPlaces>> GetSportPlaces(string token)
        {
            
            return GetData<SportPlaces>(token, "api/SportPlaces");
        }
        //dada


        public Task<Sport> PostSport(Sport sport, string token)
        {
            return PostData(sport, token, "api/Sports");
        }

        //universal method for getting data from server
        public async Task<List<T>> GetData<T>(string token, string url)
        {
            try
            {
                string data;
                var baseAddress = new Uri("https://localhost:7059");

                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var result = await client.GetAsync(url);
                    var bytes = await result.Content.ReadAsByteArrayAsync();
                    data = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                }

                return JsonConvert.DeserializeObject<List<T>>(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        //universal method for posting data to server
        public async Task<T> PostData<T>(T data, string token, string url)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var result = await client.PostAsync(baseAddress + url,
                        new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

                    var bytes = await result.Content.ReadAsByteArrayAsync();
                    var dataFromServer = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                    return JsonConvert.DeserializeObject<T>(dataFromServer);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public async Task<List<Club>> GetClubs(string token)
        {
            return await GetData<Club>(token, "api/Clubs");
        }

        public async Task<Club> PostClub(Club club, string token)
        {
            return await PostData(club, token, "api/Clubs");
        }

        public async Task<SportPlaces> PostSportPlace(SportPlaces sportplace, string token)
        {
            return await PostData(sportplace, token, "api/SportPlaces");
        }
    }
}
