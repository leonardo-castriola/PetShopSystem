using PetShopSystem.ConsoleApp.Models;

namespace PetShopSystem.ConsoleApp.Services
{
    public interface IBanhoService
    {
        decimal CalcularValorBanho(Pet pet);
    }
}
