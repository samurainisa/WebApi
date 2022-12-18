using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebClient.Data.Models;
using WebClient.Data.Service;

namespace WebClient.Data.Transfer
{
    public class UploadData : IAdminUseCases
    {
        public async Task<List<Sport>> GetSports(string token)
        {
            return await GetData<Sport>(token, "api/Sports");
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

        public async Task<List<Trener>> GetTreners(string token)
        {
            return await GetData<Trener>(token, "api/Treners");
        }

        public Task<TrenerDto> PostTrenerDto(TrenerDto trener, string token)
        {
            return PostData(trener, token, "api/Treners");
        }

        public async Task<List<Athlete>> GetAthletes(string token)
        {
            return await GetData<Athlete>(token, "api/Athletes");
        }

        public async Task<AthleteDto> PostAthleteDto(AthleteDto athlete, string token)
        {
            var result = await PostData(athlete, token, "api/Athletes");
            if (result != null)
            {
                MessageBox.Show("Спортсмен добавлен");
            }

            return result;
        }

        public Task<List<SportPlaces>> GetSportPlaces(string token)
        {
            return GetData<SportPlaces>(token, "api/SportPlaces");
        }

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
            }

            return null;
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

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        return JsonConvert.DeserializeObject<T>(dataString);
                    }

                    MessageBox.Show("Invalid data");
                    return default(T);
                }
            }
            catch
            {
                return default(T);
            }
        }

        //universal method for delete data from server
        public async Task<T> DeleteData<T>(T name, string token, string url)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    //обратиться к clubname.Name
                    var result = await client.DeleteAsync(baseAddress + url + name);


                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                        return JsonConvert.DeserializeObject<T>(dataString);
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }
            }
            catch (JsonReaderException jsonEx)
            {
                return default;
            }
        }

        public async Task<string> DeleteClub(Club clubname, string token)
        {
            return await DeleteData(clubname.Name, token, "api/Clubs/");
        }

        public Task<List<UserData>> GetUsers(string token)
        {
            return GetData<UserData>(token, "api/UserLogins");
        }

        public async Task<string> EditClub(Club club, string authInfoAccessToken)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                var url = $"{baseAddress}api/Clubs/{club.Id}";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authInfoAccessToken}");

                    var result = await client.PutAsync(url,
                        new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        var data = JsonConvert.DeserializeObject<string>(dataString);
                        return data;
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }
            }
            catch
            {
                return default;
            }
        }

        public async Task<string> DeleteSport(Sport sport, string token)
        {
            return await DeleteData(sport.Name, token, "api/Sports/");
        }

        public async Task<string> EditSport(Sport sport, string token)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                var url = $"{baseAddress}api/Sports/{sport.Id}";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var result = await client.PutAsync(url,
                        new StringContent(JsonConvert.SerializeObject(sport), Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        var data = JsonConvert.DeserializeObject<string>(dataString);
                        return data;
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }
            }
            catch
            {
                return default;
            }
        }

        public async Task<string> DeleteSportPlace(SportPlaces sport, string token)
        {
            return await DeleteData(sport.Name, token, "api/SportPlaces/");
        }

        public async Task<string> EditSportPlace(SportPlaces sport, string token)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                var url = $"{baseAddress}api/SportPlaces/{sport.Id}";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var result = await client.PutAsync(url,
                        new StringContent(JsonConvert.SerializeObject(sport), Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        var data = JsonConvert.DeserializeObject<string>(dataString);
                        return data;
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }
            }
            catch
            {
                return default;
            }
        }

        public Task<string> DeleteTrener(Trener trener, string token)
        {
            return DeleteData(trener.Id.ToString(), token, "api/Treners/");
        }

        public async Task<string> EditTrener(Trener trener, string token)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                var url = $"{baseAddress}api/Treners/{trener.Id}";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var result = await client.PutAsync(url,
                        new StringContent(JsonConvert.SerializeObject(trener), Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        var data = JsonConvert.DeserializeObject<string>(dataString);
                        return data;
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }
            }
            catch
            {
                return default;
            }
        }

        public async Task<string> DeleteAthlete(Athlete athlete, string token)
        {
            return await DeleteData(athlete.Id.ToString(), token, "api/Athletes/");
        }

        public async Task<string> EditAthlete(Athlete athlete, string token)
        {
            try
            {
                var baseAddress = new Uri("https://localhost:7059");
                var url = $"{baseAddress}api/Athletes/{athlete.Id}";
                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var result = await client.PutAsync(url,
                        new StringContent(JsonConvert.SerializeObject(athlete), Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        var data = JsonConvert.DeserializeObject<string>(dataString);
                        return data;
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }
            }
            catch
            {
                return default;
            }
        }

        public Task<string> DeleteUserLogins(UserData user, string token)
        {
            return DeleteData(user.UserId.ToString(), token, "api/UserLogins/");
        }

        public async Task<UserData> EditUserLogins(UserData user, string token)
        {

                var baseAddress = new Uri("https://localhost:7059");
                var url = $"{baseAddress}api/UserLogins/{user.UserId}";

                using (var client = new HttpClient(new HttpClientHandler()) { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var result = await client.PutAsync(url,
                        new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        var bytes = await result.Content.ReadAsByteArrayAsync();
                        var dataString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        var data = JsonConvert.DeserializeObject<UserData>(dataString);
                        return data;
                    }

                    MessageBox.Show("Invalid data");
                    return default;
                }

        }
    }
}