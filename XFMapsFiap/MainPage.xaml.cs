using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMapsFiap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MapaComunClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync( new View.MapaComunView());
        }

        private void LocalizacaoClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.LocalizacaoView());
        }

        private void ZoomClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.ZoomView());
        }

        private void BuscaClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BuscaView());
        }

        private void PinClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.PinView());
        }

    }
}
