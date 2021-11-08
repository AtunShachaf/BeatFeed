using BeatFeed.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatFeed.Data
{
    public static class DBInit
    {

        public static void Seed(BeatFeedContext _context)
        {
            Random rnd = new Random();
            // -------------------------- User Table-----------------------------------------------            
            string[] userDisplayNames = { "Admin", "Shachaf", "Yarden", "Idan", "User"};

            string[] userEmails = { "Admin@Beatfeed.com", "Shachaf@gmail.com", "Yarden@gmail.com", "Idan.Nitz@gmail.com", "User@gmail.com" };

            //password = aA123456!
            string[] userPasswords = { "6cddcf2697233484f141856251e6fff5d02bc00d", "6cddcf2697233484f141856251e6fff5d02bc00d", "6cddcf2697233484f141856251e6fff5d02bc00d", "6cddcf2697233484f141856251e6fff5d02bc00d", "6cddcf2697233484f141856251e6fff5d02bc00d" };

            string[] userTypes = { "Admin", "Admin", "Admin", "Admin", "User" };

            if (!_context.User.Any())
            {
                for (int i = 0; i < userEmails.Length; i++)
                {
                    User user = new User()
                    {
                        DisplayName = userDisplayNames[i],
                        Email = userEmails[i],
                        Password = userPasswords[i],
                        UserType = userTypes[i]
                    };

                    _context.Add(user);
                    _context.SaveChanges();

                }
            }

            // --------------------------------------------------------------------------------------


            // --------------------------Artist Table-----------------------------------------------

            string[] artistNames = { "Linkin Park", "Adele", "Ed Sheeran", "Rihanna"}; ;

            string[] artistGenres = { "Rock, Alternative Rock, Electronic Rock, Metal, Rap", "Pop, R&B, Pop-Soul", "Pop, Hip Hop, Soft Rock", "Pop, R&B, Reggae, Dubstep, Hip Hop" };

            string[] artistImageLinks = { "/images/artists/Linkin-Park/linkinpark.jpg",
                                          "/images/artists/Adele/adele.jpg",
                                          "/images/artists/Ed-Sheeran/ed.jpg",
                                          "/images/artists/Rihanna/rihanna.jpg"};

            string[] artistArtistLinks = {  "Linkin Park is an American rock band from Agoura Hills, California. </br> The band's current lineup comprises vocalist/rhythm guitarist/keyboardist Mike Shinoda, lead guitarist Brad Delson, bassist Dave Farrell, DJ/turntablist Joe Hahn and drummer Rob Bourdon, all of whom are founding members. Vocalists Mark Wakefield and Chester Bennington are former members of the band. Categorized as alternative rock, Linkin Park's earlier music spanned a fusion of heavy metal and hip hop, while their later music features more electronica and pop elements.",
                                            "Adele Laurie Blue Adkins MBE (born 5 May 1988) is an English singer and songwriter. She is one of the world's best-selling music artists, with sales of over 120 million records.",
                                            "Edward Christopher Sheeran MBE (/ˈʃɪərən/; born 17 February 1991) is an English singer-songwriter. He has sold more than 150 million records worldwide, making him one of the world's best-selling music artists.[6] He has 84.5 million RIAA-certified units in the US, and two of his albums are in the list of the best-selling albums in UK chart history. In December 2019, the Official Charts Company named him artist of the decade, with the most combined success in the UK album and singles charts in the 2010s",
                                            "Robyn Rihanna Fenty (born February 20, 1988), known professionally as Rihanna, is a Barbadian singer, actress, fashion designer, and businesswoman. Born in Saint Michael and raised in Bridgetown, Barbados, Rihanna was discovered by American record producer Evan Rogers who invited her to the United States to record demo tapes. After signing with Def Jam in 2005, she soon gained recognition with the release of her first two studio albums, Music of the Sun (2005) and A Girl Like Me (2006), both of which were influenced by Caribbean music and peaked within the top ten of the US Billboard 200 chart."
                                          };

            if (!_context.Artist.Any())
            {
                for (int i = 0; i < artistNames.Length; i++)
                {
                    Artist artist = new Artist()
                    {
                        Name = artistNames[i],
                        Genre = artistGenres[i],
                        ImageLink = artistImageLinks[i],
                        AristLink = artistArtistLinks[i]
                    };

                    _context.Add(artist);
                    _context.SaveChanges();

                }
            }

            // ------------------------------------------------------------------------------------

            // --------------------------Concert Table-----------------------------------------------
            /* Linkin Park
               Adele
               Ed Sheeran
               Rihanna*/
            string[] names = { "Chester Bennington Tribute Concert", "Rock Werchter 2017", "Bråvalla Festival 2017",
                               "Adele", "Adele", "Adele", "Adele",
                               "Divide Tour", "The Mathematics Tour", "Radio City Hits Live 2021", "The Mathematics Tour",
                               "Anti World Tour", "Rihanna", "Samir Geribov", "Rihanna" };
            int[] concertArtistID = { 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4 };
            double[] lats = { 34.11188, 50.969394, 58.606281,
                              51.556025, 51.503038, 51.507268, 34.043018,
                              52.053098, 53.360712, 53.397168, 48.207208,
                              24.481342, 1.291432, 40.344226, 55.859631};
            double[] longs = { -118.337289, 4.686618, 16.117368,
                               -0.279618, 0.003154, -0.16573, -118.267254,
                               1.119913, -6.251209, -2.990845, 16.420985,
                               54.605451, 103.86391, 49.85028, -4.287709};
            string[] countries = { "United States", "Belgium", "Sweden",
                                   "UK", "UK", "UK", "United States",
                                   "UK", "Ireland", "UK", "Austria",
                                   "Abu Dhabi", "Singapore", "Azerbaijan", "UK"
                                   };
            string[] cities = { "Los Angeles", "Rotselaar", "Norrköping",
                                "London", "London", "London", "Los Angeles",
                                "Ipswitch", "Dublin", "Liverpool", "Vienna",
                                "Yas Island","Singapore", "Baku", "Glasgow"};
            string[] addresses = { "6801 Hollywood Blvd, Hollywood, CA", "Haachtsesteenweg 13/9", "Lansengatan 40",
                                   "Wembley Stadium", "The O2", "Hyde Park", "STAPLES Center",
                                   "Chantry Park, Hadleigh Rd", "Jones' Rd, Drumcondra", "King's Dock, Port of Liverpool, Kings Dock St", "Ernst Happel Stadion",
                                   "Du Arena", "Marina Bay", "Sabail District, Settlement, National Flag Square", "Exhibition Way" };
            string[] descriptions = { "Line-up: blink-182, Zedd, Linkin Park, Bebe Rexha, Steve Aoki, Machine Gun Kelly, No Doubt, Alanis Morissette, Gavin Rossdale, Orgy, and more",
                                      "Line-up: Imagine Dragons, Radiohead, Foo Fighters, The Chainsmokers, blink-182, The Lumineers, Arcade Fire, G-Eazy, alt-J, Linkin Park, and more",
                                      "Line-up: The Killers, Ellie Goulding, Travis Scott, Linkin Park, System of a Down, Martin Garrix, Passenger, Mac Miller, Alesso, Die Antwoord, and more",

                                      "",
                                      "",
                                      "Price: £74.95 – £399.95\nDoors open: 14:00\nCapacity: 150,000",
                                      "",

                                      "",
                                      "",
                                      "Ed Sheeran has announced his ‘+ - = ÷ x Tour’ (pronounced ‘The Mathematics Tour’), taking place in stadiums throughout 2022. Kicking off in April next year, the tour will see Ed play shows across Ireland, the UK, Central Europe and Scandinavia, and will see him return to London’s Wembley Stadium for three nights in June/July. General sale for all territories commences on Saturday 25th September",
                                      "",

                                      "For fans of: R&B, Pop, Reggae, and Hip-Hop.",
                                      "",
                                      "Capacity: 25,000\nFor fans of: R & B, Pop, Reggae, and Hip-Hop",
                                      "Capacity: 12,500\nFor fans of: R & B, Pop, Reggae, and Hip-Hop."




            };
            string[] dates = {"27 October 2017", "29 June 2017", "28 June 2017",
                              "01 July 2017", "19 March 2016", "01 July 2022", "05 August 2016",
                              "Aug 25, 2019", "23 April 2022", "19 November 2021", "02 September 2022",
                              "27 November 2016", "22 September 2013" , "06 October 2012", "10 October 2011" } ;


            if (!_context.Concert.Any())
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Concert concert = new Concert()
                    {
                        Name = names[i],
                        ArtistId = concertArtistID[i],
                        Date = DateTime.Parse(dates[i]),
                        Lat = lats[i],
                        Long = longs[i],
                        Country = countries[i],
                        City = cities[i],
                        AddressName = addresses[i],
                        Description = descriptions[i],
                    };

                    _context.Add(concert);
                    _context.SaveChanges();

                }
            }

            // -------------------------------------------------------------------------------------


            // --------------------------Album Table-----------------------------------------------

            string[] albumNames = { "Hybrid Theory", "21", "Divide",
                                    "Loud" };

            string[] albumGenres = { "Rock, Nu Metal, Rap Metal, Rap Rock, Hard Rock", "Soul, Pop, R&B", "Pop", "Dance-Pop, R&B" };

            string[] albumImageLinks = { "/images/albums/Hybrid-Theory/hybridtheory.jpg",
                                         "/images/albums/21/21.jpg",
                                         "/images/albums/Divide/divide.jpg",
                                         "/images/albums/Loud/loud.jpg"};

            string[] albumAlbumLinks = { "Hybrid Theory (stylized as [HYBRID THEORY]) is the debut studio album by American rock band Linkin Park, released on October 24, 2000 by Warner Bros. Records. Produced by Don Gilmore, it was recorded at NRG Recording Studios in North Hollywood, California, during 1998, 1999 and 2000 Its lyrical themes deal with problems the band's lead singer Chester Bennington experienced during adolescence, including drug abuse and the conflict and divorce of his parents. The album takes its title from the previous name of the band, as well as the concept of music theory and combining different styles of genres.",
                                         "21 is the second studio album by English singer-songwriter Adele. It was released on 24 January 2011 in Europe by XL Recordings and on 22 February 2011 in North America by Columbia Records. The album was named after the age of the singer during its production. the album typifies the near dormant tradition of the confessional singer-songwriter in its exploration of heartbreak, introspection, and forgiveness.",
                                         "÷ (\"Divide\") is the third studio album by English singer-songwriter Ed Sheeran. It was released on 3 March 2017 through Asylum Records and Atlantic Records. \"Castle on the Hill\" and \"Shape of You\" were released as the album's lead singles on 6 January 2017. The album won the Grammy Award for Best Pop Vocal Album at the 60th Annual Grammy Awards.",
                                         "Album Link - Loud is the fifth studio album by Barbadian singer Rihanna. It was released on November 12, 2010, by Def Jam Recordings and SRP Records. The album was recorded between February and August 2010, during the singer's Last Girl on Earth tour and the filming of her first feature film Battleship (2012). The album features several guest vocalists, including rappers Drake, Nicki Minaj and Eminem, who is featured on the sequel to \"Love the Way You Lie\", titled \"Love the Way You Lie (Part II)\" "};


            int[] albumArtistIds = { 1, 2, 3, 4 };

            if (!_context.Album.Any())
            {
                for (int i = 0; i < albumNames.Length; i++)
                {
                    Album album = new Album()
                    {
                        Name = albumNames[i],
                        Release_Date = DateTime.Now,
                        Genre = albumGenres[i],
                        ImageLink = albumImageLinks[i],
                        AlbumLink = albumAlbumLinks[i],
                        ArtistId = albumArtistIds[i]
                    };

                    _context.Add(album);
                    _context.SaveChanges();

                }
            }

            // -----------------------------------------------------------------------------------------


            // --------------------------Song Table-----------------------------------------------

            string[] songNames = {  
                //Linkin Park (Total 12 Songs.)
                "Papercut", "One Step Closer", "With You", "Points of Authority", "Crawling",
                "Runaway", "By Myself", "In the End", "A Place for My Head", "Forgotten",
                "Cure for the Itch", "Pushing Me Away",
                
                //Adele (Total 12 Songs.)
                
                "Rolling in the Deep", "Rumour Has It","Turning Tables", "Don’t You Remember",
                "Set Fire to the Rain", "He Won’t Go", "Take It All", "I’ll Be Waiting",
                "One and Only", "Lovesong", "Someone Like You", "I Found a Boy",

                //Ed Sheeran (Total 12 Songs)
                "Eraser", "Castle on the Hill", "Dive", "Shape of You", "Perfect", "Galway Girl",
                "Happier","Hearts Don’t Break Around Here", "New Man", "What Do I Know?",
                 "How Would You Feel (Paean)", "Supermarket Flowers",

                //Rihanna (Total 11 Songs)
                "S&M", "What’s My Name (Feat. Drake)", "Cheers (Drink to that)", "Fading", "Only Girl (In the world)",
                "California King Bed", "Man Down",  "Raining Men (Feat. Nicki Minaj)", "Complicated",
                "Skin", "Love the way you lie (Feat. Eminem) (Part II)"};

            int[] songCountersPlay = new int[47];
            for (int i = 0; i < 47; i++)
                songCountersPlay[i] = rnd.Next(1, 1000);

            string[] videoLinks =
            {
                //Linkin Park
                "https://www.youtube.com/watch?v=vjVkXlxsO8Q",
                "https://www.youtube.com/watch?v=4qlCC1GOwFw",
                "https://www.youtube.com/watch?v=mCE334O4yhU",
                "https://www.youtube.com/watch?v=GgxcvmkPD-I",
                "https://www.youtube.com/watch?v=Gd9OhYroLN0",
                "https://www.youtube.com/watch?v=voS1wrD7NP4",
                "https://www.youtube.com/watch?v=ZrylHpa8f60",
                "https://www.youtube.com/watch?v=eVTXPUF4Oz4",
                "https://www.youtube.com/watch?v=hM50nXcfQSA",
                "https://www.youtube.com/watch?v=6hLLZfnulSU",
                "https://www.youtube.com/watch?v=qqC5sdsHLq8",
                "https://www.youtube.com/watch?v=0uLcI-eNR2U",
                
                //Adele
                "https://www.youtube.com/watch?v=rYEDA3JcQqw",
                "https://www.youtube.com/watch?v=uK3MLlTL5Ko",
                "https://www.youtube.com/watch?v=NBq0d06_bdo",
                "https://www.youtube.com/watch?v=TmJ8wXJ9y3A",
                "https://www.youtube.com/watch?v=d9bB8csLSug",
                "https://www.youtube.com/watch?v=Qgp7hlkfstI",
                "https://www.youtube.com/watch?v=k7qotHNvpkU",
                "https://www.youtube.com/watch?v=h2NFIDnUBi8",
                "https://www.youtube.com/watch?v=x4r-c4I_9Rc",
                "https://www.youtube.com/watch?v=mnH9FHfD0Zg",
                "https://www.youtube.com/watch?v=hLQl3WQQoQ0",
                "https://www.youtube.com/watch?v=RnOh_0Qapg4",
                //Ed Sheeran
                "https://www.youtube.com/watch?v=J5TOQ69dlec",
                "https://www.youtube.com/watch?v=K0ibBPhiaG0",
                "https://www.youtube.com/watch?v=Wnn4sce2hks",
                "https://www.youtube.com/watch?v=JGwWNGJdvx8",
                "https://www.youtube.com/watch?v=2Vv-BfVoq4g",
                "https://www.youtube.com/watch?v=87gWaABqGYs",
                "https://www.youtube.com/watch?v=iWZmdoY1aTE",
                "https://www.youtube.com/watch?v=nQ1OB0Aukck",
                "https://www.youtube.com/watch?v=fxxCMZReVxI",
                "https://www.youtube.com/watch?v=Somv3cMp6zs",
                "https://www.youtube.com/watch?v=wY473jAptyw",
                "https://www.youtube.com/watch?v=3Mk0F6mLKik",
                //Rihanna
                "https://www.youtube.com/watch?v=KdS6HFQ_LUc",
                "https://www.youtube.com/watch?v=U0CGsw6h60k",
                "https://www.youtube.com/watch?v=ZR0v0i63PQ4",
                "https://www.youtube.com/watch?v=MBLuiE7qZ7c",
                "https://www.youtube.com/watch?v=pa14VNsdSYM",
                "https://www.youtube.com/watch?v=nhBorPm6JjQ",
                "https://www.youtube.com/watch?v=sEhy-RXkNo0",
                "https://www.youtube.com/watch?v=izo-09kA0eE",
                "https://www.youtube.com/watch?v=Pp8ZjzOmbDM",
                "https://www.youtube.com/watch?v=IudFHngr37Y",
                "https://www.youtube.com/watch?v=ypvJZRRA6ZI"
            };


            string[] songLinksToPlays = new string[47];
            int[] songAlbumIds = new int[47];
            for (int j = 0; j < 4; j++) // 0 - Linkin, 1 - Adele, 2 - Ed, 3 - Rihanna
            {
                for (int i = 0; i < 12; i++)
                {
                    if (j == 3 && i == 11) continue;
                    string temp = "/songs/" + artistNames[j].Replace(" ", "-") + '/' + albumNames[j].Replace(" ", "-") + '/' + songNames[i + j * 12].Replace(" ", "").Replace("’", "").Replace("?","") + ".mp3";
                    songLinksToPlays[i + j * 12] = temp;
                    songAlbumIds[i + j * 12] = j+1;
                    
                }
            }

            
            if (!_context.Song.Any())
            {
                for (int i = 0; i < songNames.Length; i++)
                {
                    Song song = new Song()
                    {
                        Name = songNames[i],
                        CounterPlayed = songCountersPlay[i],
                        LinkToPlay = songLinksToPlays[i],
                        AlbumId = songAlbumIds[i],
                        ClipURL = videoLinks[i]
                    };

                    _context.Add(song);

                }
                    _context.SaveChanges();
            }

            // -----------------------------------------------------------------------------------------
        }
    }
}