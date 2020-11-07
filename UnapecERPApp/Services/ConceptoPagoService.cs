using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using UnapecERPApp.Interfaces;
using UnapecERPApp.Utils;
using UnapecErpData.Model;

namespace UnapecERPApp.Services
{
    public class ConceptoPagoService:IBaseWebPoster<ConceptoPago>
    {
        public async Task<bool> Create(ConceptoPago entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PostAsync("/api/ConceptoPago/Crear", byteContent);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Update(ConceptoPago entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PutAsync($"/api/ConceptoPago", byteContent);
            return result.IsSuccessStatusCode;

        }

        public async Task<bool> Delete(int id)
        {
            var result = await WebApiClient.Instance.DeleteAsync(string.Format($"/api/ConceptoPago/{id}"));
            return result.IsSuccessStatusCode;

        }

        public async Task<ConceptoPago> GetSingle(int id)
        {
            var result = await WebApiClient.Instance.GetAsync($"/api/ConceptoPago/{id}");
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ConceptoPago>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                MessageBox.Show(result.StatusCode.ToString());
                return null;
            }
        }

        public async Task<IList<ConceptoPago>> GetAll()
        {
            var result = await WebApiClient.Instance.GetAsync($"/api/ConceptoPago");
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IList<ConceptoPago>>(await result.Content.ReadAsStringAsync());
            }

            MessageBox.Show(result.StatusCode.ToString());
            return null;
        }
    }
}