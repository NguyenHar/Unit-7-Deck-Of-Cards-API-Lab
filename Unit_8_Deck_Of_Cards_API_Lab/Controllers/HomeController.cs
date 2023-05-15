using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unit_8_Deck_Of_Cards_API_Lab.Models;

namespace Unit_8_Deck_Of_Cards_API_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DeckDAL deckAPI = new DeckDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Deck deck = deckAPI.NewDeck();
            List<Card> drawnCards = deckAPI.DrawCard(deck.deck_id).cards.ToList();
            return View(drawnCards);
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