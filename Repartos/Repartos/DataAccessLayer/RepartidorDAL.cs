using Repartos.Dependencies;
using Repartos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Repartos.DataAccessLayer
{
    public class RepartidorDAL
    {
        private SQLiteConnection con;

        public RepartidorDAL()
        {
            this.con = DependencyService.Get<IDataBase>().GetConnection();
        }

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

        public Repartidor BuscarRepartidorPorID(int idRepartidor)
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

        public int GuardarRepartidor(Repartidor nuevoRepartidor)
        {
            int respuesta = 0;
            try
            {
                Repartidor repartidor = new Repartidor();
                repartidor.Nombre = nuevoRepartidor.Nombre;
                repartidor.Apellido = nuevoRepartidor.Apellido;
                repartidor.Direccion = nuevoRepartidor.Direccion;
                repartidor.Email = nuevoRepartidor.Email;
                repartidor.Documento = nuevoRepartidor.Documento;
                repartidor.FechaAlta = DateTime.Now;
                repartidor.FechaBaja = null;
                repartidor.Observaciones = nuevoRepartidor.Observaciones;
                repartidor.Telefono = nuevoRepartidor.Telefono;

                this.con.Insert(repartidor);

                respuesta = this.con.ExecuteScalar<int>("SELECT last_insert_rowid()");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public string ModificarRepartidor(Repartidor repartidorModificado)
        {
            string respuesta = "";
            try
            {
                Repartidor repartidor = this.BuscarRepartidorPorID(repartidorModificado.IdRepartidor);
                repartidor.Nombre = repartidorModificado.Nombre;
                repartidor.Apellido = repartidorModificado.Apellido;
                repartidor.Direccion = repartidorModificado.Direccion;
                repartidor.Email = repartidorModificado.Email;
                repartidor.Documento = repartidorModificado.Documento;
                repartidor.Observaciones = repartidorModificado.Observaciones;
                repartidor.Telefono = repartidorModificado.Telefono;

                this.con.Update(repartidor);        

                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error, " + ex.Message;
            }
            return respuesta;
        }

        public bool EliminarRepartidor(int idRepartidor)
        {
            bool respuesta = false;                 
            try
            {
                Repartidor repartidor = this.BuscarRepartidorPorID(idRepartidor);
                this.con.Delete<Repartidor>(idRepartidor);

                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public string BajaRepartidor(int idRepartidor)
        {
            string respuesta = "";
            try
            {
                Repartidor repartidor = this.BuscarRepartidorPorID(idRepartidor);
                repartidor.FechaBaja = DateTime.Now;

                this.con.Update(repartidor);

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
