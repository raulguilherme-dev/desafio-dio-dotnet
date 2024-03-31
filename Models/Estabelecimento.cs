using System.Text.RegularExpressions;

namespace Desafios01.Models;

public class Estacionamento {

    private decimal precoInicicial;
    private decimal precoPorHora;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicicial, decimal precoPorHora) {
        this.precoInicicial = precoInicicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo(string veiculo) {
        if (veiculo[3] != '-' && veiculo.Length == 7) {
            veiculo = veiculo.Insert(3, "-");
        } 

        string placaPattern = @"^[A-Z]{3}-?\d{4}$";

        if (!veiculos.Contains(veiculo)) {
            if (Regex.IsMatch(veiculo, placaPattern)) {
                veiculos.Add(veiculo);
                Console.WriteLine("Veículo adicionado com sucesso");
            } else {
                Console.WriteLine("Placa inválida");
            }
        } else {
            Console.WriteLine("Veículo já está no estacionamento");
        }
    }

    public void RemoverVeiculo(string veiculo) {
        if (veiculos.Contains(veiculo)) {
            Console.WriteLine("Informe por quantas horas o veículo ficou estacionado:");
            string inputText = Console.ReadLine();
            int horas = int.TryParse(inputText, out int result) ? result : 0;
            if (horas > 0) {
                decimal precoFinal = precoInicicial + (precoPorHora * horas);
                Console.WriteLine($"Preço a ser pago: R$ {precoFinal}");
                veiculos.Remove(veiculo);
            } else {
                Console.WriteLine("Horas inválidas");
            }
        } else {
            Console.WriteLine("Veículo não encontrado");
        }
        
    }

    public void ListarVeiculos() {
        if (veiculos.Count == 0) {
            Console.WriteLine("Não há veículos no estacionamento");
        }
        foreach (var veiculo in veiculos) {
            Console.WriteLine(veiculo);
        }
    }
}