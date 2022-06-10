using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XFMapsFiap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalizacaoView : ContentPage
    {
        public LocalizacaoView()
        {
            InitializeComponent();
        }

        private async void CentralizarMapaClicked(object sender, EventArgs e)
        {
            var currentLocation = await Geolocation.GetLocationAsync();
            var mapPosition = new Position(currentLocation.Latitude, currentLocation.Longitude);
            MapaGoogle.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromMiles(0.2)));

        }
    }
}