using PetShopSystem.ConsoleApp.Enums;

namespace PetShopSystem.ConsoleApp.Models
{
    public class Pet
    {
        public string Nome { get; set; } = string.Empty;
        public double Peso { get; set; }
        public RacaPet Raica { get; set; }

        public Pet(string nome, double peso, RacaPet raca)
        {
            Nome = nome;
            Peso = peso;
            Raica = raca;
        }
    }
}
