using APITrattori.Models;
using APITrattori.Services.DA;
using APITrattori.Services.DA.Interface;
using APITrattori.Services.Worker.Interfaces;
using System.Drawing;

namespace APITrattori.Services.Worker
{
    public class TrattoriWorkerService : ITrattoriWorkerService
    {
        private IDATrattoriFile _DATrattoriFile;

        public TrattoriWorkerService(IDATrattoriFile dATrattoriFile)
        {
            _DATrattoriFile = dATrattoriFile;
        }

        public Trattore Post(PostTrattore postTrattoreModel)
        {
            Trattore fullTrattore = MappingNewTrattore(postTrattoreModel);
            _DATrattoriFile.AddSingleTrattore(fullTrattore);
            return fullTrattore;
        }

        public Trattore GetById(int idTrattore)
        {
            var trattoreById = _DATrattoriFile.GetById(idTrattore);
            if (trattoreById == default)
                throw new Exception("ID non valido");
            return trattoreById;
        }

        public List<Trattore> GetAllByColors(Colore colore)
        {
            var trattoriByColor = _DATrattoriFile.GetByColor(colore).ToList();
            if (trattoriByColor.Count == 0)
                throw new Exception("Non ci sono trattori di quel colore");
            return trattoriByColor;
        }
        public Trattore Put(PostTrattore postTrattoreModel, int idTrattore)
        {
            var trattoreFromId = _DATrattoriFile.GetAll().SingleOrDefault(tratt => tratt.TrattoreId == idTrattore);
            if (trattoreFromId == default)
            {
                Trattore fullTrattore = MappingNewTrattore(postTrattoreModel);
                _DATrattoriFile.AddSingleTrattore(fullTrattore);
                return fullTrattore;
            }
            MappingPutTrattore(postTrattoreModel, trattoreFromId);
            _DATrattoriFile.AddSingleTrattore(trattoreFromId);
            return null;
        }

        public void DeleteById(int idTrattore)
        {
            var trattoreToDelete = GetById(idTrattore);
            _DATrattoriFile.Delete(trattoreToDelete);
        }
        private int GenerateId()
        {
            List<Trattore> trattori = _DATrattoriFile.GetAll().ToList();
            if (trattori.Count == 0)
                return 1;
            return trattori.Max(trattore => trattore.TrattoreId) + 1;
        }
        private Trattore MappingNewTrattore(PostTrattore postTrattore)
        {
            return new()
            {
                TrattoreId = GenerateId(),
                Marca = postTrattore.Marca,
                Modello = postTrattore.Modello,
                Color = postTrattore.Color
            };
        }
        private void MappingPutTrattore(PostTrattore putTrattore, Trattore originalTrattore)
        {
            originalTrattore.Color = putTrattore.Color;
            originalTrattore.Modello = putTrattore.Modello;
            originalTrattore.Marca = putTrattore.Marca;
        }
    }
}
