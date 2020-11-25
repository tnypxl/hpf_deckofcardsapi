using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace DeckOfCardsApi.Tests.Library
{
    public abstract class Endpoint
    {
        public IRestClient Client => RestClientFactory.Instance.UseNewtonsoftJson();

        public T Response<T>(RestRequest request)
        {
            IRestResponse<T> response = Client.Execute<T>(request);

            return response.Data;
        }
    }
}