using RestSharp;

namespace Unit_7_Deck_Of_Cards_API_Lab.Models
{
    public class DeckDAL
    {
        public Deck NewDeck()
        {
            string URL = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest();
            Deck response = client.Get<Deck>(request);
            return response;            
        }
        public CardResults DrawCard(string DeckID)
        {
            string URL = $"https://deckofcardsapi.com/api/deck/{DeckID}/draw/?count=5";
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest();
            CardResults response = client.Get<CardResults>(request);
            return response;
        }
    }
}
