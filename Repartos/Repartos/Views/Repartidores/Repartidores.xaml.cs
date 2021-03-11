using Repartos.DataAccessLayer;
using Repartos.Models;
using Repartos.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views.Repartidores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repartidores : ContentPage
    {
        RepartidorDAL repo;
        public RepartidorViewModel viewModel { get; set; }

        public Repartidores()
        {
            InitializeComponent();
            this.repo = new RepartidorDAL();
            this.repo.CrearBBDD();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel = new RepartidorViewModel();
            CargarRepartidores(null, null);
        }
                    
        protected void CargarRepartidores(object sender, EventArgs e)
        {
            try
            {
                viewModel = new RepartidorViewModel();
                List<Repartidor> repartidores = new List<Repartidor>();
                repartidores = viewModel.GetRepartidoresList();
                if (repartidores.Count > 0)
                    listaRepartidores.ItemsSource = repartidores;
                else
                    lblMensaje.Text = "Aún no hay repartidores cargados..."; lblMensaje.IsVisible = true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {

        }

        private async void actModificar_Clicked(object sender, EventArgs e)
        {
            var miItem = ((MenuItem)sender);
            int idRepartidor = int.Parse(miItem.CommandParameter.ToString());

            App.Current.Properties["IdRepartidor"] = idRepartidor;
            App.Current.Properties["AccionPorHacer"] = "Modificar";

            ABMRepartidor view = new ABMRepartidor();
            await Navigation.PushModalAsync(view);
        }

        private async void actBaja_Clicked(object sender, EventArgs e)
        {
            var miItem = ((MenuItem)sender);
            int idRepartidor = int.Parse(miItem.CommandParameter.ToString());

            App.Current.Properties["IdRepartidor"] = idRepartidor;
            App.Current.Properties["AccionPorHacer"] = "Baja";

            ABMRepartidor view = new ABMRepartidor();
            await Navigation.PushModalAsync(view);
        }



        private async void listaRepartidores_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ABMRepartidor view = new ABMRepartidor();

            Repartidor repartidor = e.Item as Repartidor;

            App.Current.Properties["IdRepartidor"] = repartidor.IdRepartidor;
            App.Current.Properties["AccionPorHacer"] = "Ver";

            await Navigation.PushModalAsync(view);
        }

        private async void btnNuevoRepartidor_Clicked(object sender, EventArgs e)
        {
            NuevoRepartidor view = new NuevoRepartidor();
            await Navigation.PushModalAsync(view);
        }
    }
}