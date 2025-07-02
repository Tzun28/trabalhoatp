namespace trabalhoaviao {
    class Program {
        public static void Reservar(){ //Realizar reserva
            Console.Write("Informe o código do voo:");//Pede código do voo
            int codigo = int.Parse(Console.ReadLine());//Recebe código do voo
            int codigoatual = Buscar_codigo(codigodosvoos, codigo);
            if (codigoatual == 0){ Console.WriteLine("Voo não encontrado!"); return; }//Se o código não for válido, volta pro menu
            Console.Write("Informe o número da poltrona ( de 1 a 50): ");//Pede o número da poltrona para reservar
            int poltrona = int.Parse(Console.ReadLine()) - 1;//Pega a posição da poltrona tirando um por causa do vetor
            if (poltrona < 0 || poltrona >= 49){ Console.WriteLine("Essa poltrona não existe."); return; }//Se não for nenhuma das poltronas volta pro menu
            if (!string.IsNullOrEmpty(reservas_no_voo[codigoatual, poltrona])){Console.WriteLine("Essa poltrona já está ocupado!"); return;}
            /*Se o valor da cadeira escolhida estiver dentro das 50 poltronas do voo selecionado, e não estiver nula, o código vai informar que a poltrona está ocupada*/
            //Do contrário segue o jogo
            Console.Write("Informe o seu nome: "); string nome = Console.ReadLine();//Recebe nome do passageiro
            reservas_no_voo[codigoatual, poltrona_escolhida] = nome;
            //Vai montar a reserva percorrendo as 50 cadeiras e mencionando a escolhida, marcando o nome
            poltronas_vazias[codigoatual]--;
            //Decresce 1 dos 50 (ou menos) poltronas do vetor de poltronas vazias, referente a poltrona reservada
            Console.WriteLine("Reserva realizada com sucesso!");
        }
    }
}