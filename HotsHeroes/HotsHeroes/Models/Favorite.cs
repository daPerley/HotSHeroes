using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotsHeroes.Models
{
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PrimaryName { get; set; }
        public string ImageURL { get; set; }
    }
}
