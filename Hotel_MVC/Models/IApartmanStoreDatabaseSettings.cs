namespace Hotel_MVC.Models
{
    public interface IApartmanStoreDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string HotelCollectionName { get; set; }

    }
}
