using Repartos.DataAccessLayer;
using Repartos.Models;
using Repartos.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views.Empresas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Empresas : ContentPage
    {
        EmpresaDAL repo;
        public EmpresaViewModel viewModel { get; set; }

        public Empresas()
        {
            InitializeComponent();
            this.repo = new EmpresaDAL();
            this.repo.CrearBBDD();
            //CargarEmpresas(null, null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel = new EmpresaViewModel();
            CargarEmpresas(null, null);
        }

        private async void listaEmpresas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ABMEmpresa view = new ABMEmpresa();
            //EmpresaViewModel viewmodel = new EmpresaViewModel();

            Empresa empresa = e.Item as Empresa;
            //viewmodel.Empresa = empresa;
            //view.BindingContext = viewmodel;
                       
            App.Current.Properties["IdEmpresa"] = empresa.IdEmpresa;
            App.Current.Properties["AccionPorHacer"] = "Ver";

            await Navigation.PushModalAsync(view);
        }

        private async void btnNuevaEmpresa_Clicked(object sender, EventArgs e)
        {
            NuevaEmpresa view = new NuevaEmpresa();
            await Navigation.PushModalAsync(view);
        }

        protected void CargarEmpresas(object sender, EventArgs e)
        {
            try
            {
                viewModel = new EmpresaViewModel();
                List<Empresa> empresas = new List<Empresa>();
                empresas = viewModel.GetEmpresasList();
                if (empresas.Count > 0)
                    //listaEmpresas.BindingContext = empresas;
                    listaEmpresas.ItemsSource = empresas;
                else
                    lblMensaje.Text = "Aún no hay empresas cargadas..."; lblMensaje.IsVisible = true;
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
            int idEmpresa = int.Parse(miItem.CommandParameter.ToString()); 

            App.Current.Properties["IdEmpresa"] = idEmpresa;
            App.Current.Properties["AccionPorHacer"] = "Modificar";

            ABMEmpresa view = new ABMEmpresa();
            await Navigation.PushModalAsync(view);
        }

        private async void actBaja_Clicked(object sender, EventArgs e)
        {
            var miItem = ((MenuItem)sender);
            int idEmpresa = int.Parse(miItem.CommandParameter.ToString());

            App.Current.Properties["IdEmpresa"] = idEmpresa;
            App.Current.Properties["AccionPorHacer"] = "Baja";

            ABMEmpresa view = new ABMEmpresa();
            await Navigation.PushModalAsync(view);
        }
    }
}