using System;
using System.Collections.Generic;
using System.Text;

namespace Repartos.Dependencies
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}

