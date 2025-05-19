using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2025._05._19.WPFdolgozat
{
    public class ServerConnection
    {
        private HttpClient client = new HttpClient();
        private string baseURL = "";
        public ServerConnection(string url)
        {
            baseURL = url;
        }
        public async Task<List<Mushroom>> GetGomba()
        {
            List<Mushroom> all = new List<Mushroom>();
            string url = baseURL + "/gomba";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseInString = await response.Content.ReadAsStringAsync();
                all = JsonConvert.DeserializeObject<List<Mushroom>>(responseInString);      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return all;
        }
    }
}
