// See https://aka.ms/new-console-template for more information
using System.Threading;
using Desafios01.Models;

int userChoice;
string inputText;

Console.WriteLine("Bem vindo ao Sistema de Estacionamento");
Console.Write("Digite o preço inicial: ");
inputText = Console.ReadLine();
decimal precoInicial = decimal.TryParse(inputText, out decimal Decimalresult) ? Decimalresult : 0;
Console.Write("Digite o preço por hora: ");
inputText = Console.ReadLine();
decimal precoPorHora = decimal.TryParse(inputText, out Decimalresult) ? Decimalresult : 0;
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);


do {
    Console.WriteLine("MENU DE OPÇÕES");
    Console.WriteLine("1 - Adicionar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    inputText = Console.ReadLine();
    userChoice = int.TryParse(inputText, out int result) ? result : 0;

    switch (userChoice) {
        case 1:
            Console.WriteLine("Digite a placa do veículo:");
            string veiculo = Console.ReadLine();
            es.AdicionarVeiculo(veiculo.ToUpper());
            break;
        case 2:
            Console.WriteLine("Digite a placa do veículo:");
            veiculo = Console.ReadLine();
            es.RemoverVeiculo(veiculo.ToUpper());
            break;
        case 3:
            es.ListarVeiculos();
            break;
        case 4:
            Console.WriteLine("Encerrando...");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    Thread.Sleep(3000);

} while (userChoice != 4);
