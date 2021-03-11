using Repartos.Models;
using Repartos.Repository;
using Repartos.ViewModels;
using Repartos.Views;
using Repartos.Views.Empresas;
using Repartos.Views.Repartidores;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Repartos
{
    public partial class MainPage : ContentPage
    {
        //RepositoryRepartidores repo;
        public MainPage()
        {
            InitializeComponent();
            //this.repo = new RepositoryRepartidores();
            //this.repo.CrearBBDD();
            //this.btneliminar.Clicked += Btneliminar_Clicked;
            //this.btnmodificar.Clicked += Btnmodificar_Clicked;
            //this.btnmostrar.Clicked += Btnmostrar_Clicked;
            //this.btnnuevo.Clicked += Btnnuevo_Clicked;

            //// PRUEBAS HAMBURGUESA...
            //this.btnHamburguesa.Clicked += btnHamburguesa_Clicked;

            //btnGestionarCampania.On<Android>().SetUseDefaultPadding(true).SetUseDefaultShadow(true);
            //btnRepartidores.On<Android>().SetUseDefaultPadding(true).SetUseDefaultShadow(true);
            //btnEmpresas.On<Android>().SetUseDefaultPadding(true).SetUseDefaultShadow(true);
            //btnHistorialRepartos.On<Android>().SetUseDefaultPadding(true).SetUseDefaultShadow(true);
        }

        private async void btnEmpresas_Clicked(object sender, EventArgs e)
        {
            Empresas view = new Empresas();
            await Navigation.PushModalAsync(view);
        }

        private void btnGestionarCampania_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnRepartidores_Clicked(object sender, EventArgs e)
        {
            Repartidores view = new Repartidores();
            await Navigation.PushModalAsync(view);
        }

        private void btnHistorialRepartos_Clicked(object sender, EventArgs e)
        {

        }

        //private async void Btnnuevo_Clicked(object sender, EventArgs e)
        //{
        //    AgregarRepartidor view = new AgregarRepartidor();
        //    await Navigation.PushModalAsync(view);

        //}

        //private async void Btnmostrar_Clicked(object sender, EventArgs e)
        //{
        //    Repartidoress view = new Repartidoress();
        //    await Navigation.PushModalAsync(view);
        //}

        //private async void Btnmodificar_Clicked(object sender, EventArgs e)
        //{
        //    ModificarRepartidor view = new ModificarRepartidor();
        //    RepartidorModel viewmodel = new RepartidorModel();

        //    //busca el número de documento que hay en la caja
        //    int documentoNumero = int.Parse(this.cajacodigo.Text);
        //    //asociarlo con viewmodel
        //    Repartidor repartidor = this.repo.BuscarRepartidor(documentoNumero);
        //    viewmodel.Repartidor = repartidor;
        //    view.BindingContext = viewmodel;
        //    await Navigation.PushModalAsync(view);
        //}

        //private async void Btneliminar_Clicked(object sender, EventArgs e)
        //{
        //    EliminarRepartidor view = new EliminarRepartidor();
        //    RepartidorModel viewmodel = new RepartidorModel();
        //    int documentoNumero = int.Parse(this.cajacodigo.Text);
        //    Repartidor repartidor = this.repo.BuscarRepartidor(documentoNumero);
        //    viewmodel.Repartidor = repartidor;
        //    view.BindingContext = viewmodel;
        //    await Navigation.PushModalAsync(view);
        //}

        ///// PRUEBAS HAMBURGUESA VISTE...

        //private async void btnHamburguesa_Clicked(object sender, EventArgs e)
        //{
        //    MenuHamburguesa view = new MenuHamburguesa();
        //    await Navigation.PushModalAsync(view);
        //}
    }
}

