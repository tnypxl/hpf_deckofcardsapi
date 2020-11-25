using DeckOfCardsApi.Tests.Library;
using NUnit.Framework;

namespace DeckOfCardsApi.Tests
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            RestClientFactory.Create("https://deckofcardsapi.com/api");
        }
    }
}