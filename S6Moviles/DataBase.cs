using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace S6Moviles
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
