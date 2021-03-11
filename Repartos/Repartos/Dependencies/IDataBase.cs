using System;
using System.Collections.Generic;
using System.Text;

namespace Repartos.Dependencies
{
    public interface IDataBase
    {
        /// <summary>
        /// Metodo que busca el archivo de base de datos almacenado en el Device Mobile para realizar la conexion con la misma
        /// </summary>
        SQLite.SQLiteConnection GetConnection();
    }
}

