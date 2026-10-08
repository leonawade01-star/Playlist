using Microsoft.AspNetCore.Mvc;

namespace Playlist.Controllers
{
    public class PlaylistController : Controller
    {
        private string[] songs =
        {
            "Always n Forever - Mariah The Scientist",
            "Ivy - Frank Ocean",
            "Sparks - Coldplay",
            "Reflections - The Neighborhood",
            "Hold On, We're Going Home - Drake",
            "Born to Die - Lana Del Rey"
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Liner-notes")]
        public IActionResult Notes()
        {
            return View();
        }

        [HttpGet("track/{number:int:range(1,6)=1}")]
        public IActionResult Track(int number = 1)
        {

            if (number > 1)
            {
                ViewData["Previous"] = number - 1;
            }

            if (number < 6)
            {
                ViewData["Next"] = number + 1;
            }
            ViewData["Number"] = number;
            ViewData["Item"] = songs[number - 1];
            return View();
        }

        [HttpGet("find/{word:alpha}")]
        public IActionResult Find(string word)
        {
            ViewData["Word"] = word;
            for (int i = 0; i < songs.Length; i++)
            {
                if (songs[i].ToLower().Contains(word.ToLower()))
                {
                    ViewData["Song"] = songs[i];
                    ViewData["Number"] = i + 1;
                    return View();
                }
            }

            return View();
        }
        [HttpGet("find/{**word}")]
        public IActionResult FindInvalid(string word)
        {
            ViewData["Word"] = word;
            return View("InvalidSearch");
        }
    }
}
