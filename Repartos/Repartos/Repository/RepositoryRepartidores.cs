using Repartos.Dependencies;
using Repartos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Repartos.Repository
{
    public class RepositoryRepartidores
    {
        private SQLiteConnection con;
        public RepositoryRepartidores()
        {
            this.con = DependencyService.Get<IDataBase>().GetConnection();
        }

        //------------------MÉTODOS CON SUS CONSULTAS:
        public void CrearBBDD()
        {
            this.con.CreateTable<Repartidor>();
        }

        public List<Repartidor> GetRepartidores()
        {
            var consulta = from datos in con.Table<Repartidor>()
                           where datos.FechaBaja == null 
                           select datos;
            return consulta.ToList();
        }

        public Repartidor BuscarRepartidor(int idRepartidor)
        {
            var consulta = from datos in con.Table<Repartidor>()
                           where datos.IdRepartidor == idRepartidor
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertarRepartidor(int idRepartidor, string nombre, string apellido, int telefono, 
            string direccion, int edad,  string email, string observacion)
        {
            Repartidor repartidor = new Repartidor();
            repartidor.IdRepartidor = idRepartidor;
            repartidor.Nombre = nombre;
            repartidor.Apellido = apellido;
            repartidor.Telefono = telefono;
            repartidor.Direccion = direccion;
            repartidor.Edad = edad;
            repartidor.Email = email;
            repartidor.Observaciones = observacion;
            repartidor.FechaAlta = DateTime.Now;
            repartidor.FechaBaja = null;

            this.con.Insert(repartidor);
        }

        public void ModificarRepartidor(int idRepartidor, string nombre, string apellido, int telefono, 
            string direccion, int edad, string email, string observacion)
        {
            Repartidor repartidor = this.BuscarRepartidor(idRepartidor);
            repartidor.Nombre = nombre;
            repartidor.Apellido = apellido;
            repartidor.Telefono = telefono;
            repartidor.Direccion = direccion;
            repartidor.Edad = edad;
            repartidor.Email = email;
            repartidor.Observaciones = observacion;

            this.con.Update(repartidor);
        }

        public void EliminarRepartidor(int idRepartidor)
        {
            Repartidor raz = this.BuscarRepartidor(idRepartidor);
            this.con.Delete<Repartidor>(idRepartidor);
        }

        public void BajaRepartidor(int idRepartidor)
        {
            Repartidor repartidor = this.BuscarRepartidor(idRepartidor);
            repartidor.FechaBaja = DateTime.Now;

            this.con.Update(repartidor);
        }
    }
}

