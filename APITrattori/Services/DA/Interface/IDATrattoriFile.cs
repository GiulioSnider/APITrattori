using APITrattori.Models;

namespace APITrattori.Services.DA.Interface
{
    public interface IDATrattoriFile
    {
        void AddSingleTrattore(Trattore fullTrattore);
        void Delete(Trattore trattoreToDelete);
        IEnumerable<Trattore> GetAll();
        IEnumerable<Trattore> GetByColor(Colore colore);
        Trattore GetById(int idTrattore);
    }
}
