using System;
using System.Collections.Generic;
using System.Text;

namespace HotsHeroes.Models
{
    public class Hero
    {
        public string PrimaryName { get; set; }
        public string ImageURL { get; set; }
        public string AttributeName { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public string Translations { get; set; }
    }
}
