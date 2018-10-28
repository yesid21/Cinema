using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cinema_YSCC.Dominio;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Cinema_YSCC.Dominio.Cartelera;

namespace Cinema_YSCC.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncionesPage : ContentPage
	{

        Cartelera globalcartelera;
        public FuncionesPage (Cartelera cartelera)
        {
            InitializeComponent();
            BindingContext = cartelera;
            listFuncion.ItemsSource = cartelera.Funciones;
            globalcartelera = cartelera;
        }



        private async void Funcion_Select(object sender, SelectedItemChangedEventArgs e)
        {
            int valor = Convert.ToInt32(MiEntry.Text);
            var funcion = e.SelectedItem as Funciones;
            await Navigation.PushAsync(new DetallePage(funcion, globalcartelera, valor));
        }
    }
}