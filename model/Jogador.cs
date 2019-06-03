using System;

namespace rock_paper_scissors.model
{
    public class Jogador
    {       
        public string nome {get; set;}
        public string jogada{get; set;}

        public Jogador()
        {

        }
       public Jogador(string nome, string jogada)
       {
           this.nome = nome;
           this.jogada = jogada;
       }
    }
}