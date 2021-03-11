using Repartos.Dependencies;
using Repartos.Droid;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteClient))]
namespace Repartos.Droid
{
    public class SqLiteClient : IDataBase
    {
        /// <summary>
        /// Metodo que busca la cadena de conexion creada en el dispositivo    -    si no la encuentra realiza la cracion de la misma.
        /// </summary>
        public SQLiteConnection GetConnection()
        {
            String bbddfile = "REPARTOSapp.db3";
            String rutadocumentos = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String path = Path.Combine(rutadocumentos, bbddfile);
            SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(path);
            return cn;
        }
    }
}

