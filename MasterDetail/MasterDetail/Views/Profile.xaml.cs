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
    public partial class Profile : ContentPage
    {
        User user { get; set; }
        public Profile(User user)
        {
            InitializeComponent();
            BindingContext = user;
            this.user = user;
            Refresh();

        }
        public void Refresh()
        {
            grid.Children.Clear();
            int x = 0;
            int y = 0;
            foreach (ITrackList album in user.Playlists)
            {
                RowDefinition rowDefinition = new RowDefinition { Height = 165 };
                ColumnDefinition columnDefinition = new ColumnDefinition { Width = 165 };

                grid.RowDefinitions.Add(rowDefinition);
                grid.ColumnDefinitions.Add(columnDefinition);
                var image = new Image { Source = album.Image, Aspect = Aspect.AspectFill };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    Image img = (Image)s;
                    List<ITrackList> tracksSequence = DataStore.Playlists.Cast<ITrackList>().ToList();
                    ITrackList alb = tracksSequence.Where(a => a.Image == album.Image).First();
                    StatusManager.CurrentAlbum = alb;
                    Navigation.PushAsync(new Page1(alb));
                };
                image.GestureRecognizers.Add(tapGestureRecognizer);

                //Label label = new Label
                //{
                //    Text = "Play",
                //    FontSize = 20,
                //    TextColor = Color.White
                //};

                grid.Children.Add(image, x, y);
                //grid.Children.Add(label, x, y);
                y = x == 1 ? y + 1 : y;
                x = x == 1 ? 0 : 1;
            }
        }
    }
}