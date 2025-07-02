namespace trabalhoaviao{
    class Program {
        public static void Cancelar()
        {
            Console.Write("Informe o código do voo: ");
            int codigo = Console.ReadLine();//Pega código
            int codigoatual = Buscar_codigo(codigodosvoos, codigo);//Verifica
            if (codigoatual == 0)
            {   Console.WriteLine("Voo não encontrado!"); return; }//Se não tem sai     
            Console.Write("Informe o número da poltrona ( de 1 a 50): ");
            int poltrona = int.Parse(Console.ReadLine()) - 1;//Confere
            if (poltrona < 0 || poltrona > 49) {Console.WriteLine("Número de poltrona inválida!");return;}
            if (string.IsNullOrEmpty(reservas_no_voo[codigoatual, poltrona])){
                Console.WriteLine("Essa poltrona não está reservada!");
                return;//Se não tiver nada, ela simplesmente não está reservada
            }
            reservas_no_voo[codigoatual, poltrona] = null;//Se estiver preenchida vai esvaziar a poltrona
            poltronas_vazias[codigoatual]++;//Vai aumentar no contador de poltrona vazia do referido voo
            Console.WriteLine("Reserva cancelada com sucesso!");
        }
    }
}