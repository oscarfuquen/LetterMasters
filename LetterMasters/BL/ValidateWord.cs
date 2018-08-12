using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LetterMasters.BL
{
    public class ValidateWord : IValidateWord
    {
        public async Task<bool> IsAValidWord(string word)
        {
            var r = new Regex("^[a-zA-Z]*$");
            return await Task.Run(() => r.IsMatch(word));
        }
    }
}
