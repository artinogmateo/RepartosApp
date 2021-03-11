using Repartos.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHamburguesa : MasterDetailPage
    {
        public MenuHamburguesa()
        {
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            //Detail = new NavigationPage(new Repartidor());
            //List<Menu> menu = new List<Menu>
            //{
            //    //new Menu{ Page= new Repartidor(), MenuTitle="Repartidor", MenuDetail="Detalles del Repartidor"},
            //    //new Menu{ Page= new AgregarRepartidor(), MenuTitle="Agregar Repartidor", MenuDetail="Datos del nuevo repartidor"},
            //    //new Menu{ Page= new ModificarRepartidor(), MenuTitle=Lang[6], MenuDetail=Lang[7], icon="settings.png"},
            //    //new Menu{ Page= new AgregarRepartidor(), MenuTitle="Agregar Repartidor", MenuDetail="Datos del nuevo repartidor"},
            //};
            //lstMenu.ItemsSource = menu;
        }

        private void lstMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                //IsPresented = false;
                Detail = new NavigationPage(menu.Page);
                //await Navigation.PushModalAsync(view);
            }
        }

        public class Menu
        {
            public string MenuTitle { get; set; }
            public string MenuDetail { get; set; }
            public ImageSource icon { get; set; }
            public Page Page { get; set; }
        }
    }
}