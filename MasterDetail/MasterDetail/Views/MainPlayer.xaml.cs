using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Services;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPlayer : ContentPage
	{
        SKPaint skPaint = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Orange,
            StrokeWidth = 10,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round
        };
        bool showFill = true;
        CancellationTokenSource source = new CancellationTokenSource();
        
        public MainPlayer ()
		{
			InitializeComponent ();    
            //Refresh();
            BindingContext = new { StatusManager.CurrentAlbum.Image, StatusManager.currentTrack.Name, StatusManager.currentTrack.Band };
		}
        public void ProgressBarRender()
        {
            Task.Run(() =>
            {
                while (StatusManager.mediaPlayer.IsPlaying)
                {
                    Task.Delay(100).Wait(); progress.Progress = (double)StatusManager.mediaPlayer.CurrentPosition / StatusManager.mediaPlayer.Duration;
                }
            },
            source.Token);
        }

        #region Canvas Hebdler
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            SKPoint[] skPointsList;
            if (!StatusManager.mediaPlayer.IsPlaying)
            {
                skPointsList = new SKPoint[]
                {
	        // Path 1
	        new SKPoint(5,15),
            new SKPoint(75, 80),
            // Path 2
            new SKPoint(75, 80),
            new SKPoint(5, 140),
            //Path 3
            new SKPoint(5, 140),
            new SKPoint(5, 15),
                };
            }
            else
            {
               skPointsList = new SKPoint[]
            {
	        // Path 1
	        new SKPoint(25,15),
            new SKPoint(25, 140),
            // Path 2
            new SKPoint(55, 15),
            new SKPoint(55, 140),

            };
            }
            canvas.DrawPoints(SKPointMode.Lines, skPointsList, skPaint);
        }

        void OnCanvasViewPaintSurfaceNext(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();



            SKPoint[] skPointsList = new SKPoint[]
            {
	        // Path 1
	        new SKPoint(10,50),
            new SKPoint(60, 80),
            // Path 2
            new SKPoint(60, 80),
            new SKPoint(10, 110),
            //Path 3
            new SKPoint(60, 50),
            new SKPoint(60, 110),

            };
            canvas.DrawPoints(SKPointMode.Lines, skPointsList, skPaint);
        }

        void OnCanvasViewPaintSurfacePrev(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPoint[] skPointsList = new SKPoint[]
            {
	        // Path 1
	        new SKPoint(60,50),
            new SKPoint(10, 80),
            // Path 2
            new SKPoint(10, 80),
            new SKPoint(60, 110),
            //Path 3
            new SKPoint(10, 50),
            new SKPoint(10, 110),

            };
            canvas.DrawPoints(SKPointMode.Lines, skPointsList, skPaint);
        }

        void OnPlayButtonPressed(object sender, EventArgs args)
        {
            if (StatusManager.mediaPlayer.IsPlaying)
                StatusManager.mediaPlayer.Pause();
            else
                StatusManager.mediaPlayer.Start();
            (sender as SKCanvasView).InvalidateSurface();
        }
        void OnNextButtonPressed(object sender, EventArgs args)
        {
            StatusManager.NextTrack();
            RefreshTrackData();
            RefreshButtons();
        }
        void OnPrevButtonPressed(object sender, EventArgs args)
        {
            StatusManager.PrevTrack();
            RefreshTrackData();
            RefreshButtons();
        }
        #endregion
        void RefreshTrackData()
        {
            Band.Text = StatusManager.currentTrack.Band;
            Track.Text = StatusManager.currentTrack.Name;
        }
        void RefreshButtons()
        {
            PlayButton.InvalidateSurface();
        }
    }
}