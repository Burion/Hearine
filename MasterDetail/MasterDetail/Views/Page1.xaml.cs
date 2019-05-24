using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterDetail.Models;
using Android.Media;
using MasterDetail.Services;
using Android;


namespace MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{

        public List<StrippedTrackElement> Tracks { get; set; }
        public string[] Phones { get; set; }
        public int[] Nums { get; set; }
        public string[] Names { get; set; }

        string BandName { get; set; }

        public Page1(ITrackList trackSet)
        {
            InitializeComponent();
            BandName = trackSet.Band;
            BindingContext = trackSet;
        }

        public Page1 ()
		{
            InitializeComponent();   
        }

        public void AddTracksPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new Tracks()));
        }

        public void Refresh()
        {
            BindingContext = DataStore.Playlists.Where(p => p.Band == BandName).First();
        }

        public async void Print(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPlayer()));
        }
        

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as StrippedTrackElement;
            if (item == null)
                return;
            StatusManager.Play(item);
        }
    }
}