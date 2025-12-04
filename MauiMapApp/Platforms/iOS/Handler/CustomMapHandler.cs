using MapKit;
using Microsoft.Maui.Maps.Handlers;
using Microsoft.Maui.Maps.Platform;

namespace MauiMapApp
{
    public class CustomMapHandler : MapHandler
    {

        protected override void ConnectHandler(MauiMKMapView platformView)
        {
            base.ConnectHandler(platformView);

            // Disable interactions
            platformView.RotateEnabled = false;
            platformView.PitchEnabled = false;
            platformView.ShowsCompass = false;

            // Disable user location
            platformView.ShowsUserLocation = false;

            // Schwächere Farben damit die PINs der Entwickler besser zu sehen sind
            platformView.MapType = MKMapType.MutedStandard;

            //MauiMapDelegate mauiMapDelegate = new MauiMapDelegate();
            //platformView.Delegate = mauiMapDelegate;

            //mauiMapDelegate.OnCameraIdle = () =>
            //{
            //    Console.WriteLine("mauiMapDelegate: OnCameraIdle");
            //};

            //mauiMapDelegate.OnCameraMoveStarted = () =>
            //{
            //    Console.WriteLine("mauiMapDelegate: OnCameraMoveStarted");
            //};

            platformView.MapLoaded += PlatformView_MapLoaded;

            //Test, anstelle von MapLoaded
            platformView.RegionWillChange += PlatformView_RegionWillChange;
            platformView.RegionChanged += PlatformView_RegionChanged;

            platformView.DidChangeVisibleRegion += PlatformView_DidChangeVisibleRegion;
        }


        private void PlatformView_DidChangeVisibleRegion(object? sender, EventArgs e)
        {
            Console.WriteLine("PlatformView_DidChangeVisibleRegion");
        }

        private void PlatformView_MapLoaded(object? sender, EventArgs e)
        {
            Console.WriteLine("PlatformView_MapLoaded");

            if (sender is MauiMKMapView platformView)
            {
                platformView.RegionWillChange += PlatformView_RegionWillChange;
                platformView.RegionChanged += PlatformView_RegionChanged;

                platformView.MapLoaded -= PlatformView_MapLoaded;
            }
        }

        private void PlatformView_RegionChanged(object? sender, MKMapViewChangeEventArgs e)
        {
            Console.WriteLine("PlatformView_RegionChanged");
        }

        private void PlatformView_RegionWillChange(object? sender, MKMapViewChangeEventArgs e)
        {
            Console.WriteLine("PlatformView_RegionWillChange");
        }

        protected override void DisconnectHandler(MauiMKMapView platformView)
        {
            platformView.MapLoaded -= PlatformView_MapLoaded;
            platformView.RegionWillChange -= PlatformView_RegionWillChange;
            platformView.RegionChanged -= PlatformView_RegionChanged;

            base.DisconnectHandler(platformView);
        }

        public class CustomAnnotation : MKPointAnnotation
        {
            public string IconName { get; set; } = string.Empty;
            public string AnnotationId { get; set; } = string.Empty;
        }

        public class MauiMapDelegate : MKMapViewDelegate
        {
            public Action? OnCameraMoveStarted;
            public Action? OnCameraIdle;

            public override void RegionWillChange(MKMapView mapView, bool animated)
            {
                OnCameraMoveStarted?.Invoke();
            }

            public override void RegionChanged(MKMapView mapView, bool animated)
            {
                OnCameraIdle?.Invoke();
            }
        }

    }
}