/*Você foi contratado por uma empresa para desenvolver um software que
gerenciará o estoque de seus produtos. No primeiro protótipo que você
desenvolverá, o sistema ainda não irá se conectar ao banco de dados. As
informações ficarão em memória, assim, serão perdidas ao reiniciar o
programa.*/

//O Menu deve ser recursivo, após a realização da ação escolhida, ele deve voltar a ser apresentado até que seja escolhida a ação Sair

// Assim que o software abrir, ele deve apresentar o seguinte menu:
// [1] Novo
// [2] Listar Produstos
// [3] Remover produtos
// [4] Entrada estoque
// [5] Saída estoque
// [0] Sair

using System;
using System.Collections.Generic;

namespace estoqueMercado {
    
    public class Produto
    {
    public string nomeProduto { get; set; }
    public string tipoProduto { get; set; }
    public int quantidade { get; set; }
    public double precoProduto { get; set; }
    }
    public class EstoqueMercado
    {
        static List<Produto> produtos = new List<Produto>();
        static void Main(string[] args) 
        {
            string inicio;

            Console.WriteLine("Digite: Iniciar");
            inicio = Console.ReadLine();

            if (inicio.ToLower() == "iniciar")
            {
                menu();   
            }
            else
            {
                Console.WriteLine("Comando inválido.");
            }
        }
        
        static void menu()
        {   
            int num;

            Console.WriteLine("Selecione o numero desejado");
            num = Convert.ToInt32(Console.ReadLine());

             Console.WriteLine("[1] Novo");
             Console.WriteLine("[2] Listar Produstos");
             Console.WriteLine("[3] Remover produtos");
             Console.WriteLine("[4] Entrada estoque");
             Console.WriteLine("[5] Saída estoque");
             Console.WriteLine("[0] Sair");


            switch (num)
            {
                case 1:
                    adicionarProduto();
                    break;
                case 2:
                    listaProduto();
                    break;
                case 3:
                    removerProduto();
                    break;
                case 4:
                    entradaEstoque();
                    break;
                case 5:
                    saidaEstoque();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        static void adicionarProduto()
        {

            Produto produto = new Produto();
        
            Console.WriteLine("Novo Produto:");
            produto.nomeProduto = Console.ReadLine();
            
            Console.WriteLine("Tipo de Produto:");
            produto.tipoProduto =  Console.ReadLine();
;            
            Console.WriteLine("Preço do Produto:");
            produto.precoProduto = double.Parse(Console.ReadLine());
            
            produtos.Add(produto);

            Console.WriteLine("Produto adicionado com sucesso: " + produto.nomeProduto);

            
        }
          
        static void listaProduto()
        
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto foi adicionado ainda.");
            }
            else
            {
                Console.WriteLine("Lista de Produtos:");
                foreach (var produto in produtos) 
                {
                    Console.WriteLine($"Produto: {produto.nomeProduto}. Tipo: {produto.tipoProduto}, Quantidade: {produto.quantidade}, Preço: {produto.precoProduto}.");
                }
            }
        }

        static void removerProduto()
        {
            Console.WriteLine("Digite o nome do produto a ser removido:");
            string nomeProduto = Console.ReadLine();

            Produto produtoParaRemover = produtos.Find(p => p.nomeProduto == nomeProduto);
            if (produtoParaRemover != null)
            {
                produtos.Remove(produtoParaRemover);
                Console.WriteLine($"Produto '{nomeProduto}' Removido com sucesso");
            }
            else
            {
                Console.WriteLine($"Produto '{nomeProduto}' não encontrado");
            }
        }

        static void entradaEstoque()
        {
            Console.WriteLine("Digite o nome do produto para entrada de estoque:");
            string nomeProduto = Console.ReadLine();

            Produto produto = produtos.Find(p => p.nomeProduto == nomeProduto);
            if (produto != null)
            {
                Console.WriteLine("Digite a quantidade a ser adicionada:");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                produtos.quantidade += quantidade;
                Console.WriteLine($"Estoque de '{nomeProduto}' atualizado para {produto.quantidade} unidade.");
            }
            else
            {
                Console.WriteLine($"Produto '{nomeProduto}' não encontrado");
            }
        }   

        static void saidaEstoque()
        {

        }
    }
}