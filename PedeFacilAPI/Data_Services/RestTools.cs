using Newtonsoft.Json;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PedeFacilAPI.Data_Services
{
    public class RestTools
    {
        private HttpClient client = new HttpClient();

        public async Task<List<Usuario>> Select(string controller, string parametro)
        {
            try
            {
                string url = "http://localhost:5345/" + controller + parametro;
                HttpResponseMessage response = await client.GetAsync(url);
                var teste = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Usuario>>(teste);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(Usuario objeto, string controller)
        {
            try
            {
                string url = "http://localhost:5345/" + controller;
                var uri = new Uri(string.Format(url, objeto));
                var data = JsonConvert.SerializeObject(objeto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Usuario objeto)
        {
            string url = "http://www.macwebapi.somee.com/api/produtos/{0}";
            var uri = new Uri(string.Format(url, objeto));
            var data = JsonConvert.SerializeObject(objeto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro");
            }
        }

        public async Task Delete(Usuario objeto)
        {
            string url = "http://www.macwebapi.somee.com/api/produtos/{0}";
            var uri = new Uri(string.Format(url, objeto));
            await client.DeleteAsync(uri);
        }
    }
}