using System.Collections.Generic;

namespace RickMorty.Models.Models
{
    public class Multiple<T> 
    {
        public Info Info { get; set; }
        public IEnumerable<T> Results { get; set; }
        
    }
}
