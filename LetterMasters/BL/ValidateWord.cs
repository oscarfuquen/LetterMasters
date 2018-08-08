using System.Text.RegularExpressions;

namespace LetterMasters.BL
{
    public class ValidateWord : IValidateWord
    {
        public bool IsAValidWord(string word)
        {
            Regex r = new Regex("^[a-zA-Z]*$");
            return r.IsMatch(word);
        }
    }
}
