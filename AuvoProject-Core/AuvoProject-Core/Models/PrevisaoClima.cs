namespace AuvoProject_Core.Models
{
    public class PrevisaoClima
    {
        public int Id { get; set; }
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public int TemperaturaMinima { get; set; }
        public int TemperaturaMaxima { get; set; }
    }
}
