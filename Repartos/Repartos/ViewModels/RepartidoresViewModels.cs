using Repartos.Base;
using Repartos.Models;
using Repartos.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Repartos.ViewModels
{
    public class RepartidoresViewModels : ViewModelBase
    {
        public RepartidoresViewModels()
        {
            RepositoryRepartidores repo = new RepositoryRepartidores();
            List<Repartidor> lista = repo.GetRepartidores();
            this.Repartidores = new ObservableCollection<Repartidor>(lista);
        }

        private ObservableCollection<Repartidor> _Repartidores;

        public ObservableCollection<Repartidor> Repartidores
        {
            get { return this._Repartidores; }
            set
            {
                this._Repartidores = value;
                OnPropertyChanged("Repartidores");
            }
        }
    }
}

