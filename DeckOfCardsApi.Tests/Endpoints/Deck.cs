using System.Collections.Generic;
using DeckOfCardsApi.Tests.Library;
using Newtonsoft.Json;
using RestSharp;

namespace DeckOfCardsApi.Tests.Endpoints
{
    public class Deck : Endpoint
    {
        public NewDeckResponse CreateNewDeck(bool jokersEnabled = false)
        {
            var request = new RestRequest("deck/new", Method.GET);

            if (jokersEnabled)
                request.AddQueryParameter("jokers_enabled", "true");

            return Response<NewDeckResponse>(request);
        }

        public DrawCardResponse DrawCard(string deckId)
        {
            var request = new RestRequest($"deck/{deckId}/draw", Method.GET);

            return Response<DrawCardResponse>(request);
        }

        public DrawCardResponse DrawMultipleCards(string deckId, int numberOfCards)
        {
            var request = new RestRequest($"deck/{deckId}/draw/?count={numberOfCards}", Method.GET);

            return Response<DrawCardResponse>(request);
        }
    }

    public class NewDeckResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("deck_id")]
        public string DeckId { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }

        [JsonProperty("shuffled")]
        public bool Shuffled { get; set; }
    }

    public class DrawCardResponse
    {
        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("cards")]
        public List<CardListItem> Cards;

        [JsonProperty("deck_id")]
        public string DeckId;

        [JsonProperty("remaining")]
        public int Remaining;
    }

    public class CardListItem
    {
        [JsonProperty("image")]
        public string Image;

        [JsonProperty("value")]
        public string Value;

        [JsonProperty("suit")]
        public string Suit;

        [JsonProperty("code")]
        public string Code;
    }

}