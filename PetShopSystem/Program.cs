using Microsoft.Extensions.DependencyInjection;
using PetShopSystem.ConsoleApp.Enums;
using PetShopSystem.ConsoleApp.Models;
using PetShopSystem.ConsoleApp.Services;
using System;

namespace PetShopSystem.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            // 1. Configurando o Container de Injeção de Dependência
            var serviceProvider = new ServiceCollection()
                .AddScoped<IBanhoService, BanhoService>()
                .BuildServiceProvider();

            var banhoService = serviceProvider.GetRequiredService<IBanhoService>();

            Console.WriteLine("=== Cadastro de Pet - Sistema PetShop ===");

            // 2. Captura do Nome
            Console.Write("Digite o nome do pet: ");
            string nome = Console.ReadLine() ?? "Sem Nome";

            // 3. Captura e Conversão do Peso (Tratando possíveis erros de digitação)
            double peso = 0;
            while (true)
            {
                Console.Write("Digite o peso do pet (em kg, ex: 12,5): ");
                if (double.TryParse(Console.ReadLine(), out peso) && peso > 0)
                {
                    break;
                }
                Console.WriteLine("❌ Peso inválido! Por favor, digite um número maior que zero.");
            }

            // 4. Captura e Seleção da Raça usando o Enum
            Console.WriteLine("\nSelecione a raça do pet:");
            Console.WriteLine("0 - Outra");
            Console.WriteLine("1 - Poodle");
            Console.WriteLine("2 - Vira-Lata");
            Console.WriteLine("3 - Golden Retriever");
            Console.Write("Opção: ");

            int opcaoRaica;
            int.TryParse(Console.ReadLine(), out opcaoRaica);

            // Garante que se o usuário digitar uma opção inexistente, caia em "Outra"
            if (!Enum.IsDefined(typeof(RacaPet), opcaoRaica))
            {
                opcaoRaica = 0;
            }
            RacaPet racaSelecionada = (RacaPet)opcaoRaica;

            // 5. Instanciando o objeto com as entradas do teclado
            var novoPet = new Pet(nome, peso, racaSelecionada);

            // 6. Execução da Regra de Negócio via Serviço Injetado
            decimal precoFinal = banhoService.CalcularValorBanho(novoPet);

            // 7. Exibição do Recibo Formatado
            Console.WriteLine("\n=======================================");
            Console.WriteLine("           RECIBO DO BANHO             ");
            Console.WriteLine("=======================================");
            Console.WriteLine($"Pet: {novoPet.Nome}");
            Console.WriteLine($"Peso: {novoPet.Peso:F1} kg");
            Console.WriteLine($"Raça: {novoPet.Raica}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Valor total: {precoFinal:C2}");
            Console.WriteLine("=======================================");

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
