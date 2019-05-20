using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Models
{
    public class Album: ITrackList
    {

        public Album(string name, string image, string band, int year, List<StrippedTrackElement> tracks)
        {
            Name = name;
            Image = image;
            Tracks = tracks;
            Band = band;
        }
        public int Id { get; set; }
        public string Band { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Year { get; set; }
        public List<StrippedTrackElement> Tracks { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Tags { get; set; }
    }
}
