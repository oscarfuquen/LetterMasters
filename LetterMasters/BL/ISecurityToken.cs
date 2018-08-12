using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace LetterMasters.BL
{
    public interface ISecurityToken
    {
        Task<string> GetJwtSecurityToken();
    }
}