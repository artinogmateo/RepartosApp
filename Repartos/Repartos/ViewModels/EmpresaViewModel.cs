using Repartos.DataAccessLayer;
using Repartos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Repartos.ViewModels
{
    public class EmpresaViewModel : BaseViewModel
    {
        // instanciamos la clase para consumir sus metodos.
        EmpresaDAL EmpresaDAL = new EmpresaDAL();

        public EmpresaViewModel()
        {

        }

        /// <summary>
        /// propiedades de la lista de objetos.
        /// </summary>
        private ObservableCollection<Empresa> _Empresas;

        public ObservableCollection<Empresa> Empresas
        {
            get { return this._Empresas; }
            set
            {
                this._Empresas = value;
                OnPropertyChanged("Empresas");
            }
        }

        /// <summary>
        /// propiedades del objeto.
        /// </summary>
        private Empresa _Empresa;

        public Empresa Empresa
        {
            get { return this._Empresa; }
            set
            {
                this._Empresa = value;
                OnPropertyChanged("Empresa");
            }
        }

        /// <summary>
        /// Metodo que lista las empresas en forma de ObservableCollection.
        /// </summary>
        public void GetEmpresas()
        {
            try
            {
                List<Empresa> empresas = EmpresaDAL.GetEmpresas();
                Empresas = new ObservableCollection<Empresa>(empresas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Metodo que lista las empresas en forma de Lista.
        /// </summary>
        public List<Empresa> GetEmpresasList()
        {
            List<Empresa> empresas = new List<Empresa>();
            try
            {
                empresas = EmpresaDAL.GetEmpresas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return empresas;
        }

        /// <summary>
        /// Metodo que trae una empresa por su ID. 
        /// </summary>
        public Empresa BuscarEmpresaPorID(int idEmpresa)
        {
            Empresa empresa = new Empresa();
            try
            {
                empresa = EmpresaDAL.BuscarEmpresaPorID(idEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return empresa;
        }

        /// <summary>
        /// Metodo que Guarda una empresa.
        /// </summary>
        public int Guardar(Empresa nuevaEmpresa)
        {
            int respuesta = 0;
            try
            {
                nuevaEmpresa.IdEmpresa = EmpresaDAL.GuardarEmpresa(nuevaEmpresa);

                respuesta = nuevaEmpresa.IdEmpresa;
            }
            catch (Exception ex)
            {

                throw;
            }
            return respuesta;
        }

        public string BajaEmpresa(int idEmpresa)
        {
            string respuesta = "";
            try
            {
                respuesta = EmpresaDAL.BajaEmpresa(idEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return respuesta;
        }

        public string ModificarEmpresa(Empresa empresa)
        {
            string respuesta = "";
            try
            {
                respuesta = EmpresaDAL.ModificarEmpresa(empresa);
            }
            catch (Exception ex)
            {

                throw;
            }
            return respuesta;
        }
    }
}
