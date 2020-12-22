using Repartos.Repository;
using Repartos.ViewModels;
using Repartos.Views.Repartidores;
using Repartos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repartidoress : ContentPage
    {
        RepositoryRepartidores repo;
        public Repartidoress()
        {
            InitializeComponent();
            this.repo = new RepositoryRepartidores();
            this.repo.CrearBBDD();

        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Repartidores.Repartidor view = new Repartidores.Repartidor();
            RepartidorModel viewmodel = new RepartidorModel();

            Models.Repartidor repartidor = e.Item as Models.Repartidor;
            viewmodel.Repartidor = repartidor;
            view.BindingContext = viewmodel;
            await Navigation.PushModalAsync(view);
        }

        //private void srcBuscar_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    srcBuscar.TextChanged += Filtra;
        //}

        //public void Filtra(object sender, TextChangedEventArgs e)
        //{
        //    lstItem.ItemsSource = vm.Repartidores.Where(x => x.IdLinea == li.IdLinea);

        //    string filtro = e.NewTextValue;
        //    lstItem.BeginRefresh();
        //    if (string.IsNullOrWhiteSpace(filtro))
        //        lstItem.ItemsSource = vm.lsProductos.Where(x => x.IdLinea == li.IdLinea);
        //    else
        //        lstItem.ItemsSource = vm.lsProductos.Where(x => x.IdLinea == li.IdLinea).Where(x => x.descripcion.ToUpper().Contains(filtro.ToUpper()));
        //    lstItem.EndRefresh();
        //}
    }
}
