using MasterDetail.Models;
using MasterDetail.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        int SearchId { get; set; }
		public Search ()
		{
			InitializeComponent ();
		}

        public Search(string query)
        {
            InitializeComponent();

            List<Album> list = DataStore.Albums;            
            //List<Album> result = list.Where(x => x.Name == query || x.Band == query).ToList();
            List<Album> result = list;
            foreach(var alb in result)
            {
                StackLayout stack = new StackLayout
                {
                    Padding = 20,
                    Orientation = StackOrientation.Horizontal
                };
                stack.Children.Add(new Image { Source = alb.Image, HeightRequest = 50 });
                stack.Children.Add(new Label { Text = alb.Band, FontSize = 20, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center });
                stack.Children.Add(new Label { Text = alb.Name, FontSize = 15 });
                ResultStack.Children.Add(stack);

                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer
                {
                    
                };
                tapGestureRecognizer.Tapped += (sender, args) => { Navigation.PushAsync(new Page1(alb)); };
                stack.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        public void ExecuteQuery(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Search(Input.Text));
        }
    }
}