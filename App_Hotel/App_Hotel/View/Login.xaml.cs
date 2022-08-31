using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App_Hotel.Model;


namespace App_Hotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
            App PropriedadesApp;

            public Login()
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);

                PropriedadesApp = (App)Application.Current;

                logo_login.Source = ImageSource.FromResource("App_Hotel.Imagens.logomarrom.jpg");
                frm_login.BackgroundColor = Color.FromRgba(1, 1, 1, 0.8);
    
            }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = txt_email.Text;
                string senha = txt_senha.Text;

                if (PropriedadesApp.list_usuarios.Any(i => (i.Email == email && i.Senha == senha)))
                {
                    App.Current.Properties.Add("usuario_logado", email);
                    App.Current.MainPage = new ContratacaoHospedagem();
                }
                else
                    throw new Exception("Dados incorretos, tente novamente.");

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops!", ex.Message, "OK");
            }

        }
    }
}