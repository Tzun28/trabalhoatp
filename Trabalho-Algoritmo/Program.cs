using System;
using System.IO;

class Program { //Classe programa
    

// Main que chama tudo
    public static void Main(string[] args) {   // Variável para o switch
        string opcao = 0;
        //Vai rodar até clicar no 6
        for (;opcao != 6;) {
            //Menus que estão no canvas
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Importar dados dos voos");
            Console.WriteLine("2. Realizar reserva");
            Console.WriteLine("3. Cancelar reserva");
            Console.WriteLine("4. Consultar assentos disponíveis");
            Console.WriteLine("5. Relatório de ocupação de voos");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();
            switch (opcao) {    //Switch para cada item do menu
                case "1":
                    Parte_pro_txt.Importar_dados_do_voo();
                    break;
                case "2":
                    Realizar_reserva();
                    break;
                case "3":
                    Cancelar_reserva();
                    break;
                case "4":
                    Consultar_assentos_disponiveis();
                    break;
                case "5":
                    Relatorio_de_ocupacao_de_voos();
                    break;
                case "6":
                    Parte_pro_txt.Exportar_dados_para_arquivo_txt();
                    break;
                default:
                    Console.WriteLine("Essa opção não existe.");
                    break;
            }
        }
    }
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    public static string[] codigodosvoos = new string[5];//Função para guardar o código dos voos
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    public static string[] destino = new string[5] { "Ibirité", "Contagem", "Belo Horizonte", "Ladainha", "Novo Cruzeiro" };//Declaração de variável contendo os destinos de voo
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    public static int[] poltronas_vazias = new int[5];// Guarda as cadeiras disponíveis que tem em cada voo que tem em cada voo
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    public static string[,] reservas_no_voo = new string[5, 50];// Matriz string para armazenar as reservas, 5 linhas (mirando nos destinos) e 50 colunas (mirando nas poltronas)
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    public static int Buscar_codigo(string[] codigodosvoos, string codigoinformado) { //Pega os 5 códigos e cria um verificador que recebe o código digitado
        for (int i = 0; i < codigodosvoos.Length; i++) { if (codigodosvoos[i] == codigo_informado) { return i; } } //Recebe o código e passa 1 a 1, se for o código, então retorna ele
        return 0; //Se não achar retorna 0
    }
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    public static void Realizar_reserva(){ //Realizar reserva
        Console.Write("Informe o código do voo:");//Pede código do voo
        int codigo = int.Parse(Console.ReadLine());//Recebe código do voo
        int codigoatual = Buscar_codigo(codigodosvoos, codigo);
        if (codigoatual == 0){ Console.WriteLine("Voo não encontrado!"); return; }//Se o código não for válido, volta pro menu
        Console.Write("Informe o número da poltrona ( de 1 a 50): ");//Pede o número da poltrona para reservar
        int poltrona = int.Parse(Console.ReadLine()) - 1;//Pega a posição da poltrona tirando um por causa do vetor
        if (poltrona < 0 || poltrona > 49){ Console.WriteLine("Essa poltrona não existe."); return; }//Se não for nenhuma das poltronas volta pro menu
        if (!string.IsNullOrEmpty(reservas_no_voo[codigoatual, poltrona])){Console.WriteLine("Essa poltrona já está ocupado!");

        /*Se o valor da cadeira escolhida estiver no banco de dados (50 poltronas do voo selecionado), e não estiver nula, o código vai informar que a poltrona está ocupada*/
        
            return;
            //Volta ao menu
        }
        //Do contrário segue o jogo
        Console.Write("Informe o seu nome: ");
        string nome = Console.ReadLine();
        // Nome do sujeito
        reservas_no_voo[banco_de_dados_codigo, poltrona_escolhida] = nome;
        //Vai montar a reserva percorrendo as 50 cadeiras e mencionando a escolhida, marcando o nome
        poltronas_vazias[banco_de_dados_codigo]--;
        //Decresce 1 dos 50 (ou menos) poltronas do vetor de poltronas vazias, referente a poltrona reservada
        Console.WriteLine("Reserva realizada com sucesso!");
    }
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

