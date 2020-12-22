using Repartos.Models;
using Repartos.Repository;
using Repartos.ViewModels;
using Repartos.Views;
using System;
using Xamarin.Forms;

namespace Repartos
{
    public partial class MainPage : ContentPage
    {
        RepositoryRepartidores repo;
        public MainPage()
        {
            InitializeComponent();
            this.repo = new RepositoryRepartidores();
            this.repo.CrearBBDD();
            this.btneliminar.Clicked += Btneliminar_Clicked;
            this.btnmodificar.Clicked += Btnmodificar_Clicked;
            this.btnmostrar.Clicked += Btnmostrar_Clicked;
            this.btnnuevo.Clicked += Btnnuevo_Clicked;
        }

        private async void Btnnuevo_Clicked(object sender, EventArgs e)
        {
            AgregarRepartidor view = new AgregarRepartidor();
            await Navigation.PushModalAsync(view);

        }

        private async void Btnmostrar_Clicked(object sender, EventArgs e)
        {
            Repartidoress view = new Repartidoress();
            await Navigation.PushModalAsync(view);

        }

        private async void Btnmodificar_Clicked(object sender, EventArgs e)
        {
            ModificarRepartidor view = new ModificarRepartidor();
            RepartidorModel viewmodel = new RepartidorModel();

            //busca el número de documento que hay en la caja
            int documentoNumero = int.Parse(this.cajacodigo.Text);
            //asociarlo con viewmodel
            Repartidor repartidor = this.repo.BuscarRepartidor(documentoNumero);
            viewmodel.Repartidor = repartidor;
            view.BindingContext = viewmodel;
            await Navigation.PushModalAsync(view);
        }

        private async void Btneliminar_Clicked(object sender, EventArgs e)
        {
            EliminarRepartidor view = new EliminarRepartidor();
            RepartidorModel viewmodel = new RepartidorModel();
            int documentoNumero = int.Parse(this.cajacodigo.Text);
            Repartidor repartidor = this.repo.BuscarRepartidor(documentoNumero);
            viewmodel.Repartidor = repartidor;
            view.BindingContext = viewmodel;
            await Navigation.PushModalAsync(view);
        }
    }
}

