using System;

namespace ListaExercicio
{
    class Exe01
    {
        public static void Renderizar()
        {
            //Imprimir uma mensagem no terminal
            Console.WriteLine("Digite a altura:");
            //Ler uma nova teclado
            int altura = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a largura:");
            int largura = Convert.ToInt32(Console.ReadLine());

            int area = largura * altura;

            Console.WriteLine($"Área: { area }");
        }
    }

}