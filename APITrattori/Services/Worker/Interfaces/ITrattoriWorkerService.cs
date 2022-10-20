using APITrattori.Models;

namespace APITrattori.Services.Worker.Interfaces
{
    public interface ITrattoriWorkerService
    {
        void DeleteById(int idTrattore);
        List<Trattore> GetAllByColors(Colore colore);
        Trattore GetById(int idTrattore);
        Trattore Post(PostTrattore postTrattoreModel);
        Trattore Put(PostTrattore postTrattoreModel, int idTrattore);
    }
}
