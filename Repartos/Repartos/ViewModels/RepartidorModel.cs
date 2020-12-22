using Repartos.Base;
using Repartos.Models;
using Repartos.Repository;
using Xamarin.Forms;

namespace Repartos.ViewModels
{
    public class RepartidorModel : ViewModelBase
    {
        RepositoryRepartidores repo;
        public RepartidorModel()
        {
            this.repo = new RepositoryRepartidores();
            this.Repartidor = new Repartidor();
        }

        public Command InsertarRepartidor
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.InsertarRepartidor(this.Repartidor.IdRepartidor,
                        Repartidor.Nombre, Repartidor.Apellido, Repartidor.Telefono, Repartidor.Direccion,
                        Repartidor.Edad, Repartidor.Email, Repartidor.Observaciones);
                });
            }
        }

        public Command ModificarRepartidor
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.ModificarRepartidor(this.Repartidor.IdRepartidor,
                        Repartidor.Nombre, Repartidor.Apellido, Repartidor.Telefono, Repartidor.Direccion,
                        Repartidor.Edad, Repartidor.Email, Repartidor.Observaciones
                        );
                });
            }
        }

        public Command EliminarRepartidor
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.EliminarRepartidor(this.Repartidor.IdRepartidor
                        );
                });
            }
        }

        public Command BajaRepartidor
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.BajaRepartidor(this.Repartidor.IdRepartidor
                        );
                });
            }
        }

        private Repartidor _Repartidor;
        public Repartidor Repartidor
        {
            get { return this._Repartidor; }
            set
            {
                this._Repartidor = value;
                OnPropertyChanged("Repartidor");
            }
        }
    }
}
