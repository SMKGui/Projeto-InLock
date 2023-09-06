namespace senai.inlock.webApi.tarde.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public float Valor { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}
