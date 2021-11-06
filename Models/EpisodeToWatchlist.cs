using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiCloud.Models
{
    public class EpisodeToWatchlist
    {

        public int Id { get; set; }

        // FK from Watchlist table
        [ForeignKey("Watchlist")]
        public int WatchlistId { get; set; }
        public virtual Watchlist Watchlist { get; set; }

        // FK from Episode table
        [ForeignKey("Episode")]
        public int EpisodeId { get; set; }
        public virtual Episode Episode { get; set; }
    }
}
