using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XFMapsFiap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZoomView : ContentPage
    {
        public ZoomView()
        {
            InitializeComponent();
        }

        private async void CentralizarMapaClicked(object sender, EventArgs e)
        {
            var currentLocation = await Geolocation.GetLocationAsync();
            var mapPosition = new Position(currentLocation.Latitude, currentLocation.Longitude);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromMiles(0.2)));
        }

        private async void HybridClicked(object sender, EventArgs e)
        {
            mapa.MapType = MapType.Hybrid;
        }

        private async void StreetClicked(object sender, EventArgs e)
        {
            mapa.MapType = MapType.Street;
        }

        private async void SatelitteClicked(object sender, EventArgs e)
        {
            mapa.MapType = MapType.Satellite;
        }

        private void ZoomChanged(object sender, ValueChangedEventArgs e)
        {
            var zoom = e.NewValue;
            var localizacao = 360 / (Math.Pow(2, zoom));

            mapa.MoveToRegion(
                new MapSpan(
                    mapa.VisibleRegion.Center,
                    localizacao,
                    localizacao)
                );

        }
    }
}