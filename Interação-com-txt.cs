// O que é relacionado ao txt
namespace trabalhoaviao {
    class Txt(){//Pega o que tem no txt e importa pro código
        public static void Importar() {
            string arquivo = "txt/voos.txt";//Cria uma string com o caminho do arquivo
            string[] linhas = File.ReadAllLines(arquivo);//Cria um vetor que passa todas linhas do arquivo
            for (int i = 0; i < linhas.Length; i++){    //Percorre para concatenar dados
                string[] dados = linhas[i].Split('|'); //Guarda o que tem nas linhas, separado pelas barras em pé
                Program.codigodosvoos[i] = dados[0].Trim();//Salva o código do voo 
                Program.destino[i] = dados[1].Trim();//Salva o destino da viagem
                Program.poltronas_vazias[i] = int.Parse(dados[2].Trim());//Salva as reservas no voo
            }
            Console.WriteLine("Dados dos voos importados do arquivo txt com sucesso!");//Avisa que importou
        }

        /*---------------------------------------------------------------------------------------------*/

        public static void Exportar() {
            // Cria o arquivo txt ou atualiza, conforme os dados preenchidos durante a ativação do código.
            using (StreamWriter preencher = new StreamWriter("txt/relatorio.txt"))
            { //Cria um streamwritter para preencher as linhas do txt
                for (int i = 0; i < Program.codigodosvoos.Length; i++)
                {
                    int reservados = 50 - Program.poltronas_vazias[i];//Pega as poltronas reservadas finais
                    preencher.WriteLine($"Voo {Program.codigodosvoos[i]} - Destino: {Program.destino[i]}");
                    //Voo e destino com base no código de voo atual, o mesmo com os outros
                    preencher.WriteLine($"Total de poltronas reservadas: {reservados}");
                    preencher.WriteLine($"Total de poltronas disponíveis: {Program.poltronas_vazias[i]}");
                    preencher.WriteLine();//Próximo voo, sucessivamente                }
                }
            Console.WriteLine("Dados exportados com sucesso!");//Escreve que deu certo
            }
        }
    }
}