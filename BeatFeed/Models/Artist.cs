using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BeatFeed.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Genre { get; set; }

        public string ImageLink { get; set; }


        [DisplayName("ArtistLink")]
        public string AristLink {get; set;}
    }
}