using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using UnapecERPApp.Interfaces;
using UnapecERPApp.Utils;
using UnapecErpData.Dto;
using UnapecErpData.Model;

namespace UnapecERPApp.Services
{
    public class DocumentoService:IBaseWebPoster<Documento>
    {
        public async Task<bool> Pagar(int id)
        {
            //var content = JsonConvert.SerializeObject(id);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //var byteContent = new ByteArrayContent(buffer);
            //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PostAsync($"/api/Documento/Pagar/{id}", null);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Create(Documento entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PostAsync("/api/Documento/Crear/", byteContent);
            return result.IsSuccessStatusCode;
        }

        public Task<bool> Update(Documento entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Documento> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Documento>> GetAll()
        {
            var result = await WebApiClient.Instance.GetAsync($"/api/Documento");
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IList<Documento>>(await result.Content.ReadAsStringAsync());
            }

            MessageBox.Show(result.StatusCode.ToString());
            return null;
        }
        public async Task<IList<Documento>> Search(DocumentSearchDto entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PostAsync("/api/Documento/Buscar/", byteContent);
            return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IList<Documento>>(await result.Content.ReadAsStringAsync()) : null;
        }
    }
}