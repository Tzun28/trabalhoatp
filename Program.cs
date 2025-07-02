using System;
using System.IO;
namespace trabalhoaviao {
    class Program { 
        public static void Main() {   
            string opcaomenu = 0;// Variável para o switch Menu
            while (opcaomenu != 6;) { //Vai rodar até clicar no 6
                Console.WriteLine("Menu Principal:");//Menus que estão no canvas
                Console.WriteLine("1. Importar dados dos voos");
                Console.WriteLine("2. Realizar reserva");
                Console.WriteLine("3. Cancelar reserva");
                Console.WriteLine("4. Consultar assentos disponíveis");
                Console.WriteLine("5. Relatório de ocupação de voos");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: "); opcaomenu = Console.ReadLine();
                switch (opcaomenu) {    //Switch para cada item do menu
                    case "1":
                        Txt.Importar();//Interação-com-txt.cs
                        break;
                    case "2":
                        Reservar();//
                        break;
                    case "3":
                        Cancelar();
                        break;
                    case "4":
                        Consultar_assentos_disponiveis();
                        break;
                    case "5":
                        Relatorio_de_ocupacao_de_voos();
                        break;
                    case "6":
                        Txt.Exportar();
                        break;
                    default:
                        Console.WriteLine("Essa opção não existe.");
                        break;
                }
            }
        }
        public static int Buscar_codigo(string[] codigodosvoos, string codigoinformado) { //Pega os 5 códigos e cria um verificador que recebe o código digitado
            for (int i = 0; i < codigodosvoos.Length; i++) { if (codigodosvoos[i] == codigo_informado) { return i; } } //Recebe o código e passa 1 a 1, se for o código, então retorna ele
            return 0; //Se não achar retorna 0
        }
        public static string[] codigodosvoos = new string[5];//Função para guardar o código dos voos
        public static string[] destino = new string[5] { "Ibirité", "Contagem", "Belo Horizonte", "Ladainha", "Novo Cruzeiro" };//Declaração de variável contendo os destinos de voo
        public static int[] poltronas_vazias = new int[5];// Guarda as cadeiras disponíveis que tem em cada voo que tem em cada voo
        public static string[,] reservas_no_voo = new string[5, 50];// Matriz string para armazenar as reservas, 5 linhas (mirando nos destinos) e 50 colunas (mirando nas poltronas)
        
    }
}