using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnapecERPApp.Interfaces;
using UnapecERPApp.Utils;
using UnapecErpData.Model;

namespace UnapecERPApp.Services
{
    public class DocumentoService:IBaseWebPoster<Documento>
    {
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

        public Task<IList<Documento>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}