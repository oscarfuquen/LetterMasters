using System.Threading.Tasks;

namespace LetterMasters.BL
{
    public interface IValidateWord
    {
        Task<bool> IsAValidWord(string word);
    }
}