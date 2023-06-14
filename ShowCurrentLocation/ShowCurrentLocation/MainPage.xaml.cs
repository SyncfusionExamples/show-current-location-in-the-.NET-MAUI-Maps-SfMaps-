using Syncfusion.Maui.Maps;

namespace ShowCurrentLocation;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
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
            //tileLayer.Center.Latitude = location.Latitude;
            //tileLayer.Center.Longitude = location.Longitude;
            tileLayer.Center = new MapLatLng(location.Latitude, location.Longitude);

            marker.Latitude = location.Latitude;
            marker.Longitude = location.Longitude;
        }
    }
}

