using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterDetail.Models;
using MasterDetail.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumsGrid : ContentPage
    {
        bool isAlbum;
        private User user;

        public List<ITrackList> TrackList
        {
            get
            {
                return isAlbum ? DataStore.Albums.Cast<ITrackList>().ToList() : StatusManager.CurrentUser.Playlists.Cast<ITrackList>().ToList();
            }
        }
        public AlbumsGrid(bool isAlbum, User user)
        {
            InitializeComponent();
            this.isAlbum = isAlbum;
            this.user = user;
        }

        public void Refresh()
        {
            grid.Children.Clear();
            int x = 0;
            int y = 0;
            foreach (ITrackList album in TrackList)
            {
                RowDefinition rowDefinition = new RowDefinition { Height = 165 };
                ColumnDefinition columnDefinition = new ColumnDefinition { Width = 165 };
                grid.RowDefinitions.Add(rowDefinition);
                grid.ColumnDefinitions.Add(columnDefinition);
                var image = new Image { Source = album.Image, Aspect = Aspect.AspectFill };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    Image img = (Image)s;
                    List<ITrackList> tracksSequence = isAlbum ? DataStore.Albums.Cast<ITrackList>().ToList() : user.Playlists.Cast<ITrackList>().ToList();
                    ITrackList alb = tracksSequence.Where(a => a.Image == album.Image).First();
                    StatusManager.CurrentAlbum = alb;
                    Navigation.PushAsync(new Page1(alb));
                };
                image.GestureRecognizers.Add(tapGestureRecognizer);
                grid.Children.Add(image, x, y);
                y = x == 1 ? y + 1 : y;
                x = x == 1 ? 0 : 1;
            }
            scroll.HeightRequest = (grid.Children.Count / 2) * 165;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Refresh();
        }



        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}