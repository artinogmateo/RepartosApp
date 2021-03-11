using Repartos.Dependencies;
using Repartos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Repartos.DataAccessLayer
{
    public class EmpresaDAL
    {
        // establecemos la variable global de la clase.
        private SQLiteConnection con;

        public EmpresaDAL()
        {
            // Metodo que establece la conexion.
            this.con = DependencyService.Get<IDataBase>().GetConnection();
        }

        /// <summary>
        ///     Metodo que crea la tabla Empresa en la BD
        /// </summary>
        public void CrearBBDD()
        {
            try
            {
                this.con.CreateTable<Empresa>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Metodo que trae una lista de todos las empresas     -   VER DE ENVIAR un bool para filtrar por dados de baja.
        /// </summary>
        public List<Empresa> GetEmpresas()
        {
            try
            {
                var consulta = from datos in con.Table<Empresa>()
                               where datos.FechaBaja == null
                               select datos;
                    return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que trae una empresa mediante su ID.
        /// </summary>
        public Empresa BuscarEmpresaPorID(int idEmpresa)
        {
            try
            {
                var consulta = from datos in con.Table<Empresa>()
                               where datos.IdEmpresa == idEmpresa
                               select datos;
                return consulta.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Metodo que insert una empresa
        /// </summary>
        public int GuardarEmpresa(Empresa nuevaEmpresa)
        {
            int respuesta = 0;
            try
            {
                Empresa empresa = new Empresa();
                empresa.CUIT = nuevaEmpresa.CUIT;
                empresa.DireccionDeCobro = nuevaEmpresa.DireccionDeCobro;
                empresa.DireccionRetiroFolletos = nuevaEmpresa.DireccionRetiroFolletos;
                empresa.Email = nuevaEmpresa.Email;
                empresa.FechaAlta = nuevaEmpresa.FechaAlta;
                empresa.FechaBaja = null;
                empresa.Nombre = nuevaEmpresa.Nombre;
                empresa.TelefonoPrimario = nuevaEmpresa.TelefonoPrimario;
                empresa.TelefonoSecundario = nuevaEmpresa.TelefonoSecundario;
                empresa.WhatsApp = nuevaEmpresa.WhatsApp;

                this.con.Insert(empresa);

                respuesta = this.con.ExecuteScalar<int>("SELECT last_insert_rowid()");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que actualiza los datos de una empresa.
        /// </summary>
        public string ModificarEmpresa(Empresa empresaModificada)
        {
            string respuesta = "";
            try
            {
                Empresa empresa = this.BuscarEmpresaPorID(empresaModificada.IdEmpresa);
                empresa.CUIT = empresaModificada.CUIT;
                empresa.DireccionDeCobro = empresaModificada.DireccionDeCobro;
                empresa.DireccionRetiroFolletos = empresaModificada.DireccionRetiroFolletos;
                empresa.Email = empresaModificada.Email;
                empresa.Nombre = empresaModificada.Nombre;
                empresa.TelefonoPrimario = empresaModificada.TelefonoPrimario;
                empresa.TelefonoSecundario = empresaModificada.TelefonoSecundario;
                empresa.WhatsApp = empresaModificada.WhatsApp;

                this.con.Update(empresa);                   // debuguear para confirmar de que actualice solo los datos que se envian y no toda la empresa. 

                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error, " + ex.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que elimina una Empresa de la Base de Datos.
        /// </summary>
        public bool EliminarEmpresa(int idEmpresa)
        {
            bool respuesta = false;                 // tratar de no usar este metodo.
            try
            {
                Empresa empresa = this.BuscarEmpresaPorID(idEmpresa);
                this.con.Delete<Empresa>(idEmpresa);

                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que da una baja logica a una Empresa.
        /// </summary>
        public string BajaEmpresa(int idEmpresa)
        {
            string respuesta = "";
            try
            {
                Empresa empresa = this.BuscarEmpresaPorID(idEmpresa);
                empresa.FechaBaja = DateTime.Now;

                this.con.Update(empresa);

                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error, " + ex.Message;
            }
            return respuesta;
        }
    }
}
