using RickMorty.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RickMorty.Models.Interface
{
    public interface ICharacterRepository
    {
        Task<Multiple<Character>> GetAll(int page);
        Task<IEnumerable<Character>> GetMultiple(params int[] ids);
        Task<Character> GetById(int id);
        Task<Multiple<Character>> GetFilter(int page, string name, string status, string species, string type, string gender);

    }
}
