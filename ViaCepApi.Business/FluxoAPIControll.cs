using RestSharp;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Text.Json.Serialization;
using ViaCepAPI.Models.API.Saida;

namespace ViaCepApi.Business
{
    public class FluxoAPIControll
    {
        public Endereco ConectaAPI(string cep)
        {
            var urlBase = $"https://viacep.com.br/ws/{cep}/json";
            var uri = new Uri(urlBase, UriKind.Absolute);
            
            var client = new RestClient(uri.AbsoluteUri);
            var request = new RestRequest(uri.AbsoluteUri, Method.Get);

            var response = client.Execute(request);
            var content = response.Content;

            var retorno = JsonSerializer.Deserialize<Endereco>(content);

            return retorno;
        }
    }
}
