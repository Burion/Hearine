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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Band { get; set; } //fix
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
