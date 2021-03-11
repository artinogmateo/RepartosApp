using Repartos.Models;
using Repartos.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views.Empresas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaEmpresa : ContentPage
    {
        public NuevaEmpresa()
        {
            InitializeComponent();
            HabilitarCampos();

            BindingContext = new EmpresaViewModel();
        }

        private void DesabilitarCampos()
        {
            txtCuit.IsEnabled = false;
            txtDireccionDeCobro.IsEnabled = false;
            txtDireccionRetiroFolletos.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtTelefonoSecundario.IsEnabled = false;
            txtWhatsApp.IsEnabled = false;
            txtTelefonoPrincipal.IsEnabled = false;
            btnGuardar.IsEnabled = false;
        }

        private void HabilitarCampos()
        {
            txtCuit.IsEnabled = true;
            txtDireccionDeCobro.IsEnabled = true;
            txtDireccionRetiroFolletos.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtNombre.IsEnabled = true;
            txtTelefonoSecundario.IsEnabled = true;
            txtWhatsApp.IsEnabled = true;
            txtTelefonoPrincipal.IsEnabled = true;
            btnGuardar.IsEnabled = true;
        }

        private bool ValidarCampos()
        {
            bool noValido = false;
            
            if (txtCuit.Text == "" || txtDireccionDeCobro.Text == "" || txtDireccionRetiroFolletos.Text == "" || txtEmail.Text == "" || txtespacio.Text == "" || txtNombre.Text == ""
                || txtTelefonoPrincipal.Text == "" || txtTelefonoSecundario.Text == "" || txtWhatsApp.Text == "")
            {
                noValido = true;
            }
            
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
                DisplayAlert("Error", "Ocurrió un problema al crear la Empresa.", "Aceptar");
                return;
            }
        }

        private async void ConfirmarGuardar()
        {
            try
            {
                EmpresaViewModel viewmodel = new EmpresaViewModel();
                Empresa empresa = new Empresa();

                empresa.Nombre = txtNombre.Text;
                empresa.CUIT = long.Parse(txtCuit.Text);
                empresa.DireccionRetiroFolletos = txtDireccionRetiroFolletos.Text;
                empresa.DireccionDeCobro = txtDireccionDeCobro.Text;
                empresa.TelefonoPrimario = txtTelefonoPrincipal.Text;
                empresa.TelefonoSecundario = txtTelefonoSecundario.Text;
                empresa.WhatsApp = txtWhatsApp.Text;
                empresa.Email = txtEmail.Text;
                empresa.FechaAlta = DateTime.Now;

                int respuesta = viewmodel.Guardar(empresa);
                if (respuesta > 0)
                {
                    DesabilitarCampos();
                    lblTitulo.Text = "Datos de la Empresa";

                    await DisplayAlert("Aviso", "La empresa se guardó correctamente", "Aceptar");

                    Empresas view = new Empresas();
                    await Navigation.PushModalAsync(view);
                }
                else
                    DisplayAlert("Error", "Ocurrió un error al intentar guardar la Empresa", "Aceptar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ocurrió un problema al crear la Empresa.", "Aceptar");
                return;
            }            
        }

        private void txtTelefonoPrincipal_Focused(object sender, FocusEventArgs e)
        {
            lblTelefonoPrincipal.IsVisible = true;
        }

        private void txtTelefonoPrincipal_Unfocused(object sender, FocusEventArgs e)
        {
            if (txtTelefonoPrincipal.Text == "")
                lblTelefonoPrincipal.IsVisible = false;
        }

        private void txtTelefonoPrincipal_Completed(object sender, EventArgs e)
        {

        }
    }
}