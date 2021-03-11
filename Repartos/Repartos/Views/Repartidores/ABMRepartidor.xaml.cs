using Repartos.DataAccessLayer;
using Repartos.Models;
using Repartos.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repartos.Views.Repartidores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ABMRepartidor : ContentPage
    {
        RepartidorDAL repo;
        public RepartidorViewModel viewModel { get; set; }

        public static string accion = "";
        public static int idRepartidor = 0;

        public ABMRepartidor()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                viewModel = new RepartidorViewModel();
                HabilitarCampos();

                if (Application.Current.Properties.ContainsKey("IdRepartidor") && Application.Current.Properties.ContainsKey("AccionPorHacer"))
                {
                    var val = Application.Current.Properties["AccionPorHacer"];
                    var val2 = Application.Current.Properties["IdRepartidor"];

                    accion = val.ToString();
                    idRepartidor = int.Parse(val2.ToString());

                    if (accion == "Modificar")
                    {
                        lblTitulo.Text = "MODIFICAR DATOS DEL REPARTIDOR";
                        btnGuardar.Text = "Guardar";
                        btnGuardar.IsEnabled = true;
                        btnGuardar.IsVisible = true;
                        HabilitarCampos();
                        CamposQuitarSoloLectura();
                    }
                    else if (accion == "Baja")
                    {
                        lblTitulo.Text = "DAR DE BAJA EL REPARTIDOR";
                        btnGuardar.Text = "DAR BAJA";
                        btnGuardar.IsEnabled = true;
                        btnGuardar.IsVisible = true;
                        //DesabilitarCampos();
                        CamposSoloLectura();
                    }
                    else if (accion == "Ver")
                    {
                        lblTitulo.Text = "DATOS DEL REPARTIDOR";
                        btnGuardar.IsVisible = false;
                        btnGuardar.IsEnabled = false;
                        CamposSoloLectura();
                    }
                    else
                        DisplayAlert("Error", "Ocurrió un error al obtener los datos del repartidor", "Aceptar");

                    CargarCampos();
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ocurrió un error al obtener los datos del repartidor", "Aceptar");
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
            Repartidor repartidor = new Repartidor();
            viewModel = new RepartidorViewModel();
            string respuesta = "";

            if (accion == "Baja")
            {
                repartidor.IdRepartidor = idRepartidor;
                respuesta = viewModel.BajaRepartidor(repartidor.IdRepartidor);

                if (respuesta == "ok")
                {
                    await DisplayAlert("Aviso", "Repartidor dado de baja con éxito", "Aceptar");
                    Repartidores view = new Repartidores();
                    await Navigation.PushModalAsync(view);
                }
                else
                    DisplayAlert("Error", "Ocurrió un error al procesar la información.", "Aceptar");
            }
            else
            {
                repartidor.IdRepartidor = idRepartidor;
                repartidor.Nombre = txtNombre.Text;
                repartidor.Documento = long.Parse(txtDocumento.Text);
                repartidor.Direccion = txtDireccion.Text;
                repartidor.Email = txtEmail.Text;
                repartidor.Observaciones = txtObservaciones.Text;
                repartidor.Telefono = long.Parse(txtTelefono.Text);
                repartidor.Apellido = txtApellido.Text;

                respuesta = viewModel.ModificarRepartidor(repartidor);
                if (respuesta == "ok")
                {
                    DesabilitarCampos();
                    btnGuardar.IsEnabled = false;
                    lblTitulo.Text = "DATOS DEL REPARTIDOR";

                    await DisplayAlert("Aviso", "La repartidor se modificó correctamente", "Aceptar");

                    Repartidores view = new Repartidores();
                    await Navigation.PushModalAsync(view);
                }
                else
                    DisplayAlert("Error", "Ocurrió un error al procesar la información.", "Aceptar");
            }
        }

        private void DesabilitarCampos()
        {
            txtDireccion.IsEnabled = false;
            txtDocumento.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtObservaciones.IsEnabled = false;
            txtFechaIngreso.IsEnabled = false;
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
            txtFechaIngreso.IsEnabled = true;
            txtTelefono.IsEnabled = true;
        }

        private void CamposQuitarSoloLectura()
        {
            txtDireccion.IsReadOnly = false;
            txtDocumento.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtNombre.IsReadOnly = false;
            txtApellido.IsReadOnly = false;
            txtObservaciones.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
        }

        private void CamposSoloLectura()
        {
            txtDireccion.IsReadOnly = true;
            txtDocumento.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtNombre.IsReadOnly = true;
            txtApellido.IsReadOnly = true;
            txtObservaciones.IsReadOnly = true;
            txtFechaIngreso.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;
        }

        private void CargarCampos()
        {
            Repartidor repartidor = new Repartidor();
            viewModel = new RepartidorViewModel();

            repartidor = viewModel.BuscarRepartidorPorID(idRepartidor);

            if (repartidor.IdRepartidor > 0)
            {
                txtDireccion.Text = repartidor.Direccion;
                txtDocumento.Text = repartidor.Documento.ToString();
                txtEmail.Text = repartidor.Email;
                txtNombre.Text = repartidor.Nombre;
                txtApellido.Text = repartidor.Apellido;
                txtObservaciones.Text = repartidor.Observaciones;
                txtTelefono.Text = repartidor.Telefono.ToString();
                txtFechaIngreso.Text = repartidor.FechaAlta.ToString(format: "D");
            }
        }

        private void txtTelefono_Focused(object sender, FocusEventArgs e)
        {

        }

        private void txtTelefono_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}