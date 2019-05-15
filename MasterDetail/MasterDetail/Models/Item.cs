using System;
using Xamarin.Forms;

namespace MasterDetail.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class StrippedTrackElement
    {
        public StrippedTrackElement(string name, string band, string path)
        {
            Name = name;
            Band = band;
            Path = path;
        }

        public string Name { get; set; }
        public string Band { get; set; }
        //public Image Image { get; set; }
        public string Path { get; set; }

    }
}