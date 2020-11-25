using RestSharp;

namespace DeckOfCardsApi.Tests.Library
{
    public static class RestClientFactory
    {
        public static IRestClient Instance;

        public static void Create(string url)
        {
            Instance = new RestClient(url);
        }
    }
}