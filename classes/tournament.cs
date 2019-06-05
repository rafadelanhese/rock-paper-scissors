using System;

namespace rock_paper_scissors.classes
{
    public class tournament
    {
        public static void rps_tournament_winner(string[][] torneio)
        {
            int[] vetPosVencedor = new int[torneio.Length];
            int[] vetAuxPosVencedor = new int[torneio.Length];
            int posIAux = 0;

            for (int i = 0; i < torneio.Length; i++)
            {
                int vencedorTorneio = game.rps_game_winner(torneio, i);
                vetPosVencedor[i] = vencedorTorneio;
                Console.WriteLine("Vencedor do Rodada: [{0} , {1}]", torneio[i][vencedorTorneio - 1].ToString(), torneio[i][vencedorTorneio].ToString());
            }

            while (vetPosVencedor.Length - 1 > 0 && vetPosVencedor[1] != 0)
            {
                int pos = 0;
                for (int j = 0; j + 1 < vetPosVencedor.Length; j = j + 2)
                {
                    if (vetPosVencedor[j + 1] != 0)
                    {
                        vetAuxPosVencedor[pos++] = game.ganhadorRodada(torneio, j, j + 1, vetPosVencedor[j], vetPosVencedor[j + 1]);
                        if (vetPosVencedor[j] == vetAuxPosVencedor[pos - 1])
                            posIAux = j;
                        else
                            posIAux = j + 1;
                    }

                }
                vetAuxPosVencedor.CopyTo(vetPosVencedor, 0);
            }

            Console.WriteLine("Vencedor do Torneio: [{0} , {1}]", torneio[posIAux][vetPosVencedor[0] - 1].ToString(), torneio[posIAux][vetPosVencedor[0]].ToString());
        }               
    }
}