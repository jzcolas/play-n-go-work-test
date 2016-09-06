using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GameStore.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        
        public string Rating { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
    }

    public class GameDBContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}