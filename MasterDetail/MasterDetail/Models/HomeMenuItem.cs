using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Models
{
    public enum MenuItemType
    {
        Browse,
        About, 
        Albums,
        Playlists
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
