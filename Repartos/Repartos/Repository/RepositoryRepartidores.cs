using Repartos.Dependencies;
using Repartos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Repartos.Repository
{
    /// <summary>
    ///  Capa de datos
    /// </summary>
    public class RepositoryRepartidores
    {
        private SQLiteConnection con;

        public RepositoryRepartidores()
        {
            // Metodo que establece la conexion.
            this.con = DependencyService.Get<IDataBase>().GetConnection();
        }

        /// <summary>
        ///     Metodo que crea la tabla Repartidores   -   VER COMO FUNCA PARA HACER LA VERIFICACION DE SU EXISTENCIA.
        /// </summary>
        public void CrearBBDD()
        {
            try
            {
                this.con.CreateTable<Repartidor>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Metodo que trae una lista de todos los repartidores     -   VER DE ENVIAR un bool para filtrar por dados de baja.
        /// </summary>
        public List<Repartidor> GetRepartidores()
        {
            try
            {
                var consulta = from datos in con.Table<Repartidor>()
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
        /// Metodo que trae un repartidor mediante su ID.
        /// </summary>
        public Repartidor BuscarRepartidor(int idRepartidor)
        {
            try
            {
                var consulta = from datos in con.Table<Repartidor>()
                               where datos.IdRepartidor == idRepartidor
                               select datos;
                return consulta.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Metodo que insert un repartidor
        /// </summary>
        public bool InsertarRepartidor(int documento, string nombre, string apellido, int telefono,
                                       string direccion, string email, string observacion)
        {
            bool respuesta = false;
            try
            {
                Repartidor repartidor = new Repartidor();
                repartidor.Documento = documento;
                repartidor.Nombre = nombre;
                repartidor.Apellido = apellido;
                repartidor.Telefono = telefono;
                repartidor.Direccion = direccion;
                repartidor.Email = email;
                repartidor.Observaciones = observacion;
                repartidor.FechaAlta = DateTime.Now;
                repartidor.FechaBaja = null;

                this.con.Insert(repartidor);
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que actualiza los datos de un Repartidor 
        /// </summary>
        public bool ModificarRepartidor(int idRepartidor, string nombre, string apellido, int telefono,
                                        string direccion, string email, string observacion, int documento)
        {
            bool respuesta = false;
            try
            {
                Repartidor repartidor = this.BuscarRepartidor(idRepartidor);
                repartidor.Nombre = nombre;
                repartidor.Apellido = apellido;
                repartidor.Documento = documento;
                repartidor.Telefono = telefono;
                repartidor.Direccion = direccion;
                repartidor.Email = email;
                repartidor.Observaciones = observacion;

                this.con.Update(repartidor);

                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que elimina un Repartidor de la Base de Datos.
        /// </summary>
        public bool EliminarRepartidor(int idRepartidor)
        {
            bool respuesta = false;
            try
            {
                Repartidor repartidor = this.BuscarRepartidor(idRepartidor);
                this.con.Delete<Repartidor>(idRepartidor);

                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que da una baja logica a un repartidor.
        /// </summary>
        public bool BajaRepartidor(int idRepartidor)
        {
            bool respuesta = false;
            try
            {
                Repartidor repartidor = this.BuscarRepartidor(idRepartidor);
                repartidor.FechaBaja = DateTime.Now;

                this.con.Update(repartidor);

                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}