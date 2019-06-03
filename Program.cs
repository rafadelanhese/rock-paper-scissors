using System;
using System.Collections.Generic;

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
            if (j + 2 < torneio[i].Length)
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
            Console.WriteLine(torneio.Length.ToString());
             Console.WriteLine(torneio[i].Length.ToString());
            rps_game_winner(torneio, i, j);  
            if (i + 1 < torneio.Length)
            {                
                rps_tournament_winner(torneio, i + 1, j);                                              
            }                              
        }

    }
}

