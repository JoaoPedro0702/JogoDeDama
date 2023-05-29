using System;
using tabuleiro;
using System.Collections.Generic;
using dama;

namespace dama_console {
    class Tela {

        public static void ImprimirPartida(PartidaDeDama partida) {
            ImprimirTabuleiro(partida.tab);
            System.Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            System.Console.WriteLine();
            System.Console.WriteLine("Turno: " + partida.turno);
            System.Console.WriteLine("Aguarda jogada: " + partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaDeDama partida) { 
            System.Console.WriteLine("Peças capturadas");
            System.Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            System.Console.WriteLine();
            System.Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            System.Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto) {
            System.Console.Write("[");
            foreach (Peca x in conjunto) {
                System.Console.Write(x + " ");
            }
            System.Console.Write("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab) {

            for (int i=0; i<tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<tab.colunas; j++) {
                   ImprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] PosicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (PosicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoDama LerPosicaoDama() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoDama(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca) {

            if (peca == null) {
                Console.Write("- ");
            }
            else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}