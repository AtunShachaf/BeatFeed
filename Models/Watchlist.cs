using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiCloud.Models
{
    public class Watchlist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int ImageId { get; set; }

        // FK from Episode table
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
