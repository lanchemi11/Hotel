namespace Hotel_MVC.Models
{
    public class ApartmanStoreDatabaseSettings : IApartmanStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        public string HotelCollectionName { get; set; } = String.Empty;
    }
}
