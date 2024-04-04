using System.Xml;

public class Pedido
{
    public string nome { get; set; }
    public int quantidade { get; set; }
    public decimal valorReal { get; set; }
    public decimal valorPromocao { get; set; }
    public int metodo { get; set; }

    public Pedido(
        string nome,
        int quantidade,
        decimal valorReal,
        decimal valorPromocao,
        int metodo)
    {
        this.nome = nome;
        this.quantidade = quantidade;
        this.valorReal = valorReal;
        this.valorPromocao = valorPromocao;
    }
}
public class Produto
{
    public int id { get; set; }
    public string nome { get; set; }
    public decimal valorReal { get; set; }
    public decimal valorPromocao { get; set; }

    public Produto(int id,
        string nome,
        decimal valorReal,
        decimal valorPromocao)
    {
        this.id = id;
        this.nome = nome;
        this.valorReal = valorReal;
        this.valorPromocao = valorPromocao;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var listProdutos = new List<Produto>
            {
                new Produto(1,"File Duplo", 5.8M, 0.9M),
                new Produto(2,"Alcatra", 6.8M, 0.9M),
                new Produto(3,"Picanha", 7.8M, 0.9M)
            };


        var listPedido = new List<Pedido>();


        bool vendaTerminou = false;
        int id = 0; 
        while (!vendaTerminou)
        {
            Console.WriteLine("cod\tdescricao");
            foreach (var produto in listProdutos)
            {
                Console.WriteLine(produto.id + "\t" + produto.nome);
            }
            Console.WriteLine("");
            Console.WriteLine("Selecione o produto (numero) ou 0 para sair");
            if (Int32.TryParse(Console.ReadLine(), out Int32 codigo))
            {

                if (listProdutos.FindAll(f => f.id.Equals(codigo)).Count > 0)
                {
                    Console.WriteLine("informe o peso em kilos ou 0 para sair");
                    if (Int32.TryParse(Console.ReadLine(), out Int32 quantidade))
                    {
                        Console.WriteLine("Informe o metodo de pagamento");
                        Console.WriteLine("1 - Cartão");
                        Console.WriteLine("2 - Dinheiro");
                        if (Int32.TryParse(Console.ReadLine(), out Int32 metodo))
                        {
                            var produto1 = listProdutos.Find(f => f.id.Equals(codigo));
                            listPedido.Add(new Pedido(produto1.nome, quantidade, produto1.valorReal, produto1.valorPromocao, metodo ));
                            Console.Clear();
                            vendaTerminou = true;
                        }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Permitido somente numero, ou 0 para ver os resultados da pesquisa");
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Permitido somente numero, ou 0 para ver os resultados da pesquisa");
                }
            }
            else
            {
                Console.WriteLine($"Permitido somente numero, ou 0 para ver os resultados da pesquisa");
            }

        }

            if (listPedido.Count > 0)
            {
                Console.WriteLine("Nota Fiscal");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("Mercado");
                foreach (var pedidos in listPedido)
                {
                    Console.WriteLine("Produto: " + pedidos.nome);
                    Console.WriteLine("Preço: R$ " + pedidos.valorReal);
                    Console.WriteLine("Quantidade: " + pedidos.quantidade);
                    Console.WriteLine("Desconto: R$ " + pedidos.valorPromocao);
                    Console.WriteLine("Metodo Pagamento: " + pedidos.metodo);
                    if (pedidos.metodo.Equals(1))
                    {
                        double total = listPedido.Sum(x => Convert.ToDouble(x.valorReal - x.valorPromocao - (x.valorPromocao)));
                        Console.WriteLine("Valor total: R$ " + (decimal)total);
                    }
                    else
                    {
                        double total = listPedido.Sum(x => Convert.ToDouble(x.valorReal - x.valorPromocao));
                        Console.WriteLine("Valor total: R$ " + (decimal)total);
                    }

                }

            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Obrigado pela preferência!");
        }
    }
}