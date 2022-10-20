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
            Trattore fullTrattore = new()
            {
                TrattoreId = GenerateId(),
                Marca = postTrattoreModel.Marca,
                Modello = postTrattoreModel.Modello,
                Color = postTrattoreModel.Color
            };
            _DATrattoriFile.AddSingleTrattore(fullTrattore);
            return fullTrattore;
        }

        public Trattore GetById(int idTrattore)
        {
            var trattoreById = _DATrattoriFile.GetById(idTrattore);
            if (trattoreById == default)
                throw new ArgumentNullException("ID non valido");
            return trattoreById;
        }

        public List<Trattore> GetAllByColors(Colore colore)
        {
            throw new NotImplementedException();
        }
        public Trattore Put(PostTrattore postTrattoreModel, int idTrattore)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int idTrattore)
        {
            throw new NotImplementedException();
        }
        private int GenerateId()
        {
            List<Trattore> trattori = _DATrattoriFile.GetAll().ToList();
            if (trattori.Count == 0)
                return 1;
            return trattori.Max(trattore => trattore.TrattoreId) + 1;
        }
    }
}
