 public class Colaboradores
    {
        public string nome { get; set; }
        public decimal salario { get; set; }

        public Colaboradores(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;
        }
    }
    public class Reajustes
    {
        public decimal aumentoPercentual { get; set; }
        public decimal faixaInicial { get; set; }
        public decimal faixaFinal { get; set; }

        public Reajustes(decimal aumentoPercentual,
            decimal faixaInicial,
            decimal faixaFinal)
        {
            this.aumentoPercentual = aumentoPercentual;
            this.faixaInicial = faixaInicial;
            this.faixaFinal = faixaFinal;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var listColaboradores = new List<Colaboradores>
            {
                new Colaboradores("Diego", 279),
                new Colaboradores("Jose", 285),
                new Colaboradores("Carlos", 700),
                new Colaboradores("Antonio", 1525)
            };


            var listReajustes = new List<Reajustes>
            {
                new Reajustes(20, 0, 280),
                new Reajustes(15, 280, 700),
                new Reajustes(10, 700, 1500),
                new Reajustes(5, 1500, 999999)
            };

            listColaboradores.ForEach(c =>
            {
                var faixaReajuste = listReajustes.FindAll(f => c.salario >= f.faixaInicial && c.salario < f.faixaFinal);
                if (faixaReajuste.Count().Equals(1))
                {
                    faixaReajuste.ForEach(r =>
                    {
                        var salarioAtualizado = (c.salario * r.aumentoPercentual / 100) + c.salario;
                        c.salario = salarioAtualizado;
                        Console.WriteLine("nome:" + c.nome);
                        Console.WriteLine("salario anterior:" + c.salario);
                        Console.WriteLine("percentual reajuste:" + r.aumentoPercentual);
                        Console.WriteLine("salario rajustado:" + salarioAtualizado);
                    });
                }
            });
        }
    }