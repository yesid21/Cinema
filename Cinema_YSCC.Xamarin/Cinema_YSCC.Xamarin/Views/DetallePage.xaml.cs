using Cinema_YSCC.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_YSCC.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallePage : ContentPage
	{
		public DetallePage (Funciones funciones, Cartelera pelicula, int valor)
        {
            int total = valor * (funciones.Precio);
            InitializeComponent();
            carteleral.BindingContext = pelicula;
            lbltotal.Text = Convert.ToString(total);
            Label21.Text = Convert.ToString(valor);
            stackLayout.BindingContext = funciones;
        }

        private void Confirmar(object sender, EventArgs e)
        {
            DisplayAlert("Reserva", "La reserva se ha generado correctamente", "Continuar");
            
        }
    }
}