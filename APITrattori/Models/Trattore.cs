namespace APITrattori.Models
{
    public enum Colore { Rosso, Giallo, Blu, Nero, Rosa, Viola, Verde, Marrone }
    public class Trattore
    {
        public int TrattoreId { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public Colore Color { get; set; }
    }
}
