using APITrattori.Models;
using APITrattori.Services.DA.Interface;

namespace APITrattori.Services.DA
{
    public class DATrattoriFile : IDATrattoriFile
    {
        private string _path = "File\\Trattori.txt";

        public IEnumerable<Trattore> GetAll()
        {
            return FileHelper.ReadAndDeserializeFile(_path);
        }

        public void AddSingleTrattore(Trattore fullTrattore)
        {
            var trattoriList = GetAll().ToList();
            trattoriList.Add(fullTrattore);
            FileHelper.SerializeAndWrite(trattoriList,_path);
        }

        public Trattore? GetById(int idTrattore)
        {            
            return GetAll().SingleOrDefault(tratt => tratt.TrattoreId == idTrattore);
        }

        public IEnumerable<Trattore> GetByColor(Colore colore)
        {
            return GetAll().Where(trattore => trattore.Color == colore);
        }

        public void Delete(Trattore trattoreToDelete)
        {
            var trattoriWithoutOne = GetAll().Where(tratt => tratt.TrattoreId != trattoreToDelete.TrattoreId).ToList();            
            FileHelper.SerializeAndWrite(trattoriWithoutOne, _path);
        }
    }
}
