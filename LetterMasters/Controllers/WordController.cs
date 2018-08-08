using LetterMasters.BL;
using Microsoft.AspNetCore.Mvc;

namespace LetterMasters.Controllers
{
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private readonly IValidateWord _validateWord;
        public WordController(IValidateWord validateWord)
        {
            _validateWord = validateWord;
        }

        // GET api/word/5
        [HttpGet("{word}")]
        public bool Get(string word)
        {
            return _validateWord.IsAValidWord(word);
        }
    }
}
