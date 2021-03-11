using Repartos.DataAccessLayer;
using Repartos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Repartos.ViewModels
{
    public class RepartidorViewModel : BaseViewModel
    {
        RepartidorDAL RepartidorDAL = new RepartidorDAL();

        public RepartidorViewModel()
        {

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

        public void GetRepartidores()
        {
            try
            {
                List<Repartidor> repartidores = RepartidorDAL.GetRepartidores();
                Repartidores = new ObservableCollection<Repartidor>(repartidores);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Repartidor> GetRepartidoresList()
        {
            List<Repartidor> repartidores = new List<Repartidor>();
            try
            {
                repartidores = RepartidorDAL.GetRepartidores();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return repartidores;
        }

        public Repartidor BuscarRepartidorPorID(int idRepartidor)
        {
            Repartidor repartidor = new Repartidor();
            try
            {
                repartidor = RepartidorDAL.BuscarRepartidorPorID(idRepartidor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return repartidor;
        }

        public int Guardar(Repartidor nuevoRepartidor)
        {
            int respuesta = 0;
            try
            {
                nuevoRepartidor.IdRepartidor = RepartidorDAL.GuardarRepartidor(nuevoRepartidor);

                respuesta = nuevoRepartidor.IdRepartidor;
            }
            catch (Exception ex)
            {

                throw;
            }
            return respuesta;
        }

        public string BajaRepartidor(int idRepartidor)
        {
            string respuesta = "";
            try
            {
                respuesta = RepartidorDAL.BajaRepartidor(idRepartidor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return respuesta;
        }

        public string ModificarRepartidor(Repartidor repartidor)
        {
            string respuesta = "";
            try
            {
                respuesta = RepartidorDAL.ModificarRepartidor(repartidor);
            }
            catch (Exception ex)
            {

                throw;
            }
            return respuesta;
        }
    }
}
