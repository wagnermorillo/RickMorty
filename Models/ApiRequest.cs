using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickMorty.Models
{
    internal static class ApiRequest
    {
        public static async Task<string> RequestAsync(string URL)
        {
            if (string.IsNullOrEmpty(URL) || (!Uri.IsWellFormedUriString(URL, UriKind.Absolute)))
            {
                return null;
            }
            using (HttpClient client = new HttpClient()) 
            {
                try
                {
                    HttpResponseMessage message = await client.GetAsync(URL);
                    message.EnsureSuccessStatusCode();
                    return await message.Content.ReadAsStringAsync();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
