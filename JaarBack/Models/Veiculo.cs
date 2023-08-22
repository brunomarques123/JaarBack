namespace JaarBack.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string CodigoFipe { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Combustivel { get; set; }
        public decimal Valor { get; set; }
    }
}
