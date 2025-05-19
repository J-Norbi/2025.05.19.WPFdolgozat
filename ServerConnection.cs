using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace _2025._05._19.WPFdolgozat
{
    public class ServerConnection
    {
        private HttpClient client = new HttpClient();
        private string baseURL = "http://127.1.1.1:3000";

        public async Task<List<Mushroom>> GetGomba()
        {
            List<Mushroom> all = new List<Mushroom>();
            string url = baseURL + "/gomba";
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.GetAsync(url);
                string res = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                all = JsonConvert.DeserializeObject<List<Mushroom>>(res);
            }
            catch (Exception e)
            {
                string res = await response.Content.ReadAsStringAsync();
                Mushroom a = JsonConvert.DeserializeObject<Mushroom>(res);
                MessageBox.Show($"Error: {response.StatusCode} , {a.message}", "Hiba!");
            }
            return all;
        }
        public async Task PostOne(string nev, bool mergezo, string szin, string megjegyzes)
        {
            string url = baseURL + "/gomba";
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var jsonData = new
                {
                    newNev = nev,
                    newMergezo = mergezo,
                    newSzin = szin,
                    newMegjegyzes = megjegyzes
                };
                string jsonStrong = JsonConvert.SerializeObject(jsonData);
                StringContent sendThis = new StringContent(jsonStrong, Encoding.UTF8, "Application/JSON");
                response = await client.PostAsync(url,sendThis);
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                Mushroom a = JsonConvert.DeserializeObject<Mushroom>(res);
                MessageBox.Show($"Siker: {a.message}", ":)");
            }
            catch (Exception e)
            {
                string res = await response.Content.ReadAsStringAsync();
                Mushroom a = JsonConvert.DeserializeObject<Mushroom>(res);
                MessageBox.Show($"Error: {response.StatusCode} , {a.message}", "Hiba!");
            }
        }
        public async Task deleteOne(int id)
        {
            string url = baseURL + "/gomba/" + id;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {

                response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                Mushroom a = JsonConvert.DeserializeObject<Mushroom>(res);
                MessageBox.Show($"Siker: {a.message}", ":)");
            }
            catch (Exception e)
            {
                string res = await response.Content.ReadAsStringAsync();
                Mushroom a = JsonConvert.DeserializeObject<Mushroom>(res);
                MessageBox.Show($"Error: {response.StatusCode} , {a.message}", "Hiba!");
            }
        }
    }
}
