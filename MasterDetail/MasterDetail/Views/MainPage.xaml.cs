﻿using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterDetail.Services;
using System.Linq;

namespace MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new Profile(new User())));
                        break;
                    case (int)MenuItemType.About:
                        List<Album> albums = DataStore.Albums;
                        MenuPages.Add(id, new NavigationPage(new AlbumsGrid(true, DataStore.Users[0])));
                        break;
                    case (int)MenuItemType.Albums:
                        MenuPages.Add(id, new NavigationPage(new Home()));
                        break;
                    case (int)MenuItemType.Playlists:
                        List<Playlist> playlists = DataStore.Playlists; 
                        MenuPages.Add(id, new NavigationPage(new AlbumsGrid(false, StatusManager.CurrentUser)));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new Profile(DataStore.Users.First())));
                        break;
                    case (int)MenuItemType.Search:
                        MenuPages.Add(id, new NavigationPage(new Search()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}