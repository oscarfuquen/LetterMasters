using System.Threading.Tasks;
using LetterMasters.BL;
using LetterMasters.Models;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{word}"), Authorize]
        public async Task<Word> Get(string word)
        {
            var wordModel = new Word {IsAValidWord = await _validateWord.IsAValidWord(word)};
            return wordModel;
        }
    }
}
