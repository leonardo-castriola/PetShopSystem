using PetShopSystem.ConsoleApp.Enums;
using PetShopSystem.ConsoleApp.Models;

namespace PetShopSystem.ConsoleApp.Services
{
    public class BanhoService : IBanhoService
    {
        public decimal CalcularValorBanho(Pet pet)
        {
            decimal valorBase = 0;

            // Regra base por faixa de peso
            if (pet.Peso <= 10.0)
            {
                valorBase = 40.00m;
            }
            else if (pet.Peso <= 25.0)
            {
                valorBase = 60.00m;
            }
            else
            {
                valorBase = 80.00m;
            }

            // Regra de bônus por raça (Adicional de R$ 10 para Poodles)
            if (pet.Raica == RacaPet.Poodle)
            {
                valorBase += 10.00m;
            }

            return valorBase;
        }
    }
}
