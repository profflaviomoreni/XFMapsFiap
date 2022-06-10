using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XFMapsFiap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinView : ContentPage
    {
        public PinView()
        {
            InitializeComponent();
        }

        private async void BuscarEnderecoPressed(object sender, EventArgs e)
        {
            await LocalizarAsync(seachBarEndereco.Text);
        }

        private async Task LocalizarAsync(string endereco)
        {
            Geocoder geocoder = new Geocoder();

            Task<IEnumerable<Position>> resultado = geocoder.GetPositionsForAddressAsync("Maracana");
            IEnumerable<Position> posicoes1 = await resultado;
            Position position1 = posicoes1.ElementAt(0);

            Task<IEnumerable<Position>> resultado2 = geocoder.GetPositionsForAddressAsync("São Januario");
            IEnumerable<Position> posicoes2 = await resultado2;
            Position position2 = posicoes2.ElementAt(0);



            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(position1, Distance.FromMiles(4)));

            var p1 = new Pin()
            {
                Type = PinType.Generic,
                Position = position1,
                Label = "P1",
                Address = "Maracana",
            };

            var p2 = new Pin()
            {
                Type = PinType.Place,
                Position = position2,
                Label = "P2",
                Address = "Sao Januario",
            };

            mapa.Pins.Add(p1);
            mapa.Pins.Add(p2);

            mapa.SelectedPin = p2;


        }
    }
}