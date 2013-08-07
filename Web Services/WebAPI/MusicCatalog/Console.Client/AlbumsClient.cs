using System;
using System.Linq;
using System.Net.Http;
using MusicCatalog.Models;

namespace ConsoleClient
{
    class AlbumsClient
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:1850/")
            };

            CRUD<Album> crudAlbums = new CRUD<Album>(client, "albums");
            //crudAlbums.GetAll(PrintAlbum);
            //crudAlbums.GetById(1, PrintAlbum);

            CRUD<Artist> crudArtists = new CRUD<Artist>(client, "Artists");
            //crudArtists.GetAll(PrintArtist);

            CRUD<Song> crudSongs = new CRUD<Song>(client, "Songs");
            //crudSongs.GetAll(PrintSong);

            CRUDXML<Album> crudXmlAlbums = new CRUDXML<Album>(client, "albums");
            crudXmlAlbums.GetAll();
            //crudXmlAlbums.Post(new Album()
            //{
            //    producer = "test producer xml",
            //    title = "test album xml",
            //    year = 1999
            //});
        }

        private static void PrintSong(Song song)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n{3}\r\n", song.title, song.year, song.Artist.name, song.Genre.name);

            Console.WriteLine("List albums: ");
            if (song.Albums.Count > 0)
            {
                foreach (var album in song.Albums)
                {
                    Console.WriteLine(album.title);
                }
            }
            else
            {
                Console.WriteLine("No albums.");
            }

            Console.WriteLine(new string('-', 20));
        }

        private static void PrintArtist(Artist artist)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n", artist.name, artist.DateOfBirth, artist.Country);

            Console.WriteLine("List songs: ");
            if (artist.Songs.Count > 0)
            {
                foreach (var song in artist.Songs)
                {
                    Console.WriteLine(song.Genre.name);
                    Console.WriteLine(song.title);
                }
            }
            else
            {
                Console.WriteLine("No songs.");
            }

            Console.WriteLine("List albums: ");
            if (artist.Albums.Count > 0)
            {
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine(album.title);
                }
            }
            else
            {
                Console.WriteLine("No albums.");
            }

            Console.WriteLine(new string('-', 20));
        }

        private static void PrintAlbum(Album album)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n", album.producer, album.year, album.title);

            Console.WriteLine("List songs: ");
            if (album.Songs.Count > 0)
            {
                foreach (var song in album.Songs)
                {
                    Console.WriteLine(song.Artist.name);
                    Console.WriteLine(song.Genre.name);
                    Console.WriteLine(song.title);
                }
            }
            else
            {
                Console.WriteLine("No songs.");
            }

            Console.WriteLine("List artists: ");
            if (album.Artists.Count > 0)
            {
                foreach (var artist in album.Artists)
                {
                    Console.WriteLine(artist.name);
                    Console.WriteLine(artist.Country);
                    Console.WriteLine(artist.DateOfBirth);
                }
            }
            else
            {
                Console.WriteLine("No artists.");
            }

            Console.WriteLine(new string('-', 20));
        }
    }
}
