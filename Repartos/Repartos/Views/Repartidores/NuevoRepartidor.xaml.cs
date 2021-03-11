using Repartos.Models;
using Repartos.ViewModels;
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
    public partial class NuevoRepartidor : ContentPage
    {
        public NuevoRepartidor()
        {
            InitializeComponent();
            HabilitarCampos();

            BindingContext = new RepartidorViewModel();
        }

        private void DesabilitarCampos()
        {
            txtDireccion.IsEnabled = false;
            txtDocumento.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtObservaciones.IsEnabled = false;
            txtespacio.IsEnabled = false;
            txtTelefono.IsEnabled = false;
        }

        private void HabilitarCampos()
        {
            txtDireccion.IsEnabled = true;
            txtDocumento.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtObservaciones.IsEnabled = true;
            txtespacio.IsEnabled = true;
            txtTelefono.IsEnabled = true;
        }

        private bool ValidarCampos()
        {
            bool noValido = false;

            //if (txtCuit.Text == "" || txtDireccionDeCobro.Text == "" || txtDireccionRetiroFolletos.Text == "" || txtEmail.Text == "" || txtespacio.Text == "" || txtNombre.Text == ""
            //    || txtTelefonoPrincipal.Text == "" || txtTelefonoSecundario.Text == "" || txtWhatsApp.Text == "")
            //{
            //    noValido = true;
            //}

            return noValido;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool noEsValido = ValidarCampos();
                if (noEsValido)
                {
                    var result = await DisplayAlert("Aviso", "Hay campos sin completar", "Guardar", "Cancelar");
                    if (result == true)
                        ConfirmarGuardar();
                    else
                        return;
                }
                else
                    ConfirmarGuardar();
            }
            catch (System.Exception ex)
            {
                DisplayAlert("Error", "Ocurrió un problema al crear el Repartidor.", "Aceptar");
                return;
            }
        }

        private async void ConfirmarGuardar()
        {
            try
            {
                RepartidorViewModel viewmodel = new RepartidorViewModel();
                Repartidor repartidor = new Repartidor();

                repartidor.Nombre = txtNombre.Text;
                repartidor.Documento = long.Parse(txtDocumento.Text);
                repartidor.Direccion = txtDireccion.Text;
                repartidor.Observaciones = txtObservaciones.Text;
                repartidor.Telefono = long.Parse(txtTelefono.Text);
                repartidor.Apellido = txtApellido.Text;
                repartidor.Email = txtEmail.Text;
                repartidor.FechaAlta = DateTime.Now;

                int respuesta = viewmodel.Guardar(repartidor);
                if (respuesta > 0)
                {
                    DesabilitarCampos();
                    lblTitulo.Text = "Datos de el Repartidor";

                    await DisplayAlert("Aviso", "El repartidor se guardo correctamente", "Aceptar");

                    Repartidores view = new Repartidores();
                    await Navigation.PushModalAsync(view);
                }
                else
                    DisplayAlert("Error", "Ocurrió un error al intentar guardar el Repartidor", "Aceptar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ocurrió un problema al crear el Repartidor.", "Aceptar");
                return;
            }
        }
    }
}