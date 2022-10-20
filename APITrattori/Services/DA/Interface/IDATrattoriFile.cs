using APITrattori.Models;

namespace APITrattori.Services.DA.Interface
{
    public interface IDATrattoriFile
    {
        void AddSingleTrattore(Trattore fullTrattore);
        IEnumerable<Trattore> GetAll();
        Trattore GetById(int idTrattore);
    }
}
