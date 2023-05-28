using Hotel_MVC.Models;

namespace Hotel_MVC.Services
{
    public interface IApartmanService
    {
        List<Apartman> Get();
        Apartman Get(string id);
        Apartman Create(Apartman apartman);
        void Update(string id,Apartman apartman);
        void Remove(string id);
    }
}
