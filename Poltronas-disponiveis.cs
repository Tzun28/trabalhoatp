namespace trabalhoaviao{
    class Program{
        public static void Consultar_assentos_disponiveis() {
            for (int i = 0; i < codigodosvoos.Length; i++)//Percorre todos voos
            {
                Console.WriteLine($"Voo {codigodosvoos[i]} - Destino: {destino[i]}");//Fala voo e destino
                Console.Write("Assentos disponíveis: ");
                for (int n = 0; n <= 49; n++)//Todas cadeiras
                {
                    if (string.IsNullOrEmpty(reservas_no_voo[i, n]))//Se string vazia em x voo e cadeira
                    {
                        Console.Write(n + 1);//Escreve a tal cadeira +1 por causa do índice
                    }
                }
                Console.WriteLine();    
            }
        }
    }
}