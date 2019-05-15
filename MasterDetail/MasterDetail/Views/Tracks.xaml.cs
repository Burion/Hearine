using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterDetail.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterDetail.Models;
using Android.Widget;

namespace MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tracks : ContentPage
	{
        public List<StrippedTrackElement> TracksToAdd { get; set; }
		public Tracks ()
		{
			InitializeComponent ();
            TracksToAdd = new List<StrippedTrackElement>();
            LoadTracks();
		}
        void LoadTracks()
        {
            foreach(StrippedTrackElement track in DataStore.tracks)
            {
                StackLayout stack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                
                Label Band = new Label { Text = track.Band, FontSize = 20, FontAttributes = FontAttributes.Bold };
                Label Name = new Label { Text = track.Name, FontSize = 20};
                stack.Children.Add(Band);
                stack.Children.Add(Name);
                stack.HeightRequest = 200;
                stack.BackgroundColor = Color.White;
                TapGestureRecognizer recognizer = new TapGestureRecognizer();

                recognizer.Tapped += (s, e) => {
                    StackLayout stack_ = (StackLayout)s;
                    Label label = stack_.Children.Where(x => x is Label)
                        .Where(l => ((Label)l).FontAttributes != FontAttributes.Bold).First() as Label;
                    var checkedSong = DataStore.tracks.Where(t => t.Name == label.Text).First();

                    if (isInList(checkedSong.Name))
                    {
                        TracksToAdd.Remove(checkedSong);
                        stack.BackgroundColor = Color.White;
                    }
                    else
                    {
                        stack.BackgroundColor = Color.Orange;
                        TracksToAdd.Add(checkedSong);
                    }

                    bool isInList(string name)
                    {
                        return TracksToAdd.Where(t => t.Name == name).Count() != 0;
                    }
                };
                stack.GestureRecognizers.Add(recognizer);
                _stack.Children.Add(stack);
            }
        }

        void AddTracksToPlaylist(object sender, EventArgs e)
        {
            foreach (var track in TracksToAdd)
                StatusManager.CurrentAlbum.Tracks.Add(track);
            Navigation.PopModalAsync();
        }
	}
}