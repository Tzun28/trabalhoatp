// Documento separado para deixar mais fácil de visualizar a parte do código referente ao txt.
class Parte_pro_txt {
    // Pega os dados do txt para mandar para o código, código do voo, local de destino do voo e quantos lugares vai ter no voo.
    public static void Importar_dados_do_voo() {
        // Declaração de método
        string caminho_do_arquivo = "txt/voos.txt";
        // Declara variável com o caminho para encontrar o arquivo de texto com os dados iniciais do programa.
        string[] linhas = File.ReadAllLines(caminho_do_arquivo);
        // Cria um vetor de linhas obtendo(lendo) o valor de todas as linhas de dentro do arquivo, para encontrar o caminho, segue a varíavel de caminho. Cada linha ganha um valor a mais para identificação.
        for (int i = 0; i < linhas.Length; i++)
        // Faz um for que cria uma variável inteira i e faz ela percorrer cada (vetor)linha de acordo com o indicado, ao final soma e repete o processo para a próxima (vetor)linha.
        {
            string[] dados = linhas[i].Split('|');
            // Vetor para armazenar dados advindos das linhas, referente a linha indicada no i, é separado internamente pela barra especial |
            Program.codigo[i] = dados[0].Trim();
            // Vai no vetor do código do voo e usa o i para avanço
            Program.destino[i] = dados[1].Trim();
            // Vai no vetor do destino do voo e usa o i para avanço
            Program.poltronas_vazias[i] = int.Parse(dados[2].Trim());
            // Vai no vetor de poltronas vazias e usa o i para avanço, convertendo o dado de string para inteiro
        }
        Console.WriteLine("Dados dos voos importados do arquivo txt com sucesso!");
        // Exibe mensagem de sucesso ao importar os dados
    }
    
    public static void Exportar_dados_para_arquivo_txt() {
        // Cria o arquivo txt ou atualiza, conforme os dados preenchidos durante a ativação do código.
        using (StreamWriter writer = new StreamWriter("txt/relatorio.txt"))
        {
            for (int i = 0; i < Program.codigo.Length; i++)
            {
                int reservados = 50 - Program.poltronas_vazias[i];
                // Calcula o total de poltronas reservadas subtraindo as poltronas vazias do total de poltronas (50)
                writer.WriteLine($"Voo {Program.codigo[i]} - Destino: {Program.destino[i]}");
                // Escreve no arquivo o código do voo e o destino
                writer.WriteLine($"Total de poltronas reservadas: {reservados}");
                // Escreve no arquivo o total de poltronas reservadas
                writer.WriteLine($"Total de poltronas disponíveis: {Program.poltronas_vazias[i]}");
                // Escreve no arquivo o total de poltronas disponíveis
                writer.WriteLine();
                // Adiciona uma linha em branco para separar cada voo
            }
        }
        Console.WriteLine("Dados exportados com sucesso!");
        // Invoca a mensagem de sucesso depois de exportar os dados para o documento txt
    }
}
