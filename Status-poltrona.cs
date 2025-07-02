namespace trabalhoaviao{
    class Program {
        public static void Relatorio_de_ocupacao_de_voos()
        {
            Console.Write("Informe o código do voo (01 a 05): ");
            string codigo = Console.ReadLine();//Pega o código e olha se é válido
            int codigoatual = Buscar_codigo(codigodosvoos, codigo);
            if (codigoatual == 0){Console.WriteLine("Voo não encontrado!"); return;}
            Console.WriteLine("Voo" + codigodosvoos[codigoatual] + " - Destino: " + destino[codigoatual]);
            //Exibe o código do voo e o destino correspondente
            for (int i = 0; i <= 49; i++) {
                string status;
                if (string.IsNullOrEmpty(reservas_no_voo[codigoatual, i])){
                    status = "Disponível";
                }
                else{ status = reservas_no_voo[codigoatual, i];}
                Console.WriteLine($"Poltrona {i + 1}: {status}");
            }         
            
        }
    }
}