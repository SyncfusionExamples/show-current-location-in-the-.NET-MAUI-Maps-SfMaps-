using Syncfusion.Maui.Maps;

namespace ShowCurrentLocation
{
    public class MapsBehavior : Behavior<ContentPage>
    {
        private MapTileLayer tileLayer;
        private MapMarker marker;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.tileLayer = bindable.FindByName<MapTileLayer>("tileLayer");
            this.marker = bindable.FindByName<MapMarker>("marker");
            GetLocation();
        }

        private async void GetLocation()
        {
            Location location = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.High,
                Timeout = TimeSpan.FromSeconds(30)
            });

            if (location != null)
            {
                tileLayer.Center = new MapLatLng(location.Latitude, location.Longitude);

                marker.Latitude = location.Latitude;
                marker.Longitude = location.Longitude;
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.tileLayer = null;
            this.marker = null;
        }
    }
}
