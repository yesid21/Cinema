using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinema_YSCC.Dominio;
using static Cinema_YSCC.Dominio.Cartelera;

namespace Cinema_YSCC.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarteleraPage : ContentPage
	{
        public CarteleraPage()
        {
            InitializeComponent();
            CargarPublicaciones();
        }
        private async void CargarPublicaciones()
        {
            HttpClient cartelera = new HttpClient();
            cartelera.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var request = await cartelera.GetAsync("/api/Cartelera");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var listado = JsonConvert.DeserializeObject<List<Cartelera>>(responseJson);
                listCarteleras.ItemsSource = listado;
            }
        }
        private async void Pelic_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var funcion = e.SelectedItem as Cartelera;
            await Navigation.PushAsync(new FuncionesPage(funcion));
        }
    }
}