using System;
using System.Collections.Generic;
using rock_paper_scissors.model;

namespace rock_paper_scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] torneio = new string[2][] { new string[] { "Armando", "P", "Dave", "S", "Richard", "R", "Michael", "S" }, new string[] { "Allen", "S", "Omer", "P", "David E.", "R", "Richard X.", "P" } };

            rps_tournament_winner(torneio, 0, 1);
        }

        static void rps_game_winner(string[][] torneio, int i, int j)
        {
            if (j + 2 < 8)
            {
                if (torneio[i][j].ToString().Equals("S") && torneio[i][j + 2].ToString().Equals("P") ||
                torneio[i][j].ToString().Equals("R") && torneio[i][j + 2].ToString().Equals("S") ||
                torneio[i][j].ToString().Equals("P") && torneio[i][j + 2].ToString().Equals("R"))
                    Console.WriteLine("Vencedor do Jogo: " + torneio[i][j - 1].ToString());
                else
                    rps_game_winner(torneio, i, j + 2);
            }
        }

        static void rps_tournament_winner(string[][] torneio, int i, int j)
        {
            rps_game_winner(torneio, i, j);
            if (i + 1 < 2)
            {                
                rps_tournament_winner(torneio, i + 1, j);
                Console.WriteLine("Vencedor do torneio: " + torneio[i][j - 1].ToString());
            }
        }

    }
}

