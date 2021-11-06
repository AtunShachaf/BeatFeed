using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiCloud.Models
{
    public class TVShow
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Release_Date { get; set; }

        public string Genre { get; set; }

        public string ImageLink { get; set; }

        public string TVShowLink { get; set; }

        // FK from Director table
        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
    }
}