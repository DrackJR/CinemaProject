namespace CinemaProject.Data
{
    public static class DbConfig
    {
        public static string ConnectionString
        {
            get { return "Host=localhost;Port=5432;Database=cinema_db;Username=postgres;Password=987"; }
        }
    }
}