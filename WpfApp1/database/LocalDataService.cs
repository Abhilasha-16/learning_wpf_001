using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WpfApp1.Interfaces
{
    public interface LocalDataService
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
