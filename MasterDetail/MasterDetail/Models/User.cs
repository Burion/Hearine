using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Models
{
    public class User
    {
        public User()
        {

        }
        public User(int id, string name, string password, string avatar, string mail)
        {
            Id = id;
            Name = name;
            Password = password;
            Avatar = avatar;
            Mail = mail;
            Playlists = new List<Playlist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Mail { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<User> Follows = new List<User>();

    }
}
