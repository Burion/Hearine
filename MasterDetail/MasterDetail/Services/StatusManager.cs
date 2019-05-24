using Android.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MasterDetail.Services;
using MasterDetail.Models;

namespace MasterDetail.Services
{
    public static class StatusManager
    {
        public static MediaPlayer mediaPlayer { get; set; }
        public static StrippedTrackElement currentTrack { get; set; }
        public static ITrackList CurrentAlbum { get; set; }
        public static User CurrentUser { get; set; }

        static StatusManager()
        {
            CurrentUser = DataStore.Users[0];
            mediaPlayer = new MediaPlayer();
            currentTrack = new StrippedTrackElement("—", "—", "—");
            CurrentAlbum = new Album("—", "—", "—", 1000, new List<StrippedTrackElement>());
        }

        public static void Play(StrippedTrackElement track)
        {
            mediaPlayer.Stop();
            mediaPlayer.Reset();
            var afd = Android.App.Application.Context.Assets.OpenFd(track.Path);
            mediaPlayer.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.DeclaredLength);
            mediaPlayer.Prepare();
            mediaPlayer.Start();
            int duration = mediaPlayer.Duration;
            currentTrack = track;
        }

        public static void Play(string path)
        {
            StrippedTrackElement track = CurrentAlbum.Tracks.Where(x => x.Path == path).First();
            Play(track);
        }

        public static void NextTrack()
        {
            int size = CurrentAlbum.Tracks.Count;
            int i = CurrentAlbum.Tracks.IndexOf(currentTrack);
            if (i == size - 1)
            {
                Play(CurrentAlbum.Tracks[0]);
            }
            else
                Play(CurrentAlbum.Tracks[++i]);
        }
        public static void PrevTrack()
        {
            int size = CurrentAlbum.Tracks.Count;
            int i = CurrentAlbum.Tracks.IndexOf(currentTrack);
            if (i == 0)
            {
                Play(CurrentAlbum.Tracks[size - 1]);
            }
            else
                Play(CurrentAlbum.Tracks[--i]);
        }
    }
}
