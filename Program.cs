﻿using System;
using System.Collections.Generic;

namespace rock_paper_scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string estrategia, nome_jogador;
            int qtde_jogadores, qtde_toneios;
            string[][] torneio = new string[3][] { new string[] { "Armando", "P", "Dave", "S", "Richard", "R", "Michael", "S" }, new string[] { "Allen", "S", "Omer", "P", "David E.", "R", "Richard X.", "P" }, new string[] { "Teste 1", "S", "Teste 2", "P", "Teste 1", "S", "Teste 2", "P" } };
            /*string[][] torneio;

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
                        Console.WriteLine("Digite a estratégia do jogador [{0}]: ", j);
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
            }*/

            //rps_tournament_winner(torneio, 0, 1);
            rps_tournament_winner(torneio);
        }

        /*static void rps_game_winner(string[][] torneio, int i, int j)
        {
            if (j + 2 < torneio[i].Length)
            {
                if (torneio[i][j].ToString().Equals("S") && torneio[i][j + 2].ToString().Equals("P") ||
                torneio[i][j].ToString().Equals("R") && torneio[i][j + 2].ToString().Equals("S") ||
                torneio[i][j].ToString().Equals("P") && torneio[i][j + 2].ToString().Equals("R") ||
                torneio[i][j].ToString().Equals("S") && torneio[i][j + 2].ToString().Equals("S") ||
                torneio[i][j].ToString().Equals("R") && torneio[i][j + 2].ToString().Equals("R") ||
                torneio[i][j].ToString().Equals("P") && torneio[i][j + 2].ToString().Equals("P"))
                {
                    rps_game_winner(torneio, i, j);
                    Console.WriteLine("Vencedor do Jogo: " + torneio[i][j - 1].ToString());                    
                }
                else
                {
                    Console.WriteLine("Vai empilhar: " + (j + 2).ToString());
                    rps_game_winner(torneio, i, j + 2);
                }
            }
            Console.WriteLine("Vai desempempilhar: " + j.ToString());
        }*/



        /* static void rps_tournament_winner(string[][] torneio, int i, int j)
        {
            rps_game_winner(torneio, i, j);
            if (i + 1 < torneio.Length)
            {
                rps_tournament_winner(torneio, i + 1, j);
            }
        }*/

        static void rps_tournament_winner(string[][] torneio)
        {
            int[] vetPosVencedor = new int[torneio.Length];
            int[] vetAuxPosVencedor = new int[torneio.Length];
            for (int i = 0; i < torneio.Length; i++)
            {
                int vencedorTorneio = rps_game_winner(torneio, i);
                vetPosVencedor[i] = vencedorTorneio;
                Console.WriteLine("Vencedor do Rodada: [{0} , {1}]",torneio[i][vencedorTorneio - 1].ToString(), torneio[i][vencedorTorneio].ToString());
            }

            int posIAux = 0;
            while (vetPosVencedor[1] != 0)
            {
                int pos = 0;
                for (int j = 0; j + 1 < vetPosVencedor.Length; j = j + 2)
                {
                    if (vetPosVencedor[j + 1] != 0)
                    {
                        vetAuxPosVencedor[pos++] = ganhadorRodada(torneio, j, j + 1, vetPosVencedor[j], vetPosVencedor[j + 1]);
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

        static int rps_game_winner(string[][] torneio, int i)
        {
            int[] vetGanhadores = new int[(torneio[i].Length - 4) / 2];
            int[] vetGanAux = new int[vetGanhadores.Length];
            int pos = 0;

            for (int j = 1; j + 2 < torneio[i].Length; j = j + 4)
            {
                vetGanhadores[pos++] = ganhadorRodada(torneio, i, j, j + 2);
            }


            while (vetGanhadores[1] != 0)
            {
                pos = 0;
                for (int j = 0; j + 1 < vetGanhadores.Length; j = j + 2)
                {
                    if (vetGanhadores[j + 1] != 0)
                        vetGanAux[pos++] = ganhadorRodada(torneio, i, vetGanhadores[j], vetGanhadores[j + 1]);
                }
                vetGanAux.CopyTo(vetGanhadores, 0);
            }

            return vetGanAux[0] != 0 ? vetGanAux[0] : vetGanhadores[0];
        }

        static int ganhadorRodada(string[][] torneio, int i, int posUm, int posDois)
        {
            if (torneio[i][posUm].ToString().Equals("S") && torneio[i][posDois].ToString().Equals("P") ||
                torneio[i][posUm].ToString().Equals("R") && torneio[i][posDois].ToString().Equals("S") ||
                torneio[i][posUm].ToString().Equals("P") && torneio[i][posDois].ToString().Equals("R") ||
                torneio[i][posUm].ToString().Equals("S") && torneio[i][posDois].ToString().Equals("S") ||
                torneio[i][posUm].ToString().Equals("R") && torneio[i][posDois].ToString().Equals("R") ||
                torneio[i][posUm].ToString().Equals("P") && torneio[i][posDois].ToString().Equals("P"))
            {
                return posUm;
            }
            else
            {
                return posDois;
            }
        }

        static int ganhadorRodada(string[][] torneio, int indiceUm, int indiceDois, int posUm, int posDois)
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

