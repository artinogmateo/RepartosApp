using Repartos.DataAccessLayer;
using Repartos.Models;
using Repartos.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views.Empresas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ABMEmpresa : ContentPage
    {
        EmpresaDAL repo;
        public EmpresaViewModel viewModel { get; set; }

        public static string accion = "";
        public static int idEmpresa = 0;

        public ABMEmpresa()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                viewModel = new EmpresaViewModel();
                HabilitarCampos();

                if (Application.Current.Properties.ContainsKey("IdEmpresa") && Application.Current.Properties.ContainsKey("AccionPorHacer"))
                {
                    var val = Application.Current.Properties["AccionPorHacer"];
                    var val2 = Application.Current.Properties["IdEmpresa"];

                    accion = val.ToString();
                    idEmpresa = int.Parse(val2.ToString());

                    if (accion == "Modificar")
                    {
                        lblTitulo.Text = "MODIFICAR DATOS DE LA EMPRESA";
                        btnGuardar.Text = "Guardar";
                        btnGuardar.IsEnabled = true;
                        btnGuardar.IsVisible = true;
                        HabilitarCampos();
                        CamposQuitarSoloLectura();
                    }
                    else if (accion == "Baja")
                    {
                        lblTitulo.Text = "DAR DE BAJA LA EMPRESA";
                        btnGuardar.Text = "DAR BAJA";
                        btnGuardar.IsEnabled = true;
                        btnGuardar.IsVisible = true;
                        //DesabilitarCampos();
                        CamposSoloLectura();
                    }
                    else if (accion == "Ver")
                    {
                        lblTitulo.Text = "DATOS DE LA EMPRESA";
                        btnGuardar.IsVisible = false;
                        btnGuardar.IsEnabled = false;
                        CamposSoloLectura();
                    }
                    else
                        DisplayAlert("Error", "Ocurrió un error al obtener los datos de la empresa", "Aceptar");

                    CargarCampos();
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ocurrió un error al obtener los datos de la empresa", "Aceptar");
                return;
            }
        }

        private void txtTelefonoPrincipal_Unfocused(object sender, FocusEventArgs e)
        {

        }

        private void txtTelefonoPrincipal_Focused(object sender, FocusEventArgs e)
        {

        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();
            viewModel = new EmpresaViewModel();
            string respuesta = "";

            if (accion == "Baja")
            {
                empresa.IdEmpresa = idEmpresa;
                respuesta = viewModel.BajaEmpresa(empresa.IdEmpresa);

                if (respuesta == "ok")
                {
                    await DisplayAlert("Aviso", "Empresa dada de baja con éxito", "Aceptar");

                    Empresas view = new Empresas();
                    await Navigation.PushModalAsync(view);
                }
                else
                    DisplayAlert("Error", "Ocurrió un error al procesar la información.", "Aceptar");
            }
            else
            {
                empresa.IdEmpresa = idEmpresa;
                empresa.Nombre = txtNombre.Text;
                empresa.CUIT = long.Parse(txtCuit.Text);
                empresa.DireccionRetiroFolletos = txtDireccionRetiroFolletos.Text;
                empresa.DireccionDeCobro = txtDireccionDeCobro.Text;
                empresa.TelefonoPrimario = txtTelefonoPrincipal.Text;
                empresa.TelefonoSecundario = txtTelefonoSecundario.Text;
                empresa.WhatsApp = txtWhatsApp.Text;
                empresa.Email = txtEmail.Text;

                respuesta = viewModel.ModificarEmpresa(empresa);
                if (respuesta == "ok")
                {
                    DesabilitarCampos();
                    btnGuardar.IsEnabled = false;
                    lblTitulo.Text = "DATOS DE LA EMPRESA";

                    await DisplayAlert("Aviso", "La empresa se modificó correctamente", "Aceptar");

                    Empresas view = new Empresas();
                    await Navigation.PushModalAsync(view);
                }
                else
                    DisplayAlert("Error", "Ocurrió un error al procesar la información.", "Aceptar");
            }
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
            txtFechaIngreso.IsEnabled = false;
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
        }

        private void CamposQuitarSoloLectura()
        {
            txtCuit.IsReadOnly = false;
            txtDireccionDeCobro.IsReadOnly = false;
            txtDireccionRetiroFolletos.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtNombre.IsReadOnly = false;
            txtTelefonoSecundario.IsReadOnly = false;
            txtWhatsApp.IsReadOnly = false;
            txtTelefonoPrincipal.IsReadOnly = false;
        }

        private void CamposSoloLectura()
        {
            txtCuit.IsReadOnly = true;
            txtDireccionDeCobro.IsReadOnly = true;
            txtDireccionRetiroFolletos.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtNombre.IsReadOnly = true;
            txtTelefonoSecundario.IsReadOnly = true;
            txtWhatsApp.IsReadOnly = true;
            txtTelefonoPrincipal.IsReadOnly = true;
            txtFechaIngreso.IsReadOnly = true;
        }

        private void CargarCampos()
        {
            Empresa empresa = new Empresa();
            viewModel = new EmpresaViewModel();

            empresa = viewModel.BuscarEmpresaPorID(idEmpresa);

            if (empresa.IdEmpresa > 0)
            {
                txtCuit.Text = empresa.CUIT.ToString();
                txtDireccionDeCobro.Text = empresa.DireccionDeCobro;
                txtDireccionRetiroFolletos.Text = empresa.DireccionRetiroFolletos;
                txtEmail.Text = empresa.Email;
                txtNombre.Text = empresa.Nombre;
                txtTelefonoSecundario.Text = empresa.TelefonoSecundario;
                txtTelefonoPrincipal.Text = empresa.TelefonoPrimario;
                txtWhatsApp.Text = empresa.WhatsApp;
                txtFechaIngreso.Text = empresa.FechaAlta.ToString(format: "D");
            }
        }
    }
}