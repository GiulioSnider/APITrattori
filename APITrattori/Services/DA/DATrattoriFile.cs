using APITrattori.Models;
using APITrattori.Services.DA.Interface;

namespace APITrattori.Services.DA
{
    public class DATrattoriFile : IDATrattoriFile
    {
        private readonly string _path = "File\\Trattori.txt";

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

        public Trattore GetById(int idTrattore)
        {
            var trattoriList = GetAll().ToList();
            return trattoriList.SingleOrDefault(tratt => tratt.TrattoreId == idTrattore);
        }
    }
}
