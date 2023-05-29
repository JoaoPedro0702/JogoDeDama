using System;
using tabuleiro;
using dama;

namespace dama_console {
    class Programa {

        static void Main(string[] args) {

            try {
                PartidaDeDama partida = new PartidaDeDama();

                while (!partida.terminada) {

                    try {

                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoDama().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] PosicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoDama().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);

                    }
                    catch (TabuleiroException e) {
                        System.Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}