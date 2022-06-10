using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XFMapsFiap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaView : ContentPage
    {
        public BuscaView()
        {
            InitializeComponent();
            _ = CentralizarMapaAsync();
        }

        private async void BuscarEnderecoPressed(object sender, EventArgs e)
        {
            await LocalizarAsync(seachBarEndereco.Text);
        }

        private async void BuscarCoordenadasPressed(object sender, EventArgs e)
        {
            string[] coordenadas = seachBarCoordenada.Text.Split(',');
            if (coordenadas.Count() > 1)
            {
                try
                {
                    Position position = new Position(
                        Convert.ToDouble(coordenadas[0]),
                        Convert.ToDouble(coordenadas[1])
                    );

                    await LocalizarAsync(position);
                }
                catch (Exception)
                {
                    await DisplayAlert("Localização", "Coordenada inválida.", "OK");
                }
            }
        }


        private async Task LocalizarAsync(string endereco)
        {
            Geocoder geocoder = new Geocoder();
            Task<IEnumerable<Position>> resultado = geocoder.GetPositionsForAddressAsync(endereco);

            IEnumerable<Position> posicoes = await resultado;
            foreach (Position item in posicoes)
            {
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(item, Distance.FromMiles(0.2)));
                break;
            }
        }

        private async Task LocalizarAsync(Position position)
        {
            Geocoder geocoder = new Geocoder();
            Task<IEnumerable<string>> resultado =
                geocoder.GetAddressesForPositionAsync(position);

            IEnumerable<string> posicoes = await resultado;
            foreach (var item in posicoes)
            {
                await LocalizarAsync(item);
                break;
            }
        }



        private async Task CentralizarMapaAsync()
        {
            var currentLocation = await Geolocation.GetLocationAsync();
            var mapPosition = new Position(currentLocation.Latitude, currentLocation.Longitude);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromMiles(1)));
        }

    }
}