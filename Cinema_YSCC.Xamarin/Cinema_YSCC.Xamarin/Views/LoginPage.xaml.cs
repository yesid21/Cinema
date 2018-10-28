using Cinema_YSCC.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_YSCC.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();

		}

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var usuario = new Login
            {
                Usuario = UsuarioEntry.Text,
                Password = PasswordEntry.Text
            };

            var isValid = AreCredentialsCorrect(usuario);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new CarteleraPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "El Usuario Y/O Contraseña No Es Permitio";
                PasswordEntry.Text = string.Empty;
            }
        }
        HttpClient client = new HttpClient();
        public async Task GuardarLoginAsync(Login item, bool isNewItem = false)
        {
            var uri = new Uri("https://misapis.azurewebsites.net");

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "api/Seguridad");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await client.PostAsync(uri, content);
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"Login successfully saved.");

            }
        }

        bool AreCredentialsCorrect(Login usuario)
        {
            return usuario.Usuario == Constants.Username && usuario.Password == Constants.Password;

        }
    }
}