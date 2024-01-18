using System;
using System.Collections.Generic;


namespace RickMorty.Models.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string? Type { get; set; } // can be null
        public string Gender { get; set; }
        public Location Origin { get; set; }
        public Location Location { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Episode { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
