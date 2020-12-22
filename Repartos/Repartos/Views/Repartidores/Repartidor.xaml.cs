using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views.Repartidores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repartidor : ContentPage
    {
        public Repartidor()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ///modal de carga por tiempo.
            //UserDialogs.Instance.ShowLoading(title:"Cargando Perri");

            //await Task.Delay(5000);

            //UserDialogs.Instance.HideLoading();

            //await DisplayAlert(title: "Detalle de la Carga",
            //    message:"Ya pasaron 5 segundos y esta todo ok",
            //    cancel: "Ok");  


            ///////////////////////////////////////////////////////////////////////////////////////////////////


            ///modal de carga con conteo de porcentaje por tiempo + modal de carga.
            //using (var dialog = UserDialogs.Instance.Progress(title: "Cargando Perri"))
            //{
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        await Task.Delay(1000);
            //        dialog.PercentComplete = i * 10;
            //    }
            //}


            ///////////////////////////////////////////////////////////////////////////////////////////////////


            ///modal de carga con conteo de porcentaje por tiempo + modal de carga con boton cancelar.
            ///con el metodo onCancel() podriamos revertir algun cambio en la BD si es que quisieramos... Puede Servir che.
            bool cancelada = false;

            using (var dialog = UserDialogs.Instance.Progress(title: "Cargando Perri",
                onCancel:() => cancelada = true, cancelText:"Cancelate esto Perri"))
            {
                for (int i = 1; i <= 10; i++)
                {
                    await Task.Delay(1000);
                    if (!cancelada)
                        dialog.PercentComplete = i * 10;
                }
            }
        }
    }
}