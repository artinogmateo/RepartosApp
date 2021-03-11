using Repartos.Dependencies;
using Repartos.iOS;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteClient))]
namespace Repartos.iOS
{
    public class SqLiteClient : IDataBase
    {
        /// <summary>
        /// Metodo que busca la cadena de conexion creada en el dispositivo    -    si no la encuentra realiza la cracion de la misma.
        /// </summary>
        public SQLiteConnection GetConnection()
        {
            String bbddfile = "REPARTOSapp.db";
            string rutadocumentos = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string librarypath = Path.Combine(rutadocumentos, "..", "Library", "Databases");
            if (!Directory.Exists(librarypath))
            {
                Directory.CreateDirectory(librarypath);
            }
            string path = Path.Combine(librarypath, bbddfile);
            SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}

