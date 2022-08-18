using System;

namespace OrientacaoObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario();
            usuario.setNome("Diogo Deconto");
            Console.WriteLine($"Nome do Usuário: {usuario.getNome()}");

            Produto produto1 = new Produto();
            produto1.Nome = "Água";
            produto1.Preco = 3.5;
            Console.WriteLine($"Nome do Produto: {produto1.Nome}");

            Produto produto2 = new Produto
            {
                Nome = "Coca",
                Preco = 5
            };
            Console.WriteLine($"Nome do Produto: {produto2.Nome}");
        }
    }
}
