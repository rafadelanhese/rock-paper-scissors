using System;
using System.Collections.Generic;

namespace rock_paper_scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string estrategia, nome_jogador;
            int qtde_jogadores, qtde_toneios;
            //string[][] torneio = new string[2][] { new string[] { "Armando", "P", "Dave", "S", "Richard", "R", "Michael", "S" }, new string[] { "Allen", "S", "Omer", "P", "David E.", "R", "Richard X.", "P" } };
            string[][] torneio;

            do
            {
                Console.WriteLine("Digite a quantidade de torneios: ");
                qtde_toneios = int.Parse(Console.ReadLine());

                if (qtde_toneios < 1)
                    Console.WriteLine("A quantidade de torneios tem que maior ou igual que 1");
            } while (qtde_toneios < 1);

            do
            {
                Console.WriteLine("Digite a quantidade de jogadores: ");
                qtde_jogadores = int.Parse(Console.ReadLine());

                if (qtde_jogadores < 2)
                    Console.WriteLine("WrongNumberOfPlayersError");
            } while (qtde_jogadores < 2);

            //DEFINE O TAMANHO DO ARRAY PELA QUANTIDADE DE TORNEIOS
            torneio = new string[qtde_toneios][];            
            for (int i = 0; i < qtde_toneios; i++)
            {

                string[] jogadores = new string[qtde_jogadores * 2];

                for (int j = 0; j < qtde_jogadores * 2; j++)
                {
                    Console.WriteLine("TORNEIO {0} - Digite o nome do jogador [{1}]: ", i, j);
                    nome_jogador = Console.ReadLine();

                    do
                    {
                        Console.WriteLine("Digite a estratégia do jogador [{0}]: ",j);
                        estrategia = Console.ReadLine();
                        estrategia = estrategia.ToUpper();

                        if (!estrategia.Equals("S") && !estrategia.Equals("R") && !estrategia.Equals("P"))
                            Console.WriteLine("NoSuchStrategyError");
                        else
                        {
                            jogadores[j] = nome_jogador;                            
                            jogadores[++j] = estrategia;
                        }
                    } while (!estrategia.Equals("S") && !estrategia.Equals("R") && !estrategia.Equals("P"));
                }

                torneio[i] = jogadores;
            }

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
            rps_game_winner(torneio, i, j);
            if (i + 1 < torneio.Length)
            {
                rps_tournament_winner(torneio, i + 1, j);
            }
        }

    }
}

