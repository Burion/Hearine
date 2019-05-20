using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Models
{
    public class Band
    {
        public Band(int id, string name, string image, List<User> subs, List<Album> albums)
        {
            Id = id;
            Name = name;
            Image = image;
            Subs = subs;
            Albums = albums;
        }

        public int  Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<User> Subs { get; set; }
        public List<Album> Albums { get; set; }
    }
}
