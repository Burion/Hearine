using MasterDetail.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MasterDetail.Services
{
    public static class DataStore
    {
        public static List<Album> Albums = new List<Album>();
        public static List<Playlist> Playlists = new List<Playlist>();
        public static List<StrippedTrackElement> Tracks;
        public static List<User> Users;
        public static List<Band> Bands;
        public static JsonSerializer jsonSerializer = JsonSerializer.Create();
        static DataStore()
        {
            Tracks = new List<StrippedTrackElement>
            {
                new StrippedTrackElement("Highway To Hell", "AC/DC", "01.mp3"),
                new StrippedTrackElement("Girls Got Rythm", "AC/DC", "02.mp3"),
                new StrippedTrackElement("Walk All Over You", "AC/DC", "03.mp3"),
                new StrippedTrackElement("Touch Too Much", "AC/DC", "04.mp3"),
                new StrippedTrackElement("Beating Around The Bush", "AC/DC", "05.mp3"),
                new StrippedTrackElement("Shoot Down In Flames", "AC/DC", "06.mp3"),
                new StrippedTrackElement("Get It Hot", "AC/DC", "07.mp3"),
                new StrippedTrackElement("If You Want Blood", "AC/DC", "08.mp3"),
                new StrippedTrackElement("Night Prowler", "AC/DC", "10.mp3"),
                new StrippedTrackElement("Love Hungry Man", "AC/DC", "09.mp3"),
                new StrippedTrackElement("Shoot To Thrill", "AC/DC", "shoot_to_thrill.mp3"),
                new StrippedTrackElement("Ride Of The Valkyries", "Richard Wagner", "wagner.mp3"),
                new StrippedTrackElement("Symphony #6 - Storm", "Beethoven", "beethoven.mp3"),
                new StrippedTrackElement("Symphony #6 - Storm", "Beethoven", "beethoven.mp3"),
                new StrippedTrackElement("Symphony #6 - Storm", "Beethoven", "beethoven.mp3"),
                new StrippedTrackElement("Symphony #6 - Storm", "Beethoven", "beethoven.mp3"),
                new StrippedTrackElement("Mercy Mercy", "The Rolling Stones", "r1.mp3"),
                new StrippedTrackElement("Hitch Hike", "The Rolling Stones", "r2.mp3"),
                new StrippedTrackElement("The Last Time", "The Rolling Stones", "r3.mp3"),
                new StrippedTrackElement("That's How Strong My Love Is", "The Rolling Stones", "r4.mp3"),
                new StrippedTrackElement("Good Times", "The Rolling Stones", "r5.mp3"),
                new StrippedTrackElement("I'm All Right", "The Rolling Stones", "r6.mp3"),
                new StrippedTrackElement("Satisfaction", "The Rolling Stones", "r7.mp3"),
                new StrippedTrackElement("Cry To Me", "The Rolling Stones", "r8.mp3"),
                new StrippedTrackElement("The Under Assistant West Coast Promotion Man", "The Rolling Stones", "r9.mp3"),
                new StrippedTrackElement("Play With Fire", "The Rolling Stones", "r10.mp3"),
                new StrippedTrackElement("The Spider And The Fly", "The Rolling Stones", "r11.mp3"),
                new StrippedTrackElement("One More Try", "The Rolling Stones", "r12.mp3"),
            };
            string jTracks = JsonConvert.SerializeObject(Tracks);
            //System.IO.File.Create("db.txt");
            //System.IO.File.WriteAllText("db.txt", jTracks);
            Album acdcAlbum = new Album("Highway To Hell", "ACDC.jpg", "AC/DC", 1979, Tracks.Where(x => x.Band == "AC/DC").OrderBy(y => y.Name).ToList());
            Album rollingAlbum = new Album("Out Of Our Hads", "ROLLINGSTONES.jpg", "The Rolling Stones", 1965, Tracks.Where(x => x.Band == "The Rolling Stones").OrderBy(y => y.Name).ToList());
            Albums.Add(acdcAlbum);
            Albums.Add(rollingAlbum);
            Albums.Add(acdcAlbum);
            Albums.Add(rollingAlbum);
            Albums.Add(acdcAlbum);
            Albums.Add(rollingAlbum);
            Albums.Add(acdcAlbum);
            Albums.Add(rollingAlbum);
            Albums.Add(acdcAlbum);
            Albums.Add(rollingAlbum);
            Albums.Add(acdcAlbum);
            Albums.Add(rollingAlbum);

            Playlist playlist;
            playlist = new Playlist(Tracks.Where(x => x.Band == "AC/DC").ToList(), "NewBand", "MyPlaylist", "Playlist.jpg", "My description");
            Playlists.Add(playlist);
        }

        public static void AddPlaylist(Playlist playlist)
        {
            Playlists.Add(playlist);
            //Console.WriteLine($"{playlists.Count}");
        }
    }
}
