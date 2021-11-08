using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeatFeed.Models;

namespace BeatFeed.Data
{
    public class BeatFeedContext : DbContext
    {
        public BeatFeedContext (DbContextOptions<BeatFeedContext> options)
            : base(options)
        {
        }

        public DbSet<BeatFeed.Models.User> User { get; set; }

        public DbSet<BeatFeed.Models.Playlist> Playlist { get; set; }

        public DbSet<BeatFeed.Models.Artist> Artist { get; set; }

        public DbSet<BeatFeed.Models.Concert> Concert { get; set; }

        public DbSet<BeatFeed.Models.Song> Song { get; set; }

        public DbSet<BeatFeed.Models.SongToPlaylist> SongToPlaylist { get; set; }

        public DbSet<BeatFeed.Models.Admin> Admin { get; set; }

        public DbSet<BeatFeed.Models.Album> Album { get; set; }

    }
}
