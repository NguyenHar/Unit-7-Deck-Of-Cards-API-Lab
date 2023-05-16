using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unit_7_Deck_Of_Cards_API_Lab.Models;

namespace Unit_7_Deck_Of_Cards_API_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static DeckDAL deckAPI = new DeckDAL();
        private static Deck deck = deckAPI.NewDeck();
        private static List<Card> drawnCards = deckAPI.DrawCard(deck.deck_id, 5).cards.ToList();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(drawnCards);
        }
        public IActionResult GenerateDeck()
        {
            deck = deckAPI.NewDeck();
            drawnCards = deckAPI.DrawCard(deck.deck_id, 5).cards.ToList();
            return RedirectToAction("Index");
        }
        public IActionResult DrawNext(int[] cards)
        {
            List<int> toReplace = cards.ToList();
            List<int> toRemove = new List<int>();
            for (int i=0; i<drawnCards.Count; i++)
            {   // Make it so checked items are unaffected
                if (!toReplace.Contains(i))
                {
                    CardResults result = deckAPI.DrawCard(deck.deck_id, 1);
                    if (result.cards.Length != 0)
                        drawnCards[i] = result.cards[0];
                    else
                        toRemove.Insert(0, i);
                }
            }
            foreach (int i in toRemove)
            {
                if (drawnCards.Count != 0)
                    drawnCards.RemoveAt(i);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}