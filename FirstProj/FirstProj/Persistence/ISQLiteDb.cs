using SQLite;

namespace FirstProj
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

