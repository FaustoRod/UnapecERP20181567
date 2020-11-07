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
    public class ProveedorService:IBaseWebPoster<Proveedor>
    {
        public async Task<bool> Create(Proveedor entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PostAsync("/api/Provedor/Crear/", byteContent);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Update(Proveedor entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PutAsync($"/api/Provedor", byteContent);
            return result.IsSuccessStatusCode;

        }

        public async Task<bool> Delete(int id)
        {
            var result = await WebApiClient.Instance.DeleteAsync(string.Format($"/api/Provedor/{id}"));
            return result.IsSuccessStatusCode;

        }

        public async Task<Proveedor> GetSingle(int id)
        {
            var result = await WebApiClient.Instance.GetAsync($"/api/Provedor/{id}");
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Proveedor>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                MessageBox.Show(result.StatusCode.ToString());
                return null;
            }
        }

        public async Task<IList<Proveedor>> GetAll()
        {
            var result = await WebApiClient.Instance.GetAsync($"/api/Provedor");
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IList<Proveedor>>(await result.Content.ReadAsStringAsync());
            }

            MessageBox.Show(result.StatusCode.ToString());
            return null;
        }
        public async Task<IList<Proveedor>> SearchAll(ProvedorSearchDto provedorSearch)
        {
            var content = JsonConvert.SerializeObject(provedorSearch);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await WebApiClient.Instance.PostAsync("/api/Provedor/Search/", byteContent);
            return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IList<Proveedor>>(await result.Content.ReadAsStringAsync()) : new List<Proveedor>();
        }
    }
}