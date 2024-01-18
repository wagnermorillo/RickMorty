using Newtonsoft.Json;
using RickMorty.Models.Interface;
using RickMorty.Models.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickMorty.Models.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly string BASEURL = ConfigurationManager.AppSettings["BASEURL"];

        public async Task<Multiple<Character>> GetAll(int page = 1)
        {
            if (page < 1)
            {
                return new Multiple<Character>(); // puede cambiar al futuro
            }
            string URLFINAL = $"{BASEURL}/?page={page}";
            var json = await ApiRequest.RequestAsync(URLFINAL);
            return string.IsNullOrEmpty(json) ?
                new Multiple<Character>() :
                JsonConvert.DeserializeObject<Multiple<Character>>(json);
        }
        public async Task<Multiple<Character>> GetFilter(int page = 1, string name = null, string status = null, string species = null, string type = null, string gender = null)
        {
            var parameters = new List<string>
            {
                $"page={page}",
                name != null ? $"name={name}" : null,
                status != default ? $"status={status}" : null,
                species != null ? $"species={species}" : null,
                type != null ? $"type={type}" : null,
                gender != default ? $"gender={gender}" : null
            };
            string URLFINAL = $"{BASEURL}/?{string.Join("&", parameters.Where(p => p != null))}";
            var json = await ApiRequest.RequestAsync(URLFINAL);
            return string.IsNullOrEmpty(json) ?
                new Multiple<Character>() :
                JsonConvert.DeserializeObject<Multiple<Character>>(json);

        }

        public async Task<Character> GetById(int id)
        {
            string URLFINAL = $"{BASEURL}/{id}";
            var json = await ApiRequest.RequestAsync(URLFINAL);
            return string.IsNullOrEmpty(json) ?
                new Character() :
                JsonConvert.DeserializeObject<Character>(json);
        }


        public async Task<IEnumerable<Character>> GetMultiple(params int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return Enumerable.Empty<Character>();
            }

            string URLFINAL = $"{BASEURL}/{string.Join(",", ids)}";
            var json = await ApiRequest.RequestAsync(URLFINAL);

            return string.IsNullOrEmpty(json) ?
                Enumerable.Empty<Character>() :
                JsonConvert.DeserializeObject<IEnumerable<Character>>(json).ToList();
        }

    }
}
