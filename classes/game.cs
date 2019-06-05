namespace rock_paper_scissors.classes
{
    public class game
    {
        public static int rps_game_winner(string[][] torneio, int i)
        {
            int[] vetGanhadores = new int[(torneio[i].Length - 4) / 2];
            int[] vetGanAux = new int[vetGanhadores.Length];
            int pos = 0;

            for (int j = 1; j + 2 < torneio[i].Length; j = j + 4)
            {
                vetGanhadores[pos++] = ganhadorRodada(torneio, i, i, j, j + 2);
            }


            while (vetGanhadores[1] != 0)
            {
                pos = 0;
                for (int j = 0; j + 1 < vetGanhadores.Length; j = j + 2)
                {
                    if (vetGanhadores[j + 1] != 0)
                        vetGanAux[pos++] = ganhadorRodada(torneio, i, i, vetGanhadores[j], vetGanhadores[j + 1]);
                }
                vetGanAux.CopyTo(vetGanhadores, 0);
            }

            return vetGanAux[0] != 0 ? vetGanAux[0] : vetGanhadores[0];
        }

         /*
        Método que verifica o ganhador de uma rodada a partir do índice e posição na matriz.
        Utilizado dois índices no parâmetro para evitar a sobrecarga do método.
         */
        public static int ganhadorRodada(string[][] torneio, int indiceUm, int indiceDois, int posUm, int posDois)
        {
            if (torneio[indiceUm][posUm].ToString().Equals("S") && torneio[indiceDois][posDois].ToString().Equals("P") ||
                torneio[indiceUm][posUm].ToString().Equals("R") && torneio[indiceDois][posDois].ToString().Equals("S") ||
                torneio[indiceUm][posUm].ToString().Equals("P") && torneio[indiceDois][posDois].ToString().Equals("R") ||
                torneio[indiceUm][posUm].ToString().Equals("S") && torneio[indiceDois][posDois].ToString().Equals("S") ||
                torneio[indiceUm][posUm].ToString().Equals("R") && torneio[indiceDois][posDois].ToString().Equals("R") ||
                torneio[indiceUm][posUm].ToString().Equals("P") && torneio[indiceDois][posDois].ToString().Equals("P"))
            {
                return posUm;
            }
            else
            {
                return posDois;
            }
        }

    }
}