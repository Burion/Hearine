using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Models
{
    public class Playlist: ITrackList
    {

        public Playlist(List<StrippedTrackElement> tracks, string band, string name, string image, string description)
        {
            Tracks = tracks;
            Band = band;
            Name = name;
            Image = image;
            Description = description;
        }

        public List<StrippedTrackElement> Tracks { get; set; }
        public string Band { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
