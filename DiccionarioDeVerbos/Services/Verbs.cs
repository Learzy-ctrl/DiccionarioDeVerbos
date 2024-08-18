using DiccionarioDeVerbos.Infrastructure;
using DiccionarioDeVerbos.Models;
using Newtonsoft.Json;
using System.Text;

namespace DiccionarioDeVerbos.Services
{
    public class Verbs : IVerbs
    {
        private readonly HttpClient _httpClient;

        public Verbs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SearchVerb(VerbDto data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Verbs", content);
            var responseData =  await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseData>(responseData);
            if(result != null)
            {
                var verb = result.verb;
                return verb;
            }
            return "Verbo no encontrado";
        }
    }
}