    public static void Cancelar_reserva()
    {
        Console.Write("Informe o código do voo: ");
        string codigo_informado = Console.ReadLine();
        // Pergunta e armazena o código do voo
        int banco_de_dados_codigo = Buscar_codigo(codigo, codigo_informado);
        //Ativa um banco de dados que vai segurar o codigo do voo, enviando os 5 códigos e o código informado para o método de buscar código

        if (banco_de_dados_codigo == -1)
        {
            Console.WriteLine("Voo não encontrado!");
            return;
            // Verifica e informa se o valor é ou não inválido, volta pro menu 
        }
        Console.Write("Informe o número da poltrona ( de 1 a 50): ");
        // Pede poltrona
        int poltrona_escolhida = int.Parse(Console.ReadLine()) - 1;
        //Pega a poltrona escolhida seguindo o número digitado pelo usuário, subtrai porque o vetor começa com 0 e vai até a posição 49 e depois armazena o valor
        if (poltrona_escolhida < 0 || poltrona_escolhida >= 50)
        //Se a poltrona escolhida for menor que 0 ou maior = 50 (Lembrando que está considerando a posição de vetor), vai falar que a poltrona não é válida para reserva
        {
            Console.WriteLine("Número de poltrona inválida!");
            return;
            //Volta pro menu
        }


        if (string.IsNullOrEmpty(reservas_no_voo[banco_de_dados_codigo, poltrona_escolhida]))
        /*Se o valor da cadeira escolhida estiver no banco de dados (50 poltronas do voo selecionado), e estiver nula, ou seja, está livre, o código vai informar que a poltrona não está reservada e consequentemente você não irá cancelar nada*/
        {
            Console.WriteLine("Essa poltrona não está reservada!");
            return;
            //Volta ao menu
        }

        reservas_no_voo[banco_de_dados_codigo, poltrona_escolhida] = null;
        //Se estiver preenchida vai esvaziar a poltrona
        poltronas_vazias[banco_de_dados_codigo]++;
        //Vai aumentar no contador de poltrona vazia do referido voo
        Console.WriteLine("Reserva cancelada com sucesso!");
    }

    /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

    public static void Consultar_assentos_disponiveis()
    //Método para consultar assentos disponíveis
    {
        for (int i = 0; i < codigo.Length; i++)
        //Gera um i, que vai percorrer todo codigo de voo e continuar depois
        {
            Console.WriteLine($"Voo {codigo[i]} - Destino: {destino[i]}");
            //Escreve o voo de acordo com o respectivo i, o mesmo para o destino
            Console.Write("Assentos disponíveis: ");
            for (int n = 0; n < 50; n++)
            //Para verificar, puxa um for declarando n, sendo até n menor que 50, acrescendo n por repetição
            {
                if (string.IsNullOrEmpty(reservas_no_voo[i, n]))
                // Se a string estiver nula/vazia, na reserva do voo, que vai verificar usando i e n, que dizer que está disponível, logo escreve-se a posição n + valor de exbição para usuários
                {
                    Console.Write(n + 1);
                }
            }
            Console.WriteLine();
            //Pula linha ao final das colunas de um voo, passando ao próximo
        }
    }

/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

    public static void Relatorio_de_ocupacao_de_voos()
    {
        Console.Write("Informe o código do voo (01 a 05): ");
        // Pede um relatório de poltronas ocupadas
        string codigo_informado = Console.ReadLine();
        // Pega o código do voo informado pelo usuário
        int banco_de_dados_codigo = Buscar_codigo(codigo, codigo_informado);
        // Verifica o índice do voo de acordo com o código informado
        if (banco_de_dados_codigo == -1)
        {
            Console.WriteLine("Voo não encontrado!");
            return;
            // Informa se o voo não foi encontrado e retorna ao menu
        }
        Console.WriteLine("Voo" + codigo[banco_de_dados_codigo] + " - Destino: " + destino[banco_de_dados_codigo]);
        // Exibe o código do voo e o destino correspondente
        for (int i = 0; i < 50; i++)
        // Percorre todas as 50 poltronas
        {
            // Verifica se a poltrona está disponível e concatena a informação de disponibilidade com o nome do passageiro
            string final = string.IsNullOrEmpty(reservas_no_voo[banco_de_dados_codigo, i]) ? "Disponível" : reservas_no_voo[banco_de_dados_codigo, i];
            Console.WriteLine($"Poltrona {i + 1}: {final}");
            // Exibe o status da poltrona, mostrando se está disponível ou ocupada
        }
    }
/*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

}