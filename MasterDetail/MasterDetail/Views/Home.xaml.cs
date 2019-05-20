
using MasterDetail.Models;
using MasterDetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
        List<Album> popularAlbums = DataStore.Albums.Take(4).ToList();
        List<Playlist> popularPlaylists = DataStore.Playlists.Take(1).ToList();
		public Home ()
		{
			InitializeComponent ();
            Refresh(popularAlbums.Cast<ITrackList>().ToList());
            Refresh(popularPlaylists.Cast<ITrackList>().ToList());
		}
        public void Refresh(List<ITrackList> trackLists)
        {
            int x = 0;
            int y = 0;
            bool isAlb = trackLists.First() is Album;
            var Grid = isAlb ? grid : gridPlaylists;
            var list = isAlb ? popularAlbums.Cast<ITrackList>().ToList() : popularPlaylists.Cast<ITrackList>().ToList();
            Grid.Children.Clear();
            foreach (ITrackList album in list)
            {
                RowDefinition rowDefinition = new RowDefinition { Height = 165 };
                ColumnDefinition columnDefinition = new ColumnDefinition { Width = 165 };
                Grid.RowDefinitions.Add(rowDefinition);
                Grid.ColumnDefinitions.Add(columnDefinition);
                var image = new Image { Source = album.Image, Aspect = Aspect.AspectFill };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    Image img = (Image)s;
                    List<ITrackList> tracksSequence = DataStore.Albums.Cast<ITrackList>().ToList();
                    ITrackList alb = tracksSequence.Where(a => a.Image == album.Image).First();
                    StatusManager.CurrentAlbum = alb;
                    Navigation.PushAsync(new Page1(alb));
                };
                image.GestureRecognizers.Add(tapGestureRecognizer);
                Grid.Children.Add(image, x, y);
                y = x == 1 ? y + 1 : y;
                x = x == 1 ? 0 : 1;
            }
           
        }
    }
}