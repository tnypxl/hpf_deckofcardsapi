using System;
using DeckOfCardsApi.Tests.Endpoints;
using NUnit.Framework;

namespace DeckOfCardsApi.Tests
{
    public class DeckEndpointTests : TestBase
    {
        public Deck DeckEndpoint;

        [SetUp]
        public void Setup()
        {
            DeckEndpoint = new Deck();
        }

        [TestCase]
        public void ShouldReturnNewDeckOfCardsWithoutJokers()
        {
            var response = DeckEndpoint.CreateNewDeck();

            Assert.That(response.Remaining, Is.EqualTo(52));
        }

        [TestCase]
        public void ShouldReturnNewDeckOfCardsWithJokers()
        {
            var response = DeckEndpoint.CreateNewDeck(true);

            Assert.That(response.Remaining, Is.EqualTo(54));
        }

        [TestCase]
        public void ShouldDrawSingleCardByDefault()
        {
            var deckId = DeckEndpoint.CreateNewDeck().DeckId;
            var response = DeckEndpoint.DrawCard(deckId);

            Assert.That(response.Cards.Count, Is.EqualTo(1));
        }

        [TestCase(3)]
        public void ShouldDrawMultipleCards(int numberOfCards)
        {
            var deckId = DeckEndpoint.CreateNewDeck().DeckId;
            var response = DeckEndpoint.DrawMultipleCards(deckId, numberOfCards);

            Assert.That(response.Cards.Count, Is.EqualTo(numberOfCards));
        }
    }
}