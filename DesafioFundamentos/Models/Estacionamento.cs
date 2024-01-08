using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa = "";

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine().ToUpper();
            if (!veiculos.Contains(placa))
            {
                if (Regex.IsMatch(placa, "^[A-Z]{3}-[0-9]{4}") || Regex.IsMatch(placa, "^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}"))
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo {placa} adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Placa inválida!");
                }
            }
            else
            {
                Console.WriteLine($"A placa {placa} já está registrada no sistema!");
            }
        }

        public void RemoverVeiculo()
        {
            string placa = "";

            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = Convert.ToInt32(Console.ReadLine());

                valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for (int count = 0; count < veiculos.Count; count++)
                {
                    Console.WriteLine(veiculos[count]);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
